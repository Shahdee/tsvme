using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace vme
{
    public partial class Canvas : UserControl
    {
    
        List<byte> pix8;
        List<ushort> pix16;
        long[] histogram;
        Bitmap bmp;

        int hOffset;
        int vOffset;
        int hMax;
        int vMax;
        int imgWidth;
        int imgHeight;
        int panWidth;
        int panHeight;
        bool newImage;
        public bool viewcolor;

        int winMin;
        int winMax;

        int winCentre;
        int winWidth;

        int winShr1;
        int deltaX;
        int deltaY;

        Point ptWLDown;
        double changeValWidth;
        double changeValCentre;
        bool rightMouseDown;
        bool imageAvailable;
        bool signed16Image;

        byte[] lut8;
        byte[] lut16;

        byte[] imagePixels8;
        byte[] imagePixels16;

        int sizeImg;
        int sizeImg3;

        Main mf;

        Imagebpp bpp;

        public Canvas()
        {
            InitializeComponent();
            
            pix8 = new List<byte>();
            pix16 = new List<ushort>();
    
            this.hScrollBar.Visible = false;
            this.vScrollBar.Visible = false;

            winMin = 0;
            winMax = 65535;

            ptWLDown = new Point();
            changeValWidth = 0.5;
            changeValCentre = 0.5;
            rightMouseDown = false;
            imageAvailable = false;
            signed16Image = false;

            lut8 = new byte[256];
            lut16 = new byte[65536];

            viewcolor = false;

            PerformResize();

        }

        public void EraseFields() 
        {
            pix8.Clear();
            pix16.Clear();
            winMin = 0;
            winMax = 65535;
            changeValWidth = 0.5;
            changeValCentre = 0.5;
            rightMouseDown = false;
            imageAvailable = false;
            signed16Image = false;
            viewcolor = false;
        }

        public bool NewImage
        {
            set
            {
                newImage = value;
            }
        }

        public bool Signed16Image
        {
            set { signed16Image = value; }
        }

        unsafe private void UIntToColor(uint color, ref byte* row, int j1)
        {

            byte G;
            byte B;
            byte R;
            byte A;

            uint colorX;
            uint res32;
            uint res24;
            uint res16;

            uint two_in_24_max = (1 << 24) - 1; // max 
            ushort two_in_16_max = (1 << 16) - 1; // max 

            if (color > two_in_24_max)
            {

                G = (byte)(color >> 24); // res24
                row[j1 + 1] = G;
                colorX = color >> 24;
                res32 = colorX << 24;
                color -= res32;

            }
            else
            {
                G = 0;
                row[j1 + 1] = G;
            }
            if (color > two_in_16_max)
            {
                B = (byte)(color >> 16);
                row[j1] = B;
                colorX = color >> 16;
                res24 = colorX << 16;
                color -= res24;
            }
            else
            {
                B = 0;
                row[j1] = B;
            }
            if (color > 255)
            {
                R = (byte)(color >> 8);
                row[j1 + 2] = R;
                colorX = color >> 8;
                res16 = colorX << 8;
                color -= res16;
            }
            else
            {
                R = 0;
                row[j1 + 2] = R;
                A = (byte)(color);
                return;
            }
            A = (byte)color;
            return;


        }

        /*для глубины  bpp=8*/
        public void SetParameters(ref List<byte> arr, int wid, int hei, double windowWidth,
            double windowCentre, int samplesPerPixel, bool resetScroll, Main mainFrm, long[] hi)
        {
            if (samplesPerPixel == 1)
            {
                bpp = Imagebpp.Eightbpp;
                imgWidth = wid;
                imgHeight = hei;
                histogram = new long[256];
                histogram = hi;
                winWidth = Convert.ToInt32(windowWidth);
                winCentre = Convert.ToInt32(windowCentre);
                changeValWidth = 0.1;
                changeValCentre = 0.1;
                sizeImg = imgWidth * imgHeight;
                sizeImg3 = sizeImg * 3;
                pix8 = arr;
                imagePixels8 = new byte[sizeImg3];
                mf = mainFrm;
                imageAvailable = true;
                if (bmp != null)
                    bmp.Dispose();
                ResetValues();
                ComputeLookUpTable8();
                bmp = new Bitmap(imgWidth, imgHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                CreateImage8();
            }

            if (resetScroll == true) ComputeScrollBarParameters();
            Invalidate();
        }


        public void SetParameters(ref List<ushort> arr,double intercept, int wid, int hei, double windowWidth,   // arr ushort
            double windowCentre, bool resetScroll, Main mainFrm, ref long[] hi)
        {
            bpp = Imagebpp.Sixteenbpp;
            imgWidth = wid;
            imgHeight = hei;
            histogram = hi;
            EraseHistogramArray();
            winWidth = Convert.ToInt32(windowWidth);
            winCentre = Convert.ToInt32(windowCentre);
            sizeImg = imgWidth * imgHeight;
            sizeImg3 = sizeImg * 3;
            double sizeImg3By4 = sizeImg3 / 4.0;
            if (signed16Image == true)
                winCentre -= short.MinValue;
            
            if (winWidth < 5000)
            {
                changeValWidth = 2;
                changeValCentre = 2;
            }
            else if (Width > 40000)
            {
                changeValWidth = 50;
                changeValCentre = 50;
            }
            else
            {
                changeValWidth = 25;
                changeValCentre = 25;
            }
            pix16 = arr;
            imagePixels16 = new byte[sizeImg3];
            mf = mainFrm;
            
            imageAvailable = true;
            if (bmp != null)
                bmp.Dispose();
            ResetValues();

            ComputeLookUpTable16();
            bmp = new Bitmap(imgWidth, imgHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            CreateImage16();
            if (resetScroll == true) ComputeScrollBarParameters();
            Invalidate();
        }

        public void CreateImage16()
        {
            BitmapData bmd = bmp.LockBits(new Rectangle(0, 0, imgWidth, imgHeight),
               System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat);

            Color c;
            
            unsafe
            {
                int pixelSize = 3;
                int i, j, j1, i1;
                byte b;

                for (i = 0; i < bmd.Height; ++i)
                {
                    byte* row = (byte*)bmd.Scan0 + (i * bmd.Stride);
                    i1 = i * bmd.Width;

                    for (j = 0; j < bmd.Width; ++j)
                    {
                        b = lut16[pix16[i * bmd.Width + j]];

                        histogram[b]++; // гистограмма для среза [0..255]

                        if (viewcolor)
                        {
                            
                            j1 = j * pixelSize;

                            UIntToColor(mf.colored_array[b],ref row, j1);
                        }
                        else 
                        {   
                            j1 = j * pixelSize;
                            row[j1] = b;
                            row[j1 + 1] = b;
                            row[j1 + 2] = b;
                        }
                    }
                    
                }
                //viewcolor = false;  // чтобы я могла всегда наблюдать цветное изображение, пока не сброшу по умолчанию параметры
            }
            bmp.UnlockBits(bmd);
        }

        /* работает и для ushort и для short, хотя работаю я здесь только с ushort */
        private void ComputeLookUpTable16()
        {
            int range = winMax - winMin;
            if (range < 1) range = 1;
            
            double factor = 255.0 / range;
            int i;

            for (i = 0; i < 65536; ++i)
            {
                if (i <= winMin)
                    lut16[i] = 0;
                else if (i >= winMax)
                    lut16[i] = 255;
                else
                {
                    lut16[i] = (byte)((i - winMin) * factor);
                }
            }
        }

        private void ComputeLookUpTable8()
        {
            if (winMax == 0)
                winMax = 255;

            int range = winMax - winMin;
            if (range < 1) range = 1;
            double factor = 255.0 / range;

            for (int i = 0; i < 256; ++i)
            {
                if (i <= winMin)
                    lut8[i] = 0;
                else if (i >= winMax)
                    lut8[i] = 255;
                else
                {
                    lut8[i] = (byte)((i - winMin) * factor);
                }
            }
        }

        private void CreateImage8()
        {
            BitmapData bmd = bmp.LockBits(new Rectangle(0, 0, imgWidth, imgHeight),
                System.Drawing.Imaging.ImageLockMode.ReadOnly, bmp.PixelFormat);

            unsafe
            {
                int pixelSize = 3;
                int i, j, j1, i1;
                byte b;

                for (i = 0; i < bmd.Height; ++i)
                {
                    
                    // это указатель на строку изображения 
                    byte* row = (byte*)bmd.Scan0 + (i * bmd.Stride);
                    i1 = i * bmd.Width;

                    for (j = 0; j < bmd.Width; ++j)
                    {
                        b = lut8[pix8[i1 + j]];
                        j1 = j * pixelSize;
                        row[j1] = b;            // RGB
                        row[j1 + 1] = b;       
                        row[j1 + 2] = b;       
                    }
                }
            }
            bmp.UnlockBits(bmd);
        }

        private void ComputeScrollBarParameters()
        {
            panWidth = surface.Width;
            panHeight = surface.Height;

            hOffset = (panWidth - imgWidth) / 2;
            vOffset = (panHeight - imgHeight) / 2;

            if (imgWidth < panWidth)
            {
                hScrollBar.Visible = false;
            }
            else
            {
                hScrollBar.Visible = true;
                hScrollBar.Value = (hScrollBar.Maximum + 1 - hScrollBar.LargeChange - hScrollBar.Minimum) / 2;
            }

            if (imgHeight < panHeight)
            {
                vScrollBar.Visible = false;
            }
            else
            {
                vScrollBar.Visible = true;
                vScrollBar.Value = (vScrollBar.Maximum + 1 - vScrollBar.LargeChange - vScrollBar.Minimum) / 2;
            }
        }

        private void vScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            int val = vScrollBar.Value;
            vOffset = (panHeight - imgHeight) * (val - vScrollBar.Minimum) / (vMax - vScrollBar.Minimum);
            Invalidate();
        }

        private void hScrollBar_Scroll(object sender, ScrollEventArgs e)
        {
            int val = hScrollBar.Value;
            hOffset = (panWidth - imgWidth) * (val - hScrollBar.Minimum) / (hMax - hScrollBar.Minimum);
            Invalidate();
        }

        private void Canvas_Paint(object sender, PaintEventArgs e)
        {
            if (bpp == Imagebpp.Eightbpp)
            {
                if (pix8.Count > 0)
                {
                    Graphics g = Graphics.FromHwnd(surface.Handle);
                    if (newImage == true)
                    {
                        g.Clear(SystemColors.Control);
                        newImage = false;
                    }

                    g.DrawImage(bmp, hOffset, vOffset);
                    g.Dispose();
                }
            }
            else if (bpp == Imagebpp.Sixteenbpp)
            {
                if (pix16.Count>0)
                {
                    Graphics g = Graphics.FromHwnd(surface.Handle);
                    if (newImage == true)
                    {
                        g.Clear(SystemColors.Control);
                        newImage = false;
                    }

                    g.DrawImage(bmp, hOffset, vOffset);
                    g.Dispose();
                }
            }

            int winCentreToDisplay = winCentre;
            int winMinToDisplay = winMin;
            int winMaxToDisplay = winMax;

        }

        private void UpdateMainForm()
        {
            mf.UpdateWindowLevel(winWidth, winCentre, bpp, histogram);

        }

        public void ResetValues()
        {

            winMax = Convert.ToInt32(winCentre + 0.5 * winWidth);
            winMin = winMax - winWidth;
           
            UpdateMainForm();
        }

        public void EraseHistogramArray()
        {
            for (int i = 0; i < 256; i++)
                histogram[i] = 0;
        }


       
        private void Surface_MouseDown(object sender, MouseEventArgs e)
        {
            if (imageAvailable == true)
            {
                if (e.Button == MouseButtons.Right)
                {
                    ptWLDown.X = e.X;
                    ptWLDown.Y = e.Y;
                    rightMouseDown = true;
                    Cursor = Cursors.Hand;
                }
            }
        }

        private void Surface_MouseUp(object sender, MouseEventArgs e)
        {
            if (rightMouseDown == true)
            {
                rightMouseDown = false;
                Cursor = Cursors.Default;
            }
        }

        private void Surface_MouseMove(object sender, MouseEventArgs e)
        {
            if (rightMouseDown == true)
            {
                winShr1 = winWidth >> 1;
                winWidth = winMax - winMin;
                winCentre = winMin + winShr1;

                deltaX = Convert.ToInt32((ptWLDown.X - e.X) * changeValWidth);
                deltaY = Convert.ToInt32((ptWLDown.Y - e.Y) * changeValCentre);

                winCentre -= deltaY;
                winWidth -= deltaX;

                if (winWidth < 2) winWidth = 2;

                winMin = winCentre - winShr1;
                winMax = winCentre + winShr1;

                if (winMin >= winMax) winMin = winMax - 1;
                if (winMax <= winMin) winMax = winMin + 1;

                ptWLDown.X = e.X;
                ptWLDown.Y = e.Y;

                EraseHistogramArray();
                if (bpp == Imagebpp.Eightbpp)
                {
                    ComputeLookUpTable8();
                    CreateImage8();
                }
                else if (bpp == Imagebpp.Sixteenbpp)
                {
                    ComputeLookUpTable16();
                    CreateImage16(); //  здесь  расчитывается также гистограмма изображения
                }
                UpdateMainForm();
                Invalidate();
            }
        }

        private void Canvas_Resize(object sender, EventArgs e)
        {
            PerformResize();
        }

        private void PerformResize()
        {
            surface.Location = new Point(3, 3);
            surface.Width = ClientRectangle.Width - 24;
            surface.Height = ClientRectangle.Height - 24;

            vScrollBar.Location = new Point(ClientRectangle.Width - 19, 3);
            vScrollBar.Height = surface.Height;

            hScrollBar.Location = new Point(3, ClientRectangle.Height - 19);
            hScrollBar.Width = surface.Width;

            hMax = hScrollBar.Maximum - hScrollBar.LargeChange + hScrollBar.SmallChange;
            vMax = vScrollBar.Maximum - vScrollBar.LargeChange + vScrollBar.SmallChange;
        }

    }
}

using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace vme
{
    public partial class ImageViewer : Form
    {

        private List<byte> pix8;
        private List<ushort> pix16;
        private long[] histogram;
        //private Bitmap bmp;

        private int hOffset;
        private int vOffset;
        private int hMax;
        private int vMax;
        private int imgWidth;
        private int imgHeight;
        private int panWidth;
        private int panHeight;

        private bool newImage;
        public bool NewImage
        {
            get { return newImage; }
            set { newImage = value; } // WRONG
        }

        public bool viewcolor; // WRONG

        private int winMin;
        private int winMax;

        private int winCentre;
        private int winWidth;

        private int winShr1;
        private int deltaX;
        private int deltaY;

        private Point ptWLDown;
        private double changeValWidth;
        private double changeValCentre;
        private bool rightMouseDown;
        private bool imageAvailable;

        public bool signed16Image; // WRONG
        public bool Signed16Image
        {
            get { return signed16Image; }
            set { signed16Image = value; } // WRONG
        }

        private byte[] lut8;
        private byte[] lut16;

        private byte[] imagePixels8;
        private byte[] imagePixels16;

        private int sizeImg;
        private int sizeImg3;

        private Color pixelColor;
        private Color fillColor;

        Main mf;

        Imagebpp bpp;

        public ImageViewer()
        {
            InitializeComponent();

            pix8 = new List<byte>();
            pix16 = new List<ushort>();

            //hScrollBar
            //v...

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
            pixelColor = Color.Empty;
            fillColor = Color.Empty;
        }

        public void SetParameters(ref List<byte> arr, int wid, int hei, double windowWidth,
           double windowCentre, int samplesPerPixel, bool resetScroll, Main mainFrm, long[] hi, Color inkColor)
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
                if (this.bmp != null)
                    this.bmp.Dispose();
                //ResetValues();
                fillColor = inkColor;
                ComputeLookUpTable8();
                this.bmp = new Bitmap(imgWidth, imgHeight, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                CreateImage8();
            }

            //if (resetScroll == true) ComputeScrollBarParameters();
            Invalidate();
        }

        public void ComputeLookUpTable8()
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

        public void CreateImage8()
        {
            BitmapData bmd = this.bmp.LockBits(new Rectangle(0, 0, imgWidth, imgHeight),
                System.Drawing.Imaging.ImageLockMode.ReadOnly, this.bmp.PixelFormat);

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


        public void SetParameters(ref List<ushort> arr, double intercept, int wid, int hei, double windowWidth,   // arr ushort
            double windowCentre, bool resetScroll, Main mainFrm, ref long[] hi, Color inkColor)
        {
            
            bpp = Imagebpp.Sixteenbpp;
            imgWidth = wid;
            imgHeight = hei;
            histogram = hi;
            //EraseHistogramArray();
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
            if (this.bmp != null)
                this.bmp.Dispose();
            //ResetValues();
            fillColor = inkColor;
            ComputeLookUpTable16();
            this.bmp = new Bitmap(imgWidth, imgHeight, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            CreateImage16();
            //if (resetScroll == true) ComputeScrollBarParameters();
            Invalidate();
        }

        public void CreateImage16()
        {
            BitmapData bmd = this.bmp.LockBits(new Rectangle(0, 0, imgWidth, imgHeight),
               System.Drawing.Imaging.ImageLockMode.ReadOnly, this.bmp.PixelFormat);

            unsafe
            {
                int pixelSize = 4;
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

                            UIntToColor(mf.colors[b], ref row, j1);

                        }
                        else
                        {

                            j1 = j * pixelSize;
                            row[j1] = b;
                            row[j1 + 1] = b;
                            row[j1 + 2] = b;
                            row[j1 + 3] = 255;
                        }
                    }

                }
                //viewcolor = false;  // чтобы я могла всегда наблюдать цветное изображение, пока не сброшу по умолчанию параметры
            }
            bmp.UnlockBits(bmd);
        }

        public void ComputeLookUpTable16()
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

        unsafe public void UIntToColor(uint color, ref byte* row, int j1)
        {
            byte G;
            byte B;
            byte R;
            byte A;
            uint colorX;
            uint res32;
            uint res24;
            uint res16;

            uint two_in_24_max = (1 << 24) - 1;
            ushort two_in_16_max = (1 << 16) - 1;

            if (color > two_in_24_max)
            {

                G = (byte)(color >> 24);
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
                row[j1 + 3] = A;
                return;
            }
            A = (byte)color;
            row[j1 + 3] = A;
            return;
        }

    }
}

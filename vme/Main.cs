using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace vme
{
    public partial class Main : Form
    {
        private bool readable = false;
        private DicomDecoder dec;
        protected List<byte> pixels8;
        protected List<ushort> pixels16;
        protected List<ushort> pixels_volume;

        public long[] histogram; // WRONG
        public uint[] colors; // для передачи в DVR
        public float[] opacity; // WRONG

        private int knots_counter;

        public int KnotsCounter
        {
            get { return knots_counter; }
            set { knots_counter = value; } // WRONG
        }
        private VoxelImage vform;
        private ushort num_of_images;
        private ushort image_number;
        private string safename;
        private bool navi;

        private int imageWidth;
        private int imageHeight;

        public int ImageWidth
        {
            get { return imageWidth; }
            private set { imageWidth = value; }
        }
        public int ImageHeight
        {
            get { return imageHeight; }
            private set { imageHeight = value; }
        }

        private double winWidth;
        private double winCentre;
        private ushort bpp;
        private int spp;
        private bool signedImage;
        private short intercept;
        private short slope;
        private string path;

        private Color inkColor;

        public Color InkColor
        {
            get { return inkColor; }
            private set { inkColor = value; }
        }

        public Main()
        {
            InitializeComponent();
            this.IsMdiContainer = true;
            dec = new DicomDecoder();
            pixels8 = new List<byte>();
            pixels16 = new List<ushort>();
            pixels_volume = new List<ushort>();
            colors = new uint[256];
            opacity = new float[256];
            signedImage = false;
            num_of_images = 0;
            image_number = 0;
            safename = "";
            navi = false;
            inkColor = Color.Red;
        }

        public void openDicom_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "All DICOM Files(*.*)|*.*";
            if ((ofd.ShowDialog() == DialogResult.OK) && (ofd.FileName.Length > 0))
            {
                pixels16.Clear();
                pixels8.Clear();
                dec.EraseFields();
                Cursor = Cursors.WaitCursor;
                ReadAndDisplayDicomFile(ofd.FileName, ofd.SafeFileName);
                Cursor = Cursors.Default;
                num_of_images++;
            }
            ofd.Dispose();
        }

        public void ReadAndDisplayDicomFile(string filename, string name)
        {
            if (readable = dec.ReadFile(filename))
                DisplayData();
            else
                MessageBox.Show("Невозможно обработать файл");
            return;
        }

        public void DisplayData()
        {
            /* here I can add work panels */
            view = new ImageViewer(); // HERE IT IS
            view.MdiParent = this; // HERE IT IS
            tf = new TransferFunction(); // HERE IT IS
            tf.MdiParent = this; // HERE IT IS
            roi = new ROI();
            roi.MdiParent = this;
            pr = new Presets();
            pr.MdiParent = this;
            pl = new HSVpalette();
            pl.MdiParent = this;
            view.Show(); // HERE IT IS
            tf.Show(); // HERE IT IS
            roi.Show();
            pr.Show();
            pl.Show();

            imageWidth = dec.Width;
            imageHeight = dec.Height;
            bpp = dec.BitsAllocated; // количество бит на пиксель
            winCentre = dec.WindowCenter; // средняя величина между самым ярким и самым тусклым пикселем
            winWidth = dec.WindowWidth; // разница между самым ярким и самым тусклым пикселем
            spp = dec.SamplesPerPixel;
            if (dec.Intercept < 0)
            {
                dec.SignedImage = true; // ага, а я ведь залочила для других классов модификацию поля
            }
            signedImage = dec.SignedImage;
            view.Signed16Image = dec.SignedImage; // short или ushort изображение
            view.NewImage = true;
            /*ImagePlane.Signed16Image = dec.SignedImage; // short или ushort изображение
            ImagePlane.NewImage = true;*/

            histogram = new long[256];
            if (spp == 1 && bpp == 8)
            {
                pixels8.Clear();
                pixels16.Clear();
                dec.GetPixels8(ref pixels8);
                if (winCentre == 0 && winWidth == 0)
                {
                    winWidth = 256;
                    winCentre = 128;
                }
                view.SetParameters(ref pixels8, imageWidth, imageHeight, winWidth, winCentre, spp, true, this, histogram, inkColor);
                //ImagePlane.SetParameters(ref pixels8, imageWidth, imageHeight, winWidth, winCentre, spp, true, this, histogram, inkColor);
            }
            if (spp == 1 && bpp == 16)
            {
                pixels16.Clear();
                pixels8.Clear();
                dec.GetPixels16(ref pixels16);
                intercept = (short)dec.Intercept;
                slope = (short)dec.Slope;
                // Учитываем Modality LUT
                if (dec.Intercept < 0)
                {
                    for (int i = 0; i < pixels16.Count; i++)
                        pixels16[i] = (ushort)(((short)(pixels16[i] * slope + intercept)) + 32768);
                }
                if (winCentre == 0 && winWidth == 0)
                {
                    winWidth = 65536;
                    winCentre = 32768;
                }
                if (!navi)
                {
                    for (int i = 0; i < pixels16.Count; i++)
                    {
                        pixels_volume.Add(pixels16[i]);
                    }
                }
                view.SetParameters(ref pixels16, intercept, imageWidth, imageHeight, winWidth, winCentre, true, this, ref histogram, inkColor);
                //ImagePlane.SetParameters(ref pixels16, intercept, imageWidth, imageHeight, winWidth, winCentre, true, this, ref histogram, inkColor);
                //ColoredTFobj.PassAlong(this);
                tf.PassAlong(this);
            }
            /* если у нас 16bpp lossless CT изображение */
            if (spp == 1 && bpp == 16 && dec.CompressedImage)
            {
                // позже доделать чтение lossless и учет предсказателя, притом что дерево уже построенно правильно и есть сырые данные
            }
        }

        public void EraseHistogramArray()
        {
            for (int i = 0; i < 256; i++)
                histogram[i] = 0;
        }

        public void UpdateWindowLevel(int winWidth_from_Canvas, int winCentre_from_Canvas, Imagebpp bpp, long[] histogram)
        {
            int winMin = Convert.ToInt32(winCentre_from_Canvas - 0.5 * winWidth_from_Canvas);
            int winMax = winMin + winWidth_from_Canvas;
            winWidth = winWidth_from_Canvas;
            winCentre = winCentre_from_Canvas;

            int w = (int)winWidth;
            int с = (int)winCentre;

            //this.Windowing.SetWindowWidthCentre(winMin, winMax, w, с, bpp, signedImage);
            //this.ColoredTFobj.SetParametersHistogram(winMin, winMax, w, с, bpp, signedImage, histogram);
            this.tf.SetParametersHistogram(winMin, winMax, w, с, bpp, signedImage, histogram);
        }

        public void UpdateFromColoredTF()
        {
            winWidth = dec.WindowWidth;
            winCentre = dec.WindowCenter;

            //this.ImagePlane.viewcolor = false;
            //EraseHistogramArray();
            //this.ImagePlane.SetParameters(ref pixels16, intercept, imageWidth, imageHeight, winWidth, winCentre, false, this, ref  histogram, inkColor);
        }

        public void UpdateColorFromHistogram(double width_from_coloredTF, double center_from_coloredTF)
        {
            int width = (int)(width_from_coloredTF);
            int center = (int)(center_from_coloredTF + short.MinValue);

            //this.ImagePlane.viewcolor = true;
            //this.ImagePlane.EraseHistogramArray();
            //this.ImagePlane.SetParameters(ref pixels16, intercept, imageWidth, imageHeight, width, center, false, this, ref  histogram, inkColor);
        }

        public void MainClose(object sender, FormClosingEventArgs e)
        {
            pixels8.Clear();
            pixels16.Clear();
            //ImagePlane.Dispose();
        }

        /*  По умолчанию область*/
        public void Reset_Click(object sender, EventArgs e)
        {
            if (pixels8 != null || pixels16 != null)
            {
                if ((pixels8.Count > 0) || (pixels16.Count > 0))
                {
                    EraseHistogramArray();
                    winWidth = dec.WindowWidth;
                    winCentre = dec.WindowCenter;
                    //ImagePlane.viewcolor = false;
                    if (bpp == 8)
                    {
                        if (spp == 1) { }
                        //ImagePlane.SetParameters(ref pixels8, imageWidth, imageHeight, winWidth, winCentre, spp, false, this, histogram, inkColor);
                    }

                    if (bpp == 16) { }
                    {
                        //ImagePlane.SetParameters(ref pixels16, intercept, imageWidth, imageHeight, winWidth, winCentre, false, this, ref  histogram, inkColor);
                    }
                }
            }
            else
                MessageBox.Show("Загрузите DICOM файл перед восстановлением параметров!");
        }

        public void inkButton_Click(object sender, EventArgs e)
        {
            ColorDialog inkDialog = new ColorDialog();
            inkDialog.AllowFullOpen = true;
            inkDialog.ShowHelp = true;
            if (inkDialog.ShowDialog() == DialogResult.OK)
            {
                inkColor = inkDialog.Color;
            }
        }

        public void openChest_Click(object sender, EventArgs e)
        {
            path = "D:\\tsvme\\DICOM images\\my\\";
            for (int i = 1; i < 167; i++)
            {
                safename = "_" + Convert.ToString(i);
                pixels16.Clear();
                pixels8.Clear();
                dec.EraseFields();
                //ImagePlane.EraseFields();
                Cursor = Cursors.WaitCursor;
                ReadAndDisplayDicomFile(path + safename, safename);
                Cursor = Cursors.Default;
                //image_label.Text = path + safename;
                num_of_images++;
            }
            image_number = num_of_images;
        }

        public void openKid_Click(object sender, EventArgs e)
        {
            path = "D:\\tsvme\\DICOM images\\kid\\";
            for (int i = 30; i < 190; i++)
            {
                safename = "_" + Convert.ToString(i);
                pixels16.Clear();
                pixels8.Clear();
                dec.EraseFields();
                //ImagePlane.EraseFields();
                Cursor = Cursors.WaitCursor;
                ReadAndDisplayDicomFile(path + safename, safename);
                Cursor = Cursors.Default;
                //image_label.Text = path + safename;
                num_of_images++;
            }
            image_number = num_of_images;
        }

        public void backward_Click(object sender, EventArgs e)
        {
            if (image_number > 1)
            {
                pixels16.Clear();
                dec.EraseFields();
                //ImagePlane.EraseFields();
                image_number--;
                //image_label.Text = path + image_number;
                safename = "_" + image_number;
                navi = true;
                ReadAndDisplayDicomFile(path + safename, safename);
            }
        }

        public void forward_Click(object sender, EventArgs e)
        {
            if (image_number < num_of_images)
            {
                pixels16.Clear();
                dec.EraseFields();
                //ImagePlane.EraseFields();
                image_number++;
                //image_label.Text = path + image_number;
                safename = "_" + image_number;
                navi = true;
                ReadAndDisplayDicomFile(path + safename, safename);
            }
        }

        public void volumeReconstruction_Click(object sender, EventArgs e)
        {
            vform = new VoxelImage();
            vform.VoxelImage_Load(pixels_volume, num_of_images, winCentre, winWidth, dec.Intercept, dec.SignedImage, this);
            vform.Idle();
            vform.Show();
        }

    }
}



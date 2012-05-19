using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;


namespace vme
{
    

    public partial class Main : Form
    {
        public bool readable = false;
        
        DicomDecoder dec;
        List<byte> pixels8;
        List<ushort> pixels16;
        List<short> pixels16_signed; //
        ushort[] histogram_main;
        ushort[] histogram_HU_main;
        
        
        public int imageWidth;
        public  int imageHeight;
        public double winWidth;
        public double winCentre;
        public ushort bpp;
        public int spp; // количество сэмплов на пиксель 1-градации серого и  для монохромных и  3-RGB 
        public bool signedImage;
        public short intercept;
        public short slope;

        public Main()
        {
            InitializeComponent();
            dec = new DicomDecoder();
            pixels8 = new List<byte>();
            pixels16 = new List<ushort>();
            pixels16_signed = new List<short>();  //
            signedImage = false;

        }

        private void Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "All DICOM Files(*.*)|*.*";

            if ((ofd.ShowDialog() == DialogResult.OK) && (ofd.FileName.Length > 0))
            {
                    Cursor = Cursors.WaitCursor;
                    ReadAndDisplayDicomFile(ofd.FileName, ofd.SafeFileName);
                    Cursor = Cursors.Default;
            }
                ofd.Dispose();
        }

        private void ReadAndDisplayDicomFile(string filename, string name) 
        {
            if (readable = dec.ReadFile(filename))
                DisplayData();
            else
                MessageBox.Show("Невозможно обработать файл");
            return ;
        }

        private void DisplayData()
        {
            imageWidth = dec.width;
            imageHeight = dec.height;
            bpp = dec.bitsAllocated; // количество бит на пиксель
            winCentre = dec.windowCentre; // средняя величина между самым ярким и самым тусклым пикселем
            winWidth = dec.windowWidth; // разница между самым ярким и самым тусклым пикселем
            spp = dec.samplesPerPixel;  // количество сэмплов на пиксель
            if (dec.rescaleIntercept < 0)
            {
                dec.signedImage = true;
                ImagePlane.Signed16Image = true;
            }
            ImagePlane.Signed16Image = dec.signedImage; // знаковое изображение или нет
            ImagePlane.NewImage = true; 
            histogram_main = new ushort[imageWidth*imageHeight];
            histogram_HU_main = new ushort[imageWidth*imageHeight];
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
                ImagePlane.SetParameters(ref pixels8, imageWidth, imageHeight, winWidth, winCentre, spp, true, this, histogram_main, histogram_HU_main);
            }
            if (spp == 1 && bpp == 16)
            {
                pixels16.Clear();
                pixels8.Clear();
                dec.GetPixels16(ref pixels16);
                intercept = (short) dec.rescaleIntercept;
                slope = (short) dec.rescaleSlope;

                // Учитываем Modality LUT
                if (dec.rescaleIntercept < 0)
                {
                    for (int i = 0; i < pixels16.Count; i++)
                        pixels16_signed.Add((short)(pixels16[i] * slope+intercept));
                }
                if (winCentre == 0 && winWidth == 0)
                {
                    winWidth = 65536;
                    winCentre = 32768;
                }

                if (dec.rescaleIntercept < 0)
                {   
                    ImagePlane.SetParametersIntercept(ref pixels16_signed, intercept, imageWidth, imageHeight, winWidth, winCentre, true, this, histogram_main, histogram_HU_main);
                }
                else
                    ImagePlane.SetParameters(ref pixels16, intercept, imageWidth, imageHeight, winWidth, winCentre, true, this, histogram_main, histogram_HU_main);
                Histogram.PassAlong(this); // передача MainForm в Control Гистограмма
            }
            /* если у нас 16bpp lossless CT изображение */
            if (spp == 1 && bpp == 16 && dec.compressedImage)
            {
                //...
            }
        }

        public void UpdateWindowLevel(int winWidth, int winCentre, Imagebpp bpp)
        {
            int winMin = Convert.ToInt32(winCentre - 0.5 * winWidth);
            int winMax = winMin + winWidth;

            this.TransferFunction.SetWindowWidthCentre(winMin, winMax, winWidth, winCentre, bpp, signedImage);
            this.Histogram.SetParametersHistogram(winMin, winMax, winWidth, winCentre, bpp, signedImage);
        }

        public void UpdateFormHitosgram() 
        {
            this.TransferFunction.Invalidate();
            this.ImagePlane.Invalidate();
        }

        private void MainClose(object sender, FormClosingEventArgs e)
        {
            pixels8.Clear();
            pixels16.Clear();
            ImagePlane.Dispose();
        }

        private void Reset_Click_1(object sender, EventArgs e)
        {
            if ((pixels8.Count > 0) || (pixels16.Count > 0) || (pixels16_signed.Count > 0))
            {
                ImagePlane.ResetValues();
                if (bpp == 8)
                {
                    if (spp == 1)
                            ImagePlane.SetParameters(ref pixels8, imageWidth, imageHeight, winWidth, winCentre, spp, false, this, histogram_main, histogram_HU_main);
                }

                if (bpp == 16)
                {
                    if (intercept == 0)
                        ImagePlane.SetParameters(ref pixels16, intercept, imageWidth, imageHeight, winWidth, winCentre, false, this, histogram_main, histogram_HU_main);
                    else 
                    {
                        ImagePlane.SetParametersIntercept(ref pixels16_signed, intercept, imageWidth, imageHeight, winWidth, winCentre, false, this, histogram_main, histogram_HU_main);
                    }
                }
            }
            else
                MessageBox.Show("Загрузите DICOM файл перед восстановлением параметров!");
        }

        private void reset_fn_Click(object sender, EventArgs e)
        {
            if ((pixels8.Count > 0) || (pixels16.Count > 0) || (pixels16_signed.Count > 0))
            {
                Histogram.ResetValues();
            }
            else
                MessageBox.Show("Загрузите DICOM файл перед восстановлением параметров 2 !");
        }

        /* Присваивает цвета и степень прозрачности пикселям изображения в зависимости от передаточной функции*/
        private void AssignCA_Click(object sender, EventArgs e)
        {
            
        }

        private void Color_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            MyDialog.AllowFullOpen = false;
            // Allows the user to get help. (The default is false.)
            MyDialog.ShowHelp = true;
            // Sets the initial color select to the current text color.
            MyDialog.Color = Histogram.ForeColor;

            // Update the text box color if the user clicks OK 
            if (MyDialog.ShowDialog() == DialogResult.OK)
                Histogram.ForeColor = MyDialog.Color;

            Histogram.pp.c = MyDialog.Color; // run-time error
        }

    }
}

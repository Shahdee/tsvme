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
    public enum Imagebpp { Eightbpp, Sixteenbpp  };

    public partial class Main : Form
    {
        public bool readable = false;
        
        DicomDecoder dec;
        List<byte> pixels8;
        List<ushort> pixels16;
        
        public int imageWidth;
        public  int imageHeight;
        public double winWidth;
        public double winCentre;
        public ushort bpp;
        public int spp; // количество сэмплов на пиксель 1-градации серого и  для монохромных и  3-RGB 
        public bool signedImage;

        public Main()
        {
            InitializeComponent();
            dec = new DicomDecoder();
            pixels8 = new List<byte>();
            pixels16 = new List<ushort>();
            signedImage = false;
            
        }

        private void Open_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();

            ofd.Filter = "All DICOM Files(*.*)|*.*";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                if (ofd.FileName.Length > 0)
                {
                    Cursor = Cursors.WaitCursor;

                    ReadAndDisplayDicomFile(ofd.FileName, ofd.SafeFileName);

                    Cursor = Cursors.Default;
                }
                ofd.Dispose();
            }
        }

        private void ReadAndDisplayDicomFile(string filename, string name) 
        {
            if (readable = dec.ReadFile(filename))
            {
                DisplayData();
            }
            else
            {
                MessageBox.Show("Sorry I can't handle this file");
            }
            return ;
        }

        private void DisplayData()
        {
            imageWidth = dec.width;
            imageHeight = dec.height;
            bpp = dec.bitsAllocated;
            winCentre = dec.windowCentre;
            winWidth = dec.windowWidth;
            spp = dec.samplesPerPixel;
            signedImage = dec.signedImage;
            ImagePlane.NewImage = true;

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

                ImagePlane.SetParameters(ref pixels8, imageWidth, imageHeight,
                    winWidth, winCentre, spp, true, this);
            }

            if (spp == 1 && bpp == 16)
            {
                pixels16.Clear();
                pixels8.Clear();
                dec.GetPixels16(ref pixels16);

                if (winCentre == 0 && winWidth == 0)
                {
                    winWidth = 65536;
                    winCentre = 32768;
                }

                ImagePlane.Signed16Image = dec.signedImage;
                ImagePlane.SetParameters(ref pixels16, imageWidth, imageHeight, winWidth, winCentre, true, this);
            }

            /* если у нас 16bpp lossless CT изображение */
            if (spp == 1 && bpp == 16 && dec.compressedImage)
            {
               



            }

            
        }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenCLNet;

namespace vme
{
    public partial class ColoredTF : UserControl
    {
        int marginLeft;
        int marginRight;
        int marginTop;
        int marginBottom;
        int graphWidth;
        int graphHeight;

        int winWidth;
        int winCentre;
        int winMin;
        int winMax;

        Main form_this;

        public Knot pp; 
        List<Knot> knots; // массив узловых точек
        long[] histogram_255;
        Imagebpp iBpp;

        bool signedImage;
        bool first;
        bool paint_histogram;

        public ColoredTF()
        {
            InitializeComponent();
            DoubleBuffered = true;
            marginLeft = 182;
            marginRight = 182;
            marginTop = 75;
            marginBottom = 74;
            pp.p.X = 0;
            pp.p.Y = 0;

            winWidth = 0;
            winCentre = 0;
            signedImage = false;

            paint_histogram = false;
            first = true; // last upd
            knots = new List<Knot>();
            pp = new Knot();
            pp.p = new Point(marginLeft + 1, this.Height - marginBottom - 1);
            pp.c = System.Drawing.Color.Black; 
            knots.Add(pp);  
           
        }

        public void PassAlong(Main form)
        {
            form_this = form;
        }

        public void SetParametersHistogram(int minVal, int maxVal, int widthVal, int centreVal, Imagebpp bpp, bool sign, long[] histogram)
        {

            winMin = minVal;
            winMax = maxVal;
            winWidth = widthVal;
            winCentre = centreVal;
            first = false;
            
            iBpp = bpp;
            signedImage = sign;
            histogram_255 = histogram;
            paint_histogram = true;
            Invalidate();
        }

        /* очищает параметры гистограммы: контрольные точки */
        public void ResetValues()
        {
            knots.Clear();  // очистить все контрольные точки и этого достаточно
            paint_histogram = true;

            pp.p = new Point(marginLeft + 1, this.Height - marginBottom - 1); // устанавливается единственная точка в нуле по умолчанию
            pp.c = System.Drawing.Color.Black;
            knots.Add(pp);

            form_this.UpdateFromColoredTF();
            Invalidate();
        }

        private uint ColorBytesToUInt(byte b3, byte b2, byte b1, byte b0)
        {
            return (uint)((b3 << 24) + (b2 << 16) + (b1 << 8) + b0);
        }

        private uint ColorToUInt(Color c) // GBRA
        {
            uint  gu =c.G
                , bu= c.B
                , ru =c.R
                , au= c.A;

            return (uint)((gu << 24) + (bu << 16) + (ru << 8) + au);
        }

        private Float4 UIntToColor(uint color)
        {
            byte G;
            byte B;
            byte R;
            byte A;

            Float4 Color;

            uint colorX;
            uint res32;
            uint res24;
            uint res16;
            
            uint two_in_24_max = (1 << 24) -1; // max 
            ushort two_in_16_max = (1 << 16)-1; // max 
            
            if (color > two_in_24_max)
            {
                G = (byte)(color >> 24); // res24
                colorX = color >> 24;
                res32 = colorX << 24;
                color -= res32;

            }
            else 
            {
                G = 0;
            }
            if (color > two_in_16_max)
            {
                B = (byte)(color>>16);
                colorX = color >> 16;
                res24 = colorX << 16;
                color -= res24;
            }
            else 
            {
                B = 0;
            }
            if (color > 255)
            {
                R =(byte)(color>>8);
                colorX = color >> 8;
                res16 = colorX << 8;
                color -= res16;
            }
            else
            {
                R = 0;
                A = (byte)(color);
                Color.S0 = G;
                Color.S1 = B;
                Color.S2 = R;
                Color.S3 = A;
                return Color;
            }
            A = (byte)color;
            Color.S0 = G;
            Color.S1 = B;
            Color.S2 = R;
            Color.S3 = A;
            return Color;
           
           
        }

        /*метод рисует границы и сетку*/
        private void DrawBoundaryAndGrid(Graphics g)
        {

            // границы и цвет фона
            Point pt1 = new Point(marginLeft, marginTop);
            Point pt2 = new Point(Width - marginRight, marginTop);
            Point pt3 = new Point(Width - marginRight, Height - marginBottom);
            Point pt4 = new Point(marginLeft, Height - marginBottom);
            Pen p = new Pen(System.Drawing.Color.LightGray);
            Brush br = new SolidBrush(System.Drawing.Color.White);

            // задний фон 
            Rectangle rect = new Rectangle(pt1.X, pt1.Y, pt2.X - pt1.X, pt3.Y - pt1.Y);
            g.FillRectangle(br, rect);

            Point pv11, pv21, ph11, ph21;
            pv11 = new Point();
            pv21 = new Point();
            ph11 = new Point();
            ph21 = new Point();

            int iNoVDivisions = 10, iNoHDivisions = 8;
            int iVertSpace = Convert.ToInt32((Height - marginTop - marginBottom) / iNoVDivisions);
            int iHorizSpace = Convert.ToInt32((Width - marginLeft - marginRight) / iNoHDivisions);

            // решетка
            for (int i = 1; i < iNoVDivisions; ++i)
            {
                pv11.X = marginLeft;
                pv11.Y = marginTop + i * iVertSpace;
                pv21.X = Width - marginRight;
                pv21.Y = pv11.Y;
                g.DrawLine(p, pv11, pv21);
            }


            for (int i = 1; i < iNoHDivisions; ++i)
            {
                ph11.X = marginLeft + i * iHorizSpace;
                ph11.Y = marginTop;
                ph21.X = ph11.X;
                ph21.Y = Height - marginBottom;
                g.DrawLine(p, ph11, ph21);
            }

            // границы прямоугольника
            p.Color = System.Drawing.Color.Azure;
            p.Width = 2;
            g.DrawLine(p, pt1, pt2);
            g.DrawLine(p, pt2, pt3);
            g.DrawLine(p, pt3, pt4);
            g.DrawLine(p, pt4, pt1);

            p.Dispose();
            br.Dispose();
        }

        private void DrawLines(Graphics g)
        {
            graphWidth = Width - marginLeft - marginRight;
            graphHeight = Height - marginTop - marginBottom;
        }

        /* подписи к графику */
        private void DrawAxesLabels(Graphics gr)
        {
            Font f = new Font("Calibri", 10);
            Brush br = new SolidBrush(System.Drawing.Color.Black);
            PointF p = new PointF();
            p.X = marginLeft - 24;
            p.Y = marginTop - 2;
            gr.DrawString("100", f, br, p);

            p.X = marginLeft - 10;
            p.Y = marginTop + graphHeight - 12;
            gr.DrawString("0", f, br, p);

            string strMax = "255";
            string strMin = "0";

            p.X = marginLeft - 5;
            p.Y = marginTop + graphHeight + 2;

            if (iBpp == Imagebpp.Eightbpp)
            {
                gr.DrawString("0", f, br, p);
                p.X = marginLeft + graphWidth - 19;
            }
            else 
            {
                strMin = Convert.ToString(winMin + short.MinValue);
                strMax = Convert.ToString(winMax + short.MinValue);
            }

            // метки на горизонтальных линиях
            gr.DrawString(strMin, f, br, p);
            p.X = marginLeft + graphWidth - 34;
            gr.DrawString(strMax, f, br, p);
            br.Dispose();

            br = new SolidBrush(System.Drawing.Color.RosyBrown);

            p.X = marginLeft + 35;
            p.Y = marginTop + graphHeight + 2;
            gr.DrawString("HU", f, br, p);

            p.X = marginLeft - 20;
            p.Y = marginTop + 25;
            StringFormat sf = new StringFormat(StringFormatFlags.DirectionVertical);
            gr.DrawString("Яркость[bpp] и непрозрачность[%]", f, br, p, sf);

            f.Dispose();
            br.Dispose();
        }

        /* Отрисовка линий между контрольными точками */
        private void DrawLine(Graphics g)
        {
            Pen pn = new Pen(System.Drawing.Color.Chocolate);
            if (knots.Count > 1)
            {
                for (int i = 0; i < knots.Count - 1; i++)
                    g.DrawLine(pn, knots[i].p, knots[i + 1].p);
            }
            pn.Dispose();
        }

        /* Отрисовка массива точек */
        private void DrawKnotsArray(Graphics g)
        {
            for (int i = 0; i < knots.Count; i++)
                DrawPoint(g, knots[i]);
        }

        /* Отрисовка 1 точки */
        private void DrawPoint(Graphics g, Knot j)
        {
            Pen pn = new Pen(j.c);
            SolidBrush brush = new SolidBrush(j.c);
            pn.DashStyle = DashStyle.DashDot;
            pn.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            g.DrawEllipse(pn, j.p.X - 3, j.p.Y - 3, 6, 6);
            g.FillEllipse(brush, j.p.X - 3, j.p.Y - 3, 6, 6);
            pn.Dispose();
        }

        void UpdMainForm()
        {
            form_this.UpdateFromColoredTF();
        }

        private bool CanDraw()
        {
            for (int i = 0; i < knots.Count; i++)
            {
                if (knots[i].p.X >= pp.p.X)
                    return false;
            }
            return true;
        }


        private void reset_fn_Click(object sender, EventArgs e)
        {
            if (form_this!=null)
            {
                ResetValues(); 
            }
            else
                MessageBox.Show("Сначала загрузите DICOM файл");
        }

        private void Color_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = true;
            MyDialog.ShowHelp = true;
            MyDialog.Color = pp.c;
            if (MyDialog.ShowDialog() == DialogResult.OK)
                pp.c = MyDialog.Color;
        }

        private void ColoredTF_MouseClick(object sender, MouseEventArgs e) 
        {
            if (form_this != null)
            {
                pp.p.X = e.X; // !
                pp.p.Y = e.Y;
                paint_histogram = true;
                // цвет присваивается за счет указания через ColorDialog
                if (pp.p.X > marginLeft && pp.p.X < Width - marginRight && pp.p.Y > marginTop && pp.p.Y < Height - marginBottom && CanDraw() && form_this != null)
                {
                    knots.Add(pp);
                    Invalidate();
                }
            }
        }

        /* Строит гистограмму для текущего *окна* изображения  */
        private void DrawHistogram(Graphics g) 
        {
            float height;
            int py;  // то что надо отрисовать на оси y в форме
            int pos = marginLeft + 1;
            double cons_t = ((5.5) - (0.1)) / (Math.Log10(512*512) - Math.Log10(0.1));

            for (int i = 0; i < 256; i++) 
            {
                py = (int)( (0.1) + cons_t * (Math.Log10(histogram_255[i]) - Math.Log10(0.1)) );
                height = (float)(py * ((this.Height - 2 - marginBottom - marginTop)) / (Math.Log10(512 * 512)));
                py = (int)(height);

                if (height > 0)
                {
                    Pen pn = new Pen(System.Drawing.Color.LightGray);
                    Point p1 = new Point(pos, this.Height - marginBottom - 1);
                    Point p2 = new Point(pos, this.Height - marginBottom - 1 - py);
                    g.DrawLine(pn, p1, p2);
                }
                pos++;
                   
            }
            paint_histogram = false;
        }

        private void ColoredTF_Paint(object sender, PaintEventArgs e) 
        {
            Bitmap bmp = new Bitmap(this.Width, this.Height);
            Graphics gr = Graphics.FromImage(bmp);
            DrawBoundaryAndGrid(gr);
            if ((winWidth * winCentre) != 0)
                DrawLines(gr);
            if ((winWidth * winCentre) != 0)
                DrawAxesLabels(gr);
            if (paint_histogram)
            {
                DrawHistogram(gr);
            }
            if (!first)
            {
                DrawKnotsArray(gr);
                DrawLine(gr);
            }
            
            e.Graphics.DrawImageUnscaled(bmp, 0, 0);
            gr.Dispose();
        
        }

        private short Transformation(int px)
        {

            double factor = (double)(255 / (double)(winMax - winMin));
            return (short)(((px / factor) + winMin) - 32768);

        }

        private void Test() 
        {
           
            byte ctr;
            Float4 col;

            for (short i = -120; i < 240; i++) 
            {
                ctr = 0;
                while (i > form_this.boundaries[ctr] && ctr < (form_this.knots_counter - 1)) // пока мы не дошли до того цвета, которым закрашен этот воксель и пока мы не дошли до границ окна
                {
                    ctr++;
                }
                col = (Float4)(UIntToColor(form_this.colors[ctr]));
            }
        
        }

        private void presets_TextChanged(object sender, EventArgs e) 
        {
            
            if (presets.Text == "Кости") 
            {
                
                if (form_this != null)
                {
                    for(int i=1; i<6; i++)
                    {
                        switch (i)
                        {
                            case 1: {pp.p.X = 269; pp.p.Y = 270; pp.c =System.Drawing.Color.Black;  break;}
                            case 2: {pp.p.X = 281; pp.p.Y = 251; pp.c =System.Drawing.Color.FromArgb(255,128,64);  break;}
                            case 3: {pp.p.X = 294; pp.p.Y = 239; pp.c =System.Drawing.Color.FromArgb(255,128,0); break;}
                            case 4: {pp.p.X = 314; pp.p.Y = 231; pp.c =System.Drawing.Color.FromArgb(255,0,0); break;}
                            case 5: {pp.p.X = 429; pp.p.Y = 224; pp.c =System.Drawing.Color.FromArgb(255,255,255); break;}

                        }
               
                        if (pp.p.X > marginLeft && pp.p.X < Width - marginRight && pp.p.Y > marginTop && pp.p.Y < Height - marginBottom && CanDraw() && form_this != null)
                        {
                            knots.Add(pp);
                        
                        }
                    }
                    paint_histogram = true;
                    Invalidate();
                }
            }
            if (presets.Text == "Мышцы")
            {
                
            }
        }

        /* применят передаточную функцию к массиву, а потом к изображению */
        private void Apply_Click(object sender, EventArgs e)
        {
            if (form_this != null)
            {
                byte acc = 0;
                form_this.colored_array.Initialize();
                form_this.colors.Initialize();
                form_this.boundaries.Initialize();
                form_this.knots_counter = knots.Count;
                for (int i = 1; i < knots.Count; i++)
                {
                    for (int j = knots[i - 1].p.X - marginLeft - 1; j < knots[i].p.X - marginLeft - 1; j++)
                    {
                        acc++;
                        form_this.colored_array[j] = ColorToUInt(knots[i].c);  // СѓРїР°РєРѕРІРєР° С†РІРµС‚РѕРІ РєРѕРЅС‚СЂРѕР»СЊРЅС‹С… С‚РѕС‡РµРє РІ uint
                        
                    }
                    form_this.colors[i - 1] = ColorToUInt(knots[i].c);
                    UIntToColor(form_this.colors[i - 1]);
                    form_this.boundaries[i - 1] = Transformation(knots[i].p.X - marginLeft - 1); // РёСЃРїРѕР»СЊР·РѕРІР°С‚СЊ РїРѕС‚РѕРј List
                }
                if (acc != 255) // Придаем цвет тем точкам, которые находятся правее передаточной функции, то есть им по каким-либо причинам не был присвоен цвет
                {
                    for (int j = acc; j < 256; j++)
                    {
                        form_this.colored_array[j] = ColorToUInt(knots[knots.Count - 1].c); // упаковка цветов контрольных точек в uint

                    }
                }
                Test();
                form_this.UpdateColorFromHistogram();
            }
            else
                MessageBox.Show("Сначала загрузите DICOM файл");
        }

    }
}

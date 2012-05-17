using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace vme
{
    public partial class Histogram : UserControl
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
        bool first;
        Point pp; // last upd
        List<Point> knots; // массив узловых точек

        Imagebpp iBpp;
        bool signedImage;

        Color c1 = Color.Purple;
        Color c2 = Color.DarkBlue;

        public Histogram()
        {
            InitializeComponent();
            DoubleBuffered = true;
            marginLeft = 25;
            marginRight = 25;
            marginTop = 20;
            marginBottom = 20;
            pp.X = 0;
            pp.Y = 0;

            winWidth = 0;
            winCentre = 0;
            signedImage = false;

            first = true; // last upd
            knots = new List<Point>();
            Point ini = new Point(marginLeft+1,this.Height-marginBottom-1);
            knots.Add(ini);

        }

        public void PassAlong(Main form) 
        {
            form_this = form;
        }

        public void SetParametersHistogram(int minVal, int maxVal, int widthVal, int centreVal,
            Imagebpp bpp, bool sign)
        {
            
            winMin = minVal;
            winMax = maxVal;
            winWidth = widthVal;
            winCentre = centreVal;
            first = false;  // last upd
            iBpp = bpp;
            signedImage = sign;
            Invalidate();
        }

        /* очищает параметры гистограммы: контрольные точки */
        public void ResetValues() 
        {
            knots.Clear();  // очистить все контрольные точки и этого достаточно
            Point ini = new Point(marginLeft + 1, this.Height - marginBottom - 1);
            knots.Add(ini);
            form_this.UpdateFormHitosgram();
            Invalidate();
        }

        /*метод рисует границы и сетку*/
        private void DrawBoundaryAndGrid(Graphics g)
        {
            
            // границы и цвет фона
            Point pt1 = new Point(marginLeft, marginTop);
            Point pt2 = new Point(Width - marginRight, marginTop);
            Point pt3 = new Point(Width - marginRight, Height - marginBottom);
            Point pt4 = new Point(marginLeft, Height - marginBottom);
            Pen p = new Pen(Color.LightGray);
            Brush br = new SolidBrush(Color.LightYellow);

            // задний фон 
            Rectangle rect = new Rectangle(pt1.X, pt1.Y, pt2.X - pt1.X, pt3.Y - pt1.Y);
            g.FillRectangle(br, rect);

            Point pv11, pv21, ph11, ph21;
            pv11 = new Point();
            pv21 = new Point();
            ph11 = new Point();
            ph21 = new Point();

            int iNoVDivisions = 10, iNoHDivisions = 10;
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
            p.Color = Color.Azure;
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
            Brush br = new SolidBrush(Color.Black);
            PointF p = new PointF();
            p.X = marginLeft - 24;
            p.Y = marginTop - 2;
            gr.DrawString("255", f, br, p);

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
            else //16
            {
                if (signedImage == true)
                {
                    strMax = "32767";
                    strMin = "-32768";
                }
                else
                {
                    strMax = "65535";
                    strMin = "0";
                }
            }

            // метки на горизонтальных линиях
            gr.DrawString(strMin, f, br, p);
            p.X = marginLeft + graphWidth - 34;
            gr.DrawString(strMax, f, br, p);
            br.Dispose();

            br = new SolidBrush(Color.RosyBrown);

            p.X = marginLeft + 35;
            p.Y = marginTop + graphHeight + 2;
            gr.DrawString("HU", f, br, p);

            p.X = marginLeft - 20;
            p.Y = marginTop + 25;
            StringFormat sf = new StringFormat(StringFormatFlags.DirectionVertical);
            gr.DrawString("Яркость[bpp] и прозрачность[%]", f, br, p, sf);

            f.Dispose();
            br.Dispose();
        }

        private void Histogram_Paint(object sender, PaintEventArgs e) 
        {   
            
            Bitmap bmp = new Bitmap(this.Width, this.Height);
            Graphics gr = Graphics.FromImage(bmp);
            DrawBoundaryAndGrid(gr);
            if ((winWidth * winCentre) != 0)
                DrawLines(gr);
            if ((winWidth * winCentre) != 0)
                DrawAxesLabels(gr);
            if (!first)
            {
                DrawKnotsArray(gr);
                DrawLine(gr);
            }
            e.Graphics.DrawImageUnscaled(bmp, 0, 0);
            gr.Dispose();
        }

        private void DrawLine(Graphics g) 
        {
            Pen pn = new Pen(Color.Coral);
            if (knots.Count > 1) 
            {
                for (int i = 0; i < knots.Count - 1; i++) 
                    g.DrawLine(pn, knots[i], knots[i + 1]);
            }
            pn.Dispose();
        }

        private void DrawKnotsArray(Graphics g) 
        {
            for (int i = 0; i < knots.Count; i++)
                DrawPoint(g,knots[i]);
        }

        private void DrawPoint(Graphics g, Point j)
        {
            Pen pn = new Pen(Color.Brown);
            g.DrawEllipse(pn, j.X - 3, j.Y - 3, 6, 6);
            pn.Dispose();
        }

        void UpdMainForm() 
        {
            form_this.UpdateFormHitosgram();
        }

        private bool CanDraw() 
        {
            for (int i = 0; i < knots.Count; i++) 
            {
                if (knots[i].X >= pp.X)
                    return false;
            }
            return true;

        }

        private void Histogram_MouseClick(object sender, MouseEventArgs e) 
        {
            pp.X = e.X; // !
            pp.Y = e.Y;
            if (pp.X > marginLeft && pp.X < Width-marginRight && pp.Y > marginTop && pp.Y < Height-marginBottom && CanDraw() && form_this!=null)
            {
                knots.Add(pp);
                UpdMainForm();
                Invalidate();
            }
           
        }
    }
}

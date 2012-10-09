using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using OpenCLNet;

namespace vme
{
    public partial class TransferFunction : Form
    {
        private int marginLeft;
        private int marginRight;
        private int marginTop;
        private int marginBottom;
        private int graphWidth;
        private int graphHeight;

        private int winWidth;
        private int winCentre;
        private int winMin;
        private int winMax;

        private Knot pp;
        private Knot active_point;
        private int active_number;
        private bool is_active_global;
        private Color preactive_color;

        List<Knot> knots; // массив узловых точек
        long[] histogram_255;
        Imagebpp iBpp;

        private bool signedImage;
        private bool first;
        private bool paint_histogram;

        Main form_this; // ?

        public TransferFunction()
        {
            InitializeComponent();
            DoubleBuffered = true;
            marginLeft = 20;
            marginRight = 20;
            marginTop = 20;
            marginBottom = 70;
            pp.p.X = 0;
            pp.p.Y = 0;

            winWidth = 0;
            winCentre = 0;
            signedImage = false;

            paint_histogram = false;
            first = true;
            knots = new List<Knot>();
            pp = new Knot();
            pp.p = new Point(marginLeft + 1, this.Height - marginBottom - 1);
            pp.c = System.Drawing.Color.Black;
            knots.Add(pp);
            active_number = 0;
            is_active_global = false;
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
            /*
            this.active.Text = "Unactive";
            this.cordX.Text = "x: ";
            this.cordY.Text = "y: ";
            this.red.Text = "R ";
            this.green.Text = "G ";
            this.blue.Text = "B ";
            this.alpha.Text = "A ";
            this.opacity.Text = "O ";*/
            form_this.UpdateFromColoredTF();
            Invalidate();
        }

        #region ColorMix

        private uint ColorBytesToUInt(byte b3, byte b2, byte b1, byte b0)
        {
            return (uint)((b3 << 24) + (b2 << 16) + (b1 << 8) + b0);
        }

        private uint ColorToUInt(Color c) // GBRA
        {
            uint gu = c.G, bu = c.B, ru = c.R, au = c.A;
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
            uint two_in_24_max = (1 << 24) - 1; // max 
            ushort two_in_16_max = (1 << 16) - 1; // max 

            if (color > two_in_24_max)
            {
                G = (byte)(color >> 24);
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
                B = (byte)(color >> 16);
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
                R = (byte)(color >> 8);
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
        #endregion

        #region Grid
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

            /*
            //Point pv11, pv21, ph11, ph21;
            pv11 = new Point();
            pv21 = new Point();
            ph11 = new Point();
            ph21 = new Point();*/

            int iNoVDivisions = 8, iNoHDivisions = 8;
            int iVertSpace = Convert.ToInt32((Height - marginTop - marginBottom) / iNoVDivisions);
            int iHorizSpace = Convert.ToInt32((Width - marginLeft - marginRight) / iNoHDivisions);

            /*
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
            }*/

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


        private void DrawLines()
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
            string average = "";

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
                average = Convert.ToString(winCentre + short.MinValue);
            }

            // метки на горизонтальных линиях
            gr.DrawString(strMin, f, br, p);
            p.X = marginLeft + graphWidth - 15;
            gr.DrawString(strMax, f, br, p);
            p.X = (marginLeft + 1 + graphWidth / 2 - 15);
            gr.DrawString(average, f, br, p);
            br.Dispose();

            br = new SolidBrush(System.Drawing.Color.RosyBrown);

            p.X = marginLeft + 35;
            p.Y = marginTop + graphHeight + 2;
            gr.DrawString("HU", f, br, p);

            p.X = marginLeft - 20;
            p.Y = marginTop + 25;
            StringFormat sf = new StringFormat(StringFormatFlags.DirectionVertical);
            gr.DrawString("%", f, br, p, sf);

            f.Dispose();
            br.Dispose();
        }

        #endregion

        /* Отрисовка линий между контрольными точками */
        public void DrawLine(Graphics g)
        {
            Pen pn = new Pen(System.Drawing.Color.Chocolate);
            if (knots.Count > 1)
            {
                for (int i = 0; i < knots.Count - 1; i++)
                    g.DrawLine(pn, knots[i].p, knots[i + 1].p);
            }
            pn.Dispose();
        }

        public void DrawColorInterpolation(Knot p1, Knot p2, Graphics gg)
        {
            byte a, r, g, b;
            float area;
            int overall;
            Pen p;
            SolidBrush br;
            Point put = new Point();
            Point put2 = new Point();
            float j = 0;
            for (int i = p1.p.X; i <= p2.p.X; i++)
            {
                overall = p2.p.X - p1.p.X;
                area = ((j / (float)overall));
                a = (byte)(p1.c.A + (p2.c.A - p1.c.A) * area);
                r = (byte)(p1.c.R + (p2.c.R - p1.c.R) * area);
                g = (byte)(p1.c.G + (p2.c.G - p1.c.G) * area);
                b = (byte)(p1.c.B + (p2.c.B - p1.c.B) * area);
                br = new SolidBrush(System.Drawing.Color.FromArgb(a, r, g, b));
                p = new Pen(br);
                put.X = i;
                put.Y = this.Height - marginBottom;
                put2 = put;
                put2.Y += 20;
                gg.DrawLine(p, put, put2);

                j++;
            }
        }

        /* Отрисовка массива точек */
        public void DrawKnotsArray(Graphics g)
        {
            Knot p1;
            Knot p2;

            for (int i = 0; i < knots.Count; i++)
                DrawPoint(g, knots[i]);

            for (int j = 0; j < knots.Count - 1; j++)
            {
                p1 = knots[j];
                p2 = knots[j + 1];
                DrawColorInterpolation(p1, p2, g);

            }
        }

        /* Отрисовка 1 точки */
        public void DrawPoint(Graphics g, Knot j)
        {
            Pen pn = new Pen(j.c);
            SolidBrush brush = new SolidBrush(j.c);
            pn.DashStyle = DashStyle.DashDot;
            pn.DashStyle = System.Drawing.Drawing2D.DashStyle.Solid;
            g.DrawEllipse(pn, j.p.X - 4, j.p.Y - 4, 8, 8);
            g.FillEllipse(brush, j.p.X - 4, j.p.Y - 4, 8, 8);
            pn.Dispose();
        }

        /*
        public void Apply_Click(object sender, EventArgs e)
        {
            byte a=0, r=0, g=0, b=0;
            float factor;
            float step = 0;
            int overall;
            float delta = (float)(this.Width-marginLeft-marginRight)/(float)(256);
            int resized_dx=0;

            if (form_this != null && !is_active_global)
            {
                form_this.knots_counter = knots.Count;
                EraseArrays();

                                
                for (int i = 0; i < knots.Count-1 ; i++)
                {
                    step = 0;
                    for (int dx = knots[i].p.X; dx < knots[i + 1].p.X; dx++)
                    {
                        resized_dx = dx - (marginLeft + 1); // отн нуля
                        overall = knots[i+1].p.X - knots[i].p.X; // отрезок между соседними точками
                        factor = (float)(step) / (float)(overall); 

                        a = (byte)(knots[i].c.A + (knots[i + 1].c.A - knots[i].c.A) * factor);
                        r = (byte)(knots[i].c.R + (knots[i + 1].c.R - knots[i].c.R) * factor);
                        g = (byte)(knots[i].c.G + (knots[i + 1].c.G - knots[i].c.G) * factor);
                        b = (byte)(knots[i].c.B + (knots[i + 1].c.B - knots[i].c.B) * factor);

                        form_this.colors[resized_dx] = ColorBytesToUInt(g, b, r, a);
                        form_this.opacity[resized_dx] = TransformationPy(knots[i], knots[i + 1], resized_dx);

                        step++;
                    }
                }
                if (resized_dx != 255) // Придаем цвет тем точкам, которые находятся правее передаточной функции, то есть им по каким-либо причинам не был присвоен цвет
                {
                    for (int dx = resized_dx; dx < 256; dx++)
                    {
                        form_this.colors[dx] = ColorBytesToUInt(g, b, r, a);
                        form_this.opacity[dx] = form_this.opacity[resized_dx];
                    }
                }
                form_this.UpdateColorFromHistogram(winWidth, winCentre);
            }
        }*/

        public void UpdMainForm()
        {
            form_this.UpdateFromColoredTF();
        }

        public bool CanDraw()
        {
            for (int i = 0; i < knots.Count; i++)
            {
                if (knots[i].p.X >= pp.p.X)
                    return false;
            }
            return true;
        }

        public void reset_fn_Click(object sender, EventArgs e)
        {
            if (form_this != null)
            {
                ResetValues();
            }
            else
                MessageBox.Show("First Load DICOM file(s)");
        }

        public void Color_Click(object sender, EventArgs e)
        {
            ColorDialog MyDialog = new ColorDialog();
            MyDialog.AllowFullOpen = true;
            MyDialog.ShowHelp = true;
            if (MyDialog.ShowDialog() == DialogResult.OK)
            {
                if (is_active_global)
                {
                    preactive_color = MyDialog.Color;
                    /*
                    this.red.Text = "R " + Convert.ToString(preactive_color.R);
                    this.green.Text = "G " + Convert.ToString(preactive_color.G);
                    this.blue.Text = "B " + Convert.ToString(preactive_color.B);
                    this.alpha.Text = "A " + Convert.ToString(preactive_color.A);*/
                }
                pp.c = MyDialog.Color;
            }
        }

        public bool InKnotArea(int num)
        {
            if (pp.p.X >= (knots[num].p.X - 4) && pp.p.Y >= knots[num].p.Y - 4 && pp.p.X <= knots[num].p.X + 4 && pp.p.Y <= knots[num].p.Y + 4)
                return true;
            else
                return false;
        }

        public bool CheckActivePoint()
        {
            bool shot = false;

            for (int i = 0; i < knots.Count; i++)
            {
                // если мы попали в точку
                if (shot = InKnotArea(i))
                {
                    active_number = i;
                    active_point = knots[i];
                    preactive_color = knots[i].c; // сохраняем старый цвет теперь уже активной точки точки
                    active_point.c = System.Drawing.Color.YellowGreen;
                    return true;
                }
            }
            return false;
        }

        public void CheckCoordsAndPutActivePoint()
        {
            if (knots.Count > 1)
            {
                if (active_number != (knots.Count - 1) && active_number != 0)
                {
                    if ((pp.p.X > knots[active_number - 1].p.X && pp.p.X < knots[active_number + 1].p.X))
                    {
                        active_point.p.X = pp.p.X;
                        active_point.p.Y = pp.p.Y;
                        knots[active_number] = active_point;
                        /*
                        this.cordX.Text = "x: " + Convert.ToString(active_point.p.X);
                        this.cordY.Text = "y: " + Convert.ToString(active_point.p.Y);
                        this.red.Text = "R " + Convert.ToString(active_point.c.R);
                        this.green.Text = "G " + Convert.ToString(active_point.c.G);
                        this.blue.Text = "B " + Convert.ToString(active_point.c.B);
                        this.alpha.Text = "A " + Convert.ToString(active_point.c.A);
                        this.opacity.Text = "O ";*/
                    }

                }
                else
                // если это первая либо последняя точка
                {
                    if (active_number == 0)
                    {
                        if (pp.p.X == marginLeft + 1)
                        {
                            active_point.p.X = pp.p.X;
                            active_point.p.Y = pp.p.Y;
                            knots[active_number] = active_point;
                        }
                    }

                    if (active_number == knots.Count - 1)
                    {
                        if ((pp.p.X > knots[active_number - 1].p.X && pp.p.X < this.Width - marginRight - 1))
                        {
                            active_point.p.X = pp.p.X;
                            active_point.p.Y = pp.p.Y;
                            knots[active_number] = active_point;
                        }
                    }
                    /*
                    this.cordX.Text = "x: " + Convert.ToString(active_point.p.X);
                    this.cordY.Text = "y: " + Convert.ToString(active_point.p.Y);
                    this.red.Text = "R " + Convert.ToString(active_point.c.R);
                    this.green.Text = "G " + Convert.ToString(active_point.c.G);
                    this.blue.Text = "B " + Convert.ToString(active_point.c.B);
                    this.alpha.Text = "A " + Convert.ToString(active_point.c.A);
                    this.opacity.Text = "O ";*/
                }

            }
        }

        public void TF_MouseClick(object sender, MouseEventArgs e)
        {
            if (form_this != null)
            {
                bool is_active = false;
                pp.p.X = e.X;
                pp.p.Y = e.Y;

                if (e.Button == MouseButtons.Left)
                {
                    if (pp.p.X > marginLeft && pp.p.X < Width - marginRight && pp.p.Y > marginTop && pp.p.Y < Height - marginBottom && form_this != null)
                    {
                        if (!is_active_global && (is_active = CheckActivePoint())) // проверяем на активную точку
                        {
                            knots[active_number] = active_point;
                            is_active_global = true;
                            /*
                            this.active.Text = "Active";
                            this.cordX.Text = "x: " + Convert.ToString(active_point.p.X);
                            this.cordY.Text = "y: " + Convert.ToString(active_point.p.Y);
                            this.red.Text = "R " + Convert.ToString(preactive_color.R);
                            this.green.Text = "G " + Convert.ToString(preactive_color.G);
                            this.blue.Text = "B " + Convert.ToString(preactive_color.B);
                            this.alpha.Text = "A " + Convert.ToString(preactive_color.A);
                            this.opacity.Text = "O ";*/
                        }
                        else
                        {
                            // если мы не выбрали точку для редактирования, тогда просто добавляем новую 
                            if (CanDraw() && !is_active_global)
                            {
                                knots.Add(pp);
                            }
                            if (is_active_global)
                            {
                                CheckCoordsAndPutActivePoint();
                            }
                        }
                        paint_histogram = true;
                        Invalidate();
                    }
                }
                if (e.Button == MouseButtons.Right)
                {
                    if (is_active_global)
                    {
                        is_active_global = false;
                        active_point.c = preactive_color;
                        knots[active_number] = active_point;
                        active_point.c = System.Drawing.Color.YellowGreen;
                        /*
                        this.active.Text = "Unactive";
                        this.cordX.Text = "x: ";
                        this.cordY.Text = "y: ";
                        this.red.Text = "R ";
                        this.green.Text = "G ";
                        this.blue.Text = "B ";
                        this.alpha.Text = "A ";
                        this.opacity.Text = "O ";*/
                        paint_histogram = true;
                        Invalidate();
                    }
                }

            }
        }

        /* Строит гистограмму для текущего *окна* изображения  */
        public void DrawHistogram(Graphics g)
        {
            float koeffy;
            float perc;
            int pos = marginLeft + 1;
            int py = 0;  // то что надо отрисовать на оси y в форме

            koeffy = ((float)100.0 / (float)(this.Height - marginTop - marginBottom - 1));

            for (int i = 0; i < 256; i++)
            {

                if (histogram_255[i] > 0)
                {

                    perc = (float)((100 * (Math.Log10(histogram_255[i]))) / ((float)(Math.Log10(form_this.ImageWidth * form_this.ImageHeight))));
                    py = (int)(perc / koeffy);

                    Pen pn = new Pen(System.Drawing.Color.LightGray);
                    Point p1 = new Point(pos, this.Height - marginBottom - 1);
                    Point p2 = new Point(pos, this.Height - marginBottom - 1 - py);
                    g.DrawLine(pn, p1, p2);
                }
                pos++;


            }
            //paint_histogram = false;
        }

        public void TF_Paint(object sender, PaintEventArgs e)
        {
            Bitmap bmp = new Bitmap(this.Width, this.Height);
            Graphics gr = Graphics.FromImage(bmp);
            DrawBoundaryAndGrid(gr);
            
            if ((winWidth * winCentre) != 0)
                DrawLines();
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

        public short TransformationPx(int px)
        {

            double factor = (double)(255 / (double)(winMax - winMin));
            return (short)(((px / factor) + winMin) - 32768);
        }

        public float TransformationPy(Knot k1, Knot k2, int dx)
        {
            float x, x0, x1;
            float y, y0, y1;
            x = dx;
            x0 = k1.p.X - (marginLeft + 1);
            x1 = k2.p.X - (marginLeft + 1);
            y0 = Math.Abs(this.Height - (marginBottom - 1) - k1.p.Y);
            y1 = Math.Abs(this.Height - (marginBottom - 1) - k2.p.Y);

            y = (int)((float)(((dx - x0) * (y1 - y0)) / (float)(x1 - x0)) + y0);
            return ((float)y / (float)(this.Height - marginTop - marginBottom));

        }

        public void presets_TextChanged(object sender, EventArgs e)
        {
            if (form_this != null)
            {
                knots.Clear();
                pp = new Knot();
                pp.p = new Point(marginLeft + 1, this.Height - marginBottom - 1);
                pp.c = System.Drawing.Color.Black;
                knots.Add(pp);
                /*
                if (presets.Text == "Bones 1")
                {

                    for (int i = 1; i < 6; i++)
                    {
                        switch (i)
                        {
                            case 1: { pp.p.X = 269; pp.p.Y = 270; pp.c = System.Drawing.Color.Black; break; }
                            case 2: { pp.p.X = 281; pp.p.Y = 251; pp.c = System.Drawing.Color.FromArgb(255, 128, 64); break; }
                            case 3: { pp.p.X = 294; pp.p.Y = 239; pp.c = System.Drawing.Color.FromArgb(255, 128, 0); break; }
                            case 4: { pp.p.X = 314; pp.p.Y = 231; pp.c = System.Drawing.Color.FromArgb(255, 0, 0); break; }
                            case 5: { pp.p.X = 429; pp.p.Y = 224; pp.c = System.Drawing.Color.FromArgb(255, 255, 255); break; }

                        }

                        if (pp.p.X > marginLeft && pp.p.X < Width - marginRight && pp.p.Y > marginTop && pp.p.Y < Height - marginBottom && CanDraw() && form_this != null)
                        {
                            knots.Add(pp);

                        }
                    }
                }
                if (presets.Text == "Bones 2")
                {
                    for (int i = 1; i < 13; i++)
                    {
                        switch (i)
                        {
                            case 1: { pp.p.X = 188; pp.p.Y = 227; pp.c = System.Drawing.Color.FromArgb(64, 0, 0); ; break; }
                            case 2: { pp.p.X = 196; pp.p.Y = 201; pp.c = System.Drawing.Color.FromArgb(253, 201, 166); break; }
                            case 3: { pp.p.X = 226; pp.p.Y = 187; pp.c = System.Drawing.Color.FromArgb(251, 191, 125); break; }
                            case 4: { pp.p.X = 265; pp.p.Y = 169; pp.c = System.Drawing.Color.FromArgb(255, 0, 0); break; }
                            case 5: { pp.p.X = 280; pp.p.Y = 155; pp.c = System.Drawing.Color.FromArgb(255, 128, 125); break; }
                            case 6: { pp.p.X = 292; pp.p.Y = 147; pp.c = System.Drawing.Color.FromArgb(255, 255, 0); break; }
                            case 7: { pp.p.X = 309; pp.p.Y = 172; pp.c = System.Drawing.Color.FromArgb(255, 128, 0); break; }
                            case 8: { pp.p.X = 317; pp.p.Y = 197; pp.c = System.Drawing.Color.FromArgb(248, 189, 124); break; }
                            case 9: { pp.p.X = 333; pp.p.Y = 223; pp.c = System.Drawing.Color.FromArgb(255, 128, 64); break; }
                            case 10: { pp.p.X = 375; pp.p.Y = 242; pp.c = System.Drawing.Color.FromArgb(0, 128, 255); break; }
                            case 11: { pp.p.X = 408; pp.p.Y = 236; pp.c = System.Drawing.Color.FromArgb(0, 128, 192); break; }
                            case 12: { pp.p.X = 428; pp.p.Y = 225; pp.c = System.Drawing.Color.FromArgb(255, 255, 255); break; }
                        }

                        if (pp.p.X > marginLeft && pp.p.X < Width - marginRight && pp.p.Y > marginTop && pp.p.Y < Height - marginBottom && CanDraw() && form_this != null)
                        {
                            knots.Add(pp);
                        }
                    }
                }
                 * */
                paint_histogram = true;
                Invalidate();
            }
        }

        public void EraseArrays()
        {
            for (int i = 0; i < form_this.colors.Count(); i++)
                form_this.colors[i] = 0;
            for (int i = 0; i < form_this.opacity.Count(); i++)
                form_this.opacity[i] = 0;
        }

        /* применят передаточную функцию к массиву, а потом к изображению */
        public void Apply_Click(object sender, EventArgs e)
        {
            byte a = 0, r = 0, g = 0, b = 0;
            float factor;
            float step = 0;
            int overall;
            float delta = (float)(this.Width - marginLeft - marginRight) / (float)(256);
            int resized_dx = 0;

            if (form_this != null && !is_active_global)
            {
                form_this.KnotsCounter = knots.Count; // я его залочила, оно приватное
                EraseArrays();

                for (int i = 0; i < knots.Count - 1; i++)
                {
                    step = 0;
                    for (int dx = knots[i].p.X; dx < knots[i + 1].p.X; dx++)
                    {
                        resized_dx = dx - (marginLeft + 1); // отн нуля
                        overall = knots[i + 1].p.X - knots[i].p.X; // отрезок между соседними точками
                        factor = (float)(step) / (float)(overall);

                        a = (byte)(knots[i].c.A + (knots[i + 1].c.A - knots[i].c.A) * factor);
                        r = (byte)(knots[i].c.R + (knots[i + 1].c.R - knots[i].c.R) * factor);
                        g = (byte)(knots[i].c.G + (knots[i + 1].c.G - knots[i].c.G) * factor);
                        b = (byte)(knots[i].c.B + (knots[i + 1].c.B - knots[i].c.B) * factor);

                        form_this.colors[resized_dx] = ColorBytesToUInt(g, b, r, a);
                        form_this.opacity[resized_dx] = TransformationPy(knots[i], knots[i + 1], resized_dx);

                        step++;
                    }
                }
                if (resized_dx != 255) // Придаем цвет тем точкам, которые находятся правее передаточной функции, то есть им по каким-либо причинам не был присвоен цвет
                {
                    for (int dx = resized_dx; dx < 256; dx++)
                    {
                        form_this.colors[dx] = ColorBytesToUInt(g, b, r, a);
                        form_this.opacity[dx] = form_this.opacity[resized_dx];
                    }
                }
                form_this.UpdateColorFromHistogram(winWidth, winCentre);
            }
        }

    }
}

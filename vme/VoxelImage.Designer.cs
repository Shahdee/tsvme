namespace vme
{
    partial class VoxelImage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.VSurface = new vme.VoxelImage.DrawPanel();
            this.left = new System.Windows.Forms.Button();
            this.right = new System.Windows.Forms.Button();
            this.up = new System.Windows.Forms.Button();
            this.down = new System.Windows.Forms.Button();
            this.colorMi = new System.Windows.Forms.TextBox();
            this.colorMa = new System.Windows.Forms.TextBox();
            this._trilinear = new System.Windows.Forms.CheckBox();
            this.tf = new System.Windows.Forms.CheckBox();
            this._cutArrea = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.labelx = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.colorMa2 = new System.Windows.Forms.TextBox();
            this.colorMi2 = new System.Windows.Forms.TextBox();
            this.maxX = new System.Windows.Forms.TextBox();
            this.minY = new System.Windows.Forms.TextBox();
            this.minZ = new System.Windows.Forms.TextBox();
            this.minX = new System.Windows.Forms.TextBox();
            this.maxY = new System.Windows.Forms.TextBox();
            this.maxZ = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.kamb = new System.Windows.Forms.ComboBox();
            this.kdiff = new System.Windows.Forms.ComboBox();
            this.kspec = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.trackminX = new System.Windows.Forms.TrackBar();
            this.trackminY = new System.Windows.Forms.TrackBar();
            this.trackminZ = new System.Windows.Forms.TrackBar();
            this.trackmaxZ = new System.Windows.Forms.TrackBar();
            this.trackmaxY = new System.Windows.Forms.TrackBar();
            this.trackmaxX = new System.Windows.Forms.TrackBar();
            this.specexp = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.rotation = new System.Windows.Forms.Label();
            this.tracklx = new System.Windows.Forms.TrackBar();
            this.ly = new System.Windows.Forms.TextBox();
            this.lz = new System.Windows.Forms.TextBox();
            this.lx = new System.Windows.Forms.TextBox();
            this.trackly = new System.Windows.Forms.TrackBar();
            this.tracklz = new System.Windows.Forms.TrackBar();
            this.fps = new System.Windows.Forms.Label();
            this.kc = new System.Windows.Forms.ComboBox();
            this.kl = new System.Windows.Forms.ComboBox();
            this.kq = new System.Windows.Forms.ComboBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.voxelCounter = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackminX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackminY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackminZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackmaxZ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackmaxY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackmaxX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tracklx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackly)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tracklz)).BeginInit();
            this.SuspendLayout();
            // 
            // VSurface
            // 
            this.VSurface.Location = new System.Drawing.Point(12, 12);
            this.VSurface.Name = "VSurface";
            this.VSurface.Size = new System.Drawing.Size(512, 512);
            this.VSurface.TabIndex = 0;
            this.VSurface.Click += new System.EventHandler(this.VSurface_Click);
            this.VSurface.Paint += new System.Windows.Forms.PaintEventHandler(this.VSurface_Paint);
            this.VSurface.MouseMove += new System.Windows.Forms.MouseEventHandler(this.VSurface_MouseMove);
            this.VSurface.MouseWheel += new System.Windows.Forms.MouseEventHandler(this.VSurface_MouseWheel);
            // 
            // left
            // 
            this.left.Location = new System.Drawing.Point(751, 89);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(41, 23);
            this.left.TabIndex = 1;
            this.left.Text = "L";
            this.left.UseVisualStyleBackColor = true;
            this.left.Click += new System.EventHandler(this.left_Click);
            // 
            // right
            // 
            this.right.Location = new System.Drawing.Point(808, 89);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(46, 23);
            this.right.TabIndex = 2;
            this.right.Text = "R";
            this.right.UseVisualStyleBackColor = true;
            this.right.Click += new System.EventHandler(this.right_Click);
            // 
            // up
            // 
            this.up.Location = new System.Drawing.Point(784, 60);
            this.up.Name = "up";
            this.up.Size = new System.Drawing.Size(38, 23);
            this.up.TabIndex = 3;
            this.up.Text = "+";
            this.up.UseVisualStyleBackColor = true;
            this.up.Click += new System.EventHandler(this.up_Click);
            // 
            // down
            // 
            this.down.Location = new System.Drawing.Point(784, 118);
            this.down.Name = "down";
            this.down.Size = new System.Drawing.Size(36, 23);
            this.down.TabIndex = 4;
            this.down.Text = "-";
            this.down.UseVisualStyleBackColor = true;
            this.down.Click += new System.EventHandler(this.down_Click);
            // 
            // colorMi
            // 
            this.colorMi.Location = new System.Drawing.Point(543, 116);
            this.colorMi.Name = "colorMi";
            this.colorMi.Size = new System.Drawing.Size(47, 20);
            this.colorMi.TabIndex = 6;
            this.colorMi.Text = "0";
            // 
            // colorMa
            // 
            this.colorMa.Location = new System.Drawing.Point(596, 116);
            this.colorMa.Name = "colorMa";
            this.colorMa.Size = new System.Drawing.Size(47, 20);
            this.colorMa.TabIndex = 7;
            this.colorMa.Text = "0";
            // 
            // _trilinear
            // 
            this._trilinear.AutoSize = true;
            this._trilinear.Location = new System.Drawing.Point(543, 22);
            this._trilinear.Name = "_trilinear";
            this._trilinear.Size = new System.Drawing.Size(116, 17);
            this._trilinear.TabIndex = 8;
            this._trilinear.Text = "Трилинейная инт.";
            this._trilinear.UseVisualStyleBackColor = true;
            // 
            // tf
            // 
            this.tf.AutoSize = true;
            this.tf.Location = new System.Drawing.Point(543, 53);
            this.tf.Name = "tf";
            this.tf.Size = new System.Drawing.Size(112, 17);
            this.tf.TabIndex = 9;
            this.tf.Text = "Передаточная ф.";
            this.tf.UseVisualStyleBackColor = true;
            this.tf.CheckedChanged += new System.EventHandler(this.tf_CheckedChanged);
            // 
            // _cutArrea
            // 
            this._cutArrea.AutoSize = true;
            this._cutArrea.Location = new System.Drawing.Point(544, 90);
            this._cutArrea.Name = "_cutArrea";
            this._cutArrea.Size = new System.Drawing.Size(89, 17);
            this._cutArrea.TabIndex = 5;
            this._cutArrea.Text = "Отсечь окно";
            this._cutArrea.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(705, 319);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Свет";
            // 
            // labelx
            // 
            this.labelx.AutoSize = true;
            this.labelx.Location = new System.Drawing.Point(530, 352);
            this.labelx.Name = "labelx";
            this.labelx.Size = new System.Drawing.Size(14, 13);
            this.labelx.TabIndex = 23;
            this.labelx.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(530, 379);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(530, 405);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Z";
            // 
            // colorMa2
            // 
            this.colorMa2.Location = new System.Drawing.Point(596, 142);
            this.colorMa2.Name = "colorMa2";
            this.colorMa2.Size = new System.Drawing.Size(47, 20);
            this.colorMa2.TabIndex = 27;
            this.colorMa2.Text = "0";
            // 
            // colorMi2
            // 
            this.colorMi2.Location = new System.Drawing.Point(543, 142);
            this.colorMi2.Name = "colorMi2";
            this.colorMi2.Size = new System.Drawing.Size(47, 20);
            this.colorMi2.TabIndex = 26;
            this.colorMi2.Text = "0";
            // 
            // maxX
            // 
            this.maxX.Location = new System.Drawing.Point(835, 219);
            this.maxX.Name = "maxX";
            this.maxX.ReadOnly = true;
            this.maxX.Size = new System.Drawing.Size(47, 20);
            this.maxX.TabIndex = 31;
            this.maxX.Text = "0";
            // 
            // minY
            // 
            this.minY.Location = new System.Drawing.Point(648, 245);
            this.minY.Name = "minY";
            this.minY.ReadOnly = true;
            this.minY.Size = new System.Drawing.Size(47, 20);
            this.minY.TabIndex = 30;
            this.minY.Text = "0";
            // 
            // minZ
            // 
            this.minZ.Location = new System.Drawing.Point(648, 271);
            this.minZ.Name = "minZ";
            this.minZ.ReadOnly = true;
            this.minZ.Size = new System.Drawing.Size(47, 20);
            this.minZ.TabIndex = 29;
            this.minZ.Text = "0";
            // 
            // minX
            // 
            this.minX.Location = new System.Drawing.Point(648, 219);
            this.minX.Name = "minX";
            this.minX.ReadOnly = true;
            this.minX.Size = new System.Drawing.Size(47, 20);
            this.minX.TabIndex = 28;
            this.minX.Text = "0";
            // 
            // maxY
            // 
            this.maxY.Location = new System.Drawing.Point(835, 245);
            this.maxY.Name = "maxY";
            this.maxY.ReadOnly = true;
            this.maxY.Size = new System.Drawing.Size(47, 20);
            this.maxY.TabIndex = 32;
            this.maxY.Text = "0";
            // 
            // maxZ
            // 
            this.maxZ.Location = new System.Drawing.Point(835, 271);
            this.maxZ.Name = "maxZ";
            this.maxZ.ReadOnly = true;
            this.maxZ.Size = new System.Drawing.Size(47, 20);
            this.maxZ.TabIndex = 33;
            this.maxZ.Text = "0";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(704, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Бокс";
            // 
            // kamb
            // 
            this.kamb.FormattingEnabled = true;
            this.kamb.Items.AddRange(new object[] {
            "0,0",
            "0,1",
            "0,2",
            "0,3",
            "0,4",
            "0,5",
            "0,6",
            "0,7",
            "0,8",
            "0,9",
            "1,0"});
            this.kamb.Location = new System.Drawing.Point(781, 344);
            this.kamb.Name = "kamb";
            this.kamb.Size = new System.Drawing.Size(48, 21);
            this.kamb.TabIndex = 35;
            // 
            // kdiff
            // 
            this.kdiff.FormattingEnabled = true;
            this.kdiff.Items.AddRange(new object[] {
            "0,0",
            "0,1",
            "0,2",
            "0,3",
            "0,4",
            "0,5",
            "0,6",
            "0,7",
            "0,8",
            "0,9",
            "1,0"});
            this.kdiff.Location = new System.Drawing.Point(781, 373);
            this.kdiff.Name = "kdiff";
            this.kdiff.Size = new System.Drawing.Size(48, 21);
            this.kdiff.TabIndex = 36;
            // 
            // kspec
            // 
            this.kspec.FormattingEnabled = true;
            this.kspec.Items.AddRange(new object[] {
            "0,0",
            "0,1",
            "0,2",
            "0,3",
            "0,4",
            "0,5",
            "0,6",
            "0,7",
            "0,8",
            "0,9",
            "1,0"});
            this.kspec.Location = new System.Drawing.Point(782, 406);
            this.kspec.Name = "kspec";
            this.kspec.Size = new System.Drawing.Size(48, 21);
            this.kspec.TabIndex = 37;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(731, 347);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(50, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "K общий";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(731, 377);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "K расс.";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(731, 409);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 13);
            this.label7.TabIndex = 40;
            this.label7.Text = "K зерк.";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(532, 272);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(14, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "Z";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(532, 246);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(14, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "Y";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(532, 219);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 13);
            this.label10.TabIndex = 41;
            this.label10.Text = "X";
            // 
            // trackminX
            // 
            this.trackminX.Location = new System.Drawing.Point(548, 213);
            this.trackminX.Name = "trackminX";
            this.trackminX.Size = new System.Drawing.Size(84, 45);
            this.trackminX.TabIndex = 44;
            this.trackminX.Scroll += new System.EventHandler(this.trackminX_Scroll);
            // 
            // trackminY
            // 
            this.trackminY.Location = new System.Drawing.Point(548, 243);
            this.trackminY.Name = "trackminY";
            this.trackminY.Size = new System.Drawing.Size(84, 45);
            this.trackminY.TabIndex = 45;
            this.trackminY.Scroll += new System.EventHandler(this.trackminY_Scroll);
            // 
            // trackminZ
            // 
            this.trackminZ.Location = new System.Drawing.Point(548, 271);
            this.trackminZ.Name = "trackminZ";
            this.trackminZ.Size = new System.Drawing.Size(84, 45);
            this.trackminZ.TabIndex = 46;
            this.trackminZ.Scroll += new System.EventHandler(this.trackminZ_Scroll);
            // 
            // trackmaxZ
            // 
            this.trackmaxZ.Location = new System.Drawing.Point(740, 271);
            this.trackmaxZ.Name = "trackmaxZ";
            this.trackmaxZ.Size = new System.Drawing.Size(89, 45);
            this.trackmaxZ.TabIndex = 49;
            this.trackmaxZ.Scroll += new System.EventHandler(this.trackmaxZ_Scroll);
            // 
            // trackmaxY
            // 
            this.trackmaxY.Location = new System.Drawing.Point(740, 243);
            this.trackmaxY.Name = "trackmaxY";
            this.trackmaxY.Size = new System.Drawing.Size(89, 45);
            this.trackmaxY.TabIndex = 48;
            this.trackmaxY.Scroll += new System.EventHandler(this.trackmaxY_Scroll);
            // 
            // trackmaxX
            // 
            this.trackmaxX.Location = new System.Drawing.Point(740, 213);
            this.trackmaxX.Name = "trackmaxX";
            this.trackmaxX.Size = new System.Drawing.Size(89, 45);
            this.trackmaxX.TabIndex = 47;
            this.trackmaxX.Scroll += new System.EventHandler(this.trackmaxX_Scroll);
            // 
            // specexp
            // 
            this.specexp.FormattingEnabled = true;
            this.specexp.Items.AddRange(new object[] {
            "1,0",
            "2,0",
            "10,0",
            "20,0",
            "30,0",
            "40,0",
            "50,0",
            "60,0",
            "70,0",
            "80,0",
            "90,0",
            "100,0"});
            this.specexp.Location = new System.Drawing.Point(783, 445);
            this.specexp.Name = "specexp";
            this.specexp.Size = new System.Drawing.Size(48, 21);
            this.specexp.TabIndex = 50;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(729, 436);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 51;
            this.label11.Text = "Ст. зерк.";
            // 
            // rotation
            // 
            this.rotation.AutoSize = true;
            this.rotation.Location = new System.Drawing.Point(761, 26);
            this.rotation.Name = "rotation";
            this.rotation.Size = new System.Drawing.Size(80, 13);
            this.rotation.TabIndex = 52;
            this.rotation.Text = "Перемещение";
            // 
            // tracklx
            // 
            this.tracklx.Location = new System.Drawing.Point(566, 343);
            this.tracklx.Name = "tracklx";
            this.tracklx.Size = new System.Drawing.Size(84, 45);
            this.tracklx.TabIndex = 53;
            this.tracklx.Scroll += new System.EventHandler(this.tracklx_Scroll);
            // 
            // ly
            // 
            this.ly.Location = new System.Drawing.Point(659, 375);
            this.ly.Name = "ly";
            this.ly.ReadOnly = true;
            this.ly.Size = new System.Drawing.Size(47, 20);
            this.ly.TabIndex = 56;
            this.ly.Text = "0";
            // 
            // lz
            // 
            this.lz.Location = new System.Drawing.Point(659, 401);
            this.lz.Name = "lz";
            this.lz.ReadOnly = true;
            this.lz.Size = new System.Drawing.Size(47, 20);
            this.lz.TabIndex = 55;
            this.lz.Text = "0";
            // 
            // lx
            // 
            this.lx.Location = new System.Drawing.Point(659, 349);
            this.lx.Name = "lx";
            this.lx.ReadOnly = true;
            this.lx.Size = new System.Drawing.Size(47, 20);
            this.lx.TabIndex = 54;
            this.lx.Text = "0";
            // 
            // trackly
            // 
            this.trackly.Location = new System.Drawing.Point(566, 372);
            this.trackly.Name = "trackly";
            this.trackly.Size = new System.Drawing.Size(84, 45);
            this.trackly.TabIndex = 57;
            this.trackly.Scroll += new System.EventHandler(this.trackly_Scroll);
            // 
            // tracklz
            // 
            this.tracklz.Location = new System.Drawing.Point(566, 401);
            this.tracklz.Name = "tracklz";
            this.tracklz.Size = new System.Drawing.Size(84, 45);
            this.tracklz.TabIndex = 58;
            this.tracklz.Scroll += new System.EventHandler(this.tracklz_Scroll);
            // 
            // fps
            // 
            this.fps.AutoSize = true;
            this.fps.Location = new System.Drawing.Point(557, 470);
            this.fps.Name = "fps";
            this.fps.Size = new System.Drawing.Size(33, 13);
            this.fps.TabIndex = 59;
            this.fps.Text = "FPS: ";
            // 
            // kc
            // 
            this.kc.FormattingEnabled = true;
            this.kc.Items.AddRange(new object[] {
            "0,0",
            "0,1",
            "0,2",
            "0,3",
            "0,4",
            "0,5",
            "0,6",
            "0,7",
            "0,8",
            "0,9",
            "1,0"});
            this.kc.Location = new System.Drawing.Point(860, 348);
            this.kc.Name = "kc";
            this.kc.Size = new System.Drawing.Size(38, 21);
            this.kc.TabIndex = 60;
            // 
            // kl
            // 
            this.kl.FormattingEnabled = true;
            this.kl.Items.AddRange(new object[] {
            "0,0",
            "0,1",
            "0,2",
            "0,3",
            "0,4",
            "0,5",
            "0,6",
            "0,7",
            "0,8",
            "0,9",
            "1,0"});
            this.kl.Location = new System.Drawing.Point(860, 398);
            this.kl.Name = "kl";
            this.kl.Size = new System.Drawing.Size(38, 21);
            this.kl.TabIndex = 61;
            // 
            // kq
            // 
            this.kq.FormattingEnabled = true;
            this.kq.Items.AddRange(new object[] {
            "0,0",
            "0,1",
            "0,2",
            "0,3",
            "0,4",
            "0,5",
            "0,6",
            "0,7",
            "0,8",
            "0,9",
            "1,0"});
            this.kq.Location = new System.Drawing.Point(860, 450);
            this.kq.Name = "kq";
            this.kq.Size = new System.Drawing.Size(38, 21);
            this.kq.TabIndex = 62;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(870, 325);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(20, 13);
            this.label12.TabIndex = 63;
            this.label12.Text = "Kc";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(871, 378);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(16, 13);
            this.label13.TabIndex = 64;
            this.label13.Text = "Kl";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(871, 432);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(20, 13);
            this.label14.TabIndex = 65;
            this.label14.Text = "Kq";
            // 
            // voxelCounter
            // 
            this.voxelCounter.AutoSize = true;
            this.voxelCounter.Location = new System.Drawing.Point(557, 495);
            this.voxelCounter.Name = "voxelCounter";
            this.voxelCounter.Size = new System.Drawing.Size(162, 13);
            this.voxelCounter.TabIndex = 66;
            this.voxelCounter.Text = "Количество вокселей в сцене:";
            // 
            // VoxelImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(920, 540);
            this.Controls.Add(this.voxelCounter);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.kq);
            this.Controls.Add(this.kl);
            this.Controls.Add(this.kc);
            this.Controls.Add(this.fps);
            this.Controls.Add(this.tracklz);
            this.Controls.Add(this.trackly);
            this.Controls.Add(this.ly);
            this.Controls.Add(this.lz);
            this.Controls.Add(this.lx);
            this.Controls.Add(this.tracklx);
            this.Controls.Add(this.rotation);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.specexp);
            this.Controls.Add(this.trackmaxZ);
            this.Controls.Add(this.trackmaxY);
            this.Controls.Add(this.trackmaxX);
            this.Controls.Add(this.trackminZ);
            this.Controls.Add(this.trackminY);
            this.Controls.Add(this.trackminX);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.kspec);
            this.Controls.Add(this.kdiff);
            this.Controls.Add(this.kamb);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.maxZ);
            this.Controls.Add(this.maxY);
            this.Controls.Add(this.maxX);
            this.Controls.Add(this.minY);
            this.Controls.Add(this.minZ);
            this.Controls.Add(this.minX);
            this.Controls.Add(this.colorMa2);
            this.Controls.Add(this.colorMi2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelx);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tf);
            this.Controls.Add(this._trilinear);
            this.Controls.Add(this.colorMa);
            this.Controls.Add(this.colorMi);
            this.Controls.Add(this._cutArrea);
            this.Controls.Add(this.down);
            this.Controls.Add(this.up);
            this.Controls.Add(this.right);
            this.Controls.Add(this.left);
            this.Controls.Add(this.VSurface);
            this.Name = "VoxelImage";
            this.Text = "VoxelImage";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.VoxelImage_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.trackminX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackminY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackminZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackmaxZ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackmaxY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackmaxX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tracklx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackly)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tracklz)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button left;
        private System.Windows.Forms.Button right;
        private System.Windows.Forms.Button up;
        private System.Windows.Forms.Button down;
        public VoxelImage.DrawPanel VSurface;
        private System.Windows.Forms.TextBox colorMi;
        private System.Windows.Forms.TextBox colorMa;
        private System.Windows.Forms.CheckBox _trilinear;
        private System.Windows.Forms.CheckBox tf;
        private System.Windows.Forms.CheckBox _cutArrea;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelx;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox colorMa2;
        private System.Windows.Forms.TextBox colorMi2;
        private System.Windows.Forms.TextBox maxX;
        private System.Windows.Forms.TextBox minY;
        private System.Windows.Forms.TextBox minZ;
        private System.Windows.Forms.TextBox minX;
        private System.Windows.Forms.TextBox maxY;
        private System.Windows.Forms.TextBox maxZ;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox kamb;
        private System.Windows.Forms.ComboBox kdiff;
        private System.Windows.Forms.ComboBox kspec;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TrackBar trackminX;
        private System.Windows.Forms.TrackBar trackminY;
        private System.Windows.Forms.TrackBar trackminZ;
        private System.Windows.Forms.TrackBar trackmaxZ;
        private System.Windows.Forms.TrackBar trackmaxY;
        private System.Windows.Forms.TrackBar trackmaxX;
        private System.Windows.Forms.ComboBox specexp;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label rotation;
        private System.Windows.Forms.TrackBar tracklx;
        private System.Windows.Forms.TextBox ly;
        private System.Windows.Forms.TextBox lz;
        private System.Windows.Forms.TextBox lx;
        private System.Windows.Forms.TrackBar trackly;
        private System.Windows.Forms.TrackBar tracklz;
        private System.Windows.Forms.Label fps;
        private System.Windows.Forms.ComboBox kc;
        private System.Windows.Forms.ComboBox kl;
        private System.Windows.Forms.ComboBox kq;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label voxelCounter;

    }
}
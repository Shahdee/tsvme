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
            this.lx = new System.Windows.Forms.ComboBox();
            this.ly = new System.Windows.Forms.ComboBox();
            this.lz = new System.Windows.Forms.ComboBox();
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
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
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
            this.left.Location = new System.Drawing.Point(593, 265);
            this.left.Name = "left";
            this.left.Size = new System.Drawing.Size(41, 23);
            this.left.TabIndex = 1;
            this.left.Text = "L";
            this.left.UseVisualStyleBackColor = true;
            this.left.Click += new System.EventHandler(this.left_Click);
            // 
            // right
            // 
            this.right.Location = new System.Drawing.Point(650, 265);
            this.right.Name = "right";
            this.right.Size = new System.Drawing.Size(46, 23);
            this.right.TabIndex = 2;
            this.right.Text = "R";
            this.right.UseVisualStyleBackColor = true;
            this.right.Click += new System.EventHandler(this.right_Click);
            // 
            // up
            // 
            this.up.Location = new System.Drawing.Point(626, 236);
            this.up.Name = "up";
            this.up.Size = new System.Drawing.Size(38, 23);
            this.up.TabIndex = 3;
            this.up.Text = "+";
            this.up.UseVisualStyleBackColor = true;
            this.up.Click += new System.EventHandler(this.up_Click);
            // 
            // down
            // 
            this.down.Location = new System.Drawing.Point(626, 294);
            this.down.Name = "down";
            this.down.Size = new System.Drawing.Size(36, 23);
            this.down.TabIndex = 4;
            this.down.Text = "-";
            this.down.UseVisualStyleBackColor = true;
            this.down.Click += new System.EventHandler(this.down_Click);
            // 
            // colorMi
            // 
            this.colorMi.Location = new System.Drawing.Point(561, 165);
            this.colorMi.Name = "colorMi";
            this.colorMi.Size = new System.Drawing.Size(47, 20);
            this.colorMi.TabIndex = 6;
            this.colorMi.Text = "0";
            // 
            // colorMa
            // 
            this.colorMa.Location = new System.Drawing.Point(614, 165);
            this.colorMa.Name = "colorMa";
            this.colorMa.Size = new System.Drawing.Size(47, 20);
            this.colorMa.TabIndex = 7;
            this.colorMa.Text = "0";
            // 
            // _trilinear
            // 
            this._trilinear.AutoSize = true;
            this._trilinear.Location = new System.Drawing.Point(545, 55);
            this._trilinear.Name = "_trilinear";
            this._trilinear.Size = new System.Drawing.Size(116, 17);
            this._trilinear.TabIndex = 8;
            this._trilinear.Text = "Трилинейная инт.";
            this._trilinear.UseVisualStyleBackColor = true;
            // 
            // tf
            // 
            this.tf.AutoSize = true;
            this.tf.Location = new System.Drawing.Point(545, 94);
            this.tf.Name = "tf";
            this.tf.Size = new System.Drawing.Size(112, 17);
            this.tf.TabIndex = 9;
            this.tf.Text = "Передаточная ф.";
            this.tf.UseVisualStyleBackColor = true;
            // 
            // _cutArrea
            // 
            this._cutArrea.AutoSize = true;
            this._cutArrea.Location = new System.Drawing.Point(545, 132);
            this._cutArrea.Name = "_cutArrea";
            this._cutArrea.Size = new System.Drawing.Size(89, 17);
            this._cutArrea.TabIndex = 5;
            this._cutArrea.Text = "Отсечь окно";
            this._cutArrea.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(550, 339);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(31, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Свет";
            // 
            // lx
            // 
            this.lx.FormattingEnabled = true;
            this.lx.Items.AddRange(new object[] {
            "-1000",
            "-900",
            "-800",
            "-700",
            "-600",
            "-500",
            "-400",
            "-300",
            "-200",
            "-100",
            "0",
            "100",
            "200",
            "300",
            "400",
            "500",
            "600",
            "700",
            "800",
            "900",
            "1000"});
            this.lx.Location = new System.Drawing.Point(536, 362);
            this.lx.Name = "lx";
            this.lx.Size = new System.Drawing.Size(48, 21);
            this.lx.TabIndex = 20;
            this.lx.TextChanged += new System.EventHandler(this.lx_TextChanged);
            // 
            // ly
            // 
            this.ly.FormattingEnabled = true;
            this.ly.Items.AddRange(new object[] {
            "-1000",
            "-900",
            "-800",
            "-700",
            "-600",
            "-500",
            "-400",
            "-300",
            "-200",
            "-100",
            "0",
            "100",
            "200",
            "300",
            "400",
            "500",
            "600",
            "700",
            "800",
            "900",
            "1000"});
            this.ly.Location = new System.Drawing.Point(536, 389);
            this.ly.Name = "ly";
            this.ly.Size = new System.Drawing.Size(48, 21);
            this.ly.TabIndex = 21;
            this.ly.TextChanged += new System.EventHandler(this.ly_TextChanged);
            // 
            // lz
            // 
            this.lz.FormattingEnabled = true;
            this.lz.Items.AddRange(new object[] {
            "-1000",
            "-900",
            "-800",
            "-700",
            "-600",
            "-500",
            "-400",
            "-300",
            "-200",
            "-100",
            "0",
            "100",
            "200",
            "300",
            "400",
            "500",
            "600",
            "700",
            "800",
            "900",
            "1000"});
            this.lz.Location = new System.Drawing.Point(536, 416);
            this.lz.Name = "lz";
            this.lz.Size = new System.Drawing.Size(48, 21);
            this.lz.TabIndex = 22;
            this.lz.TextChanged += new System.EventHandler(this.lz_TextChanged);
            // 
            // labelx
            // 
            this.labelx.AutoSize = true;
            this.labelx.Location = new System.Drawing.Point(611, 364);
            this.labelx.Name = "labelx";
            this.labelx.Size = new System.Drawing.Size(14, 13);
            this.labelx.TabIndex = 23;
            this.labelx.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(611, 391);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 24;
            this.label2.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(611, 417);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Z";
            // 
            // colorMa2
            // 
            this.colorMa2.Location = new System.Drawing.Point(614, 191);
            this.colorMa2.Name = "colorMa2";
            this.colorMa2.Size = new System.Drawing.Size(47, 20);
            this.colorMa2.TabIndex = 27;
            this.colorMa2.Text = "0";
            // 
            // colorMi2
            // 
            this.colorMi2.Location = new System.Drawing.Point(561, 191);
            this.colorMi2.Name = "colorMi2";
            this.colorMi2.Size = new System.Drawing.Size(47, 20);
            this.colorMi2.TabIndex = 26;
            this.colorMi2.Text = "0";
            // 
            // maxX
            // 
            this.maxX.Location = new System.Drawing.Point(703, 364);
            this.maxX.Name = "maxX";
            this.maxX.Size = new System.Drawing.Size(47, 20);
            this.maxX.TabIndex = 31;
            this.maxX.Text = "0";
            this.maxX.TextChanged += new System.EventHandler(this.maxX_TextChanged);
            // 
            // minY
            // 
            this.minY.Location = new System.Drawing.Point(650, 390);
            this.minY.Name = "minY";
            this.minY.Size = new System.Drawing.Size(47, 20);
            this.minY.TabIndex = 30;
            this.minY.Text = "0";
            this.minY.TextChanged += new System.EventHandler(this.minY_TextChanged);
            // 
            // minZ
            // 
            this.minZ.Location = new System.Drawing.Point(650, 416);
            this.minZ.Name = "minZ";
            this.minZ.Size = new System.Drawing.Size(47, 20);
            this.minZ.TabIndex = 29;
            this.minZ.Text = "0";
            this.minZ.TextChanged += new System.EventHandler(this.minZ_TextChanged);
            // 
            // minX
            // 
            this.minX.Location = new System.Drawing.Point(650, 364);
            this.minX.Name = "minX";
            this.minX.Size = new System.Drawing.Size(47, 20);
            this.minX.TabIndex = 28;
            this.minX.Text = "0";
            this.minX.TextChanged += new System.EventHandler(this.minX_TextChanged);
            // 
            // maxY
            // 
            this.maxY.Location = new System.Drawing.Point(703, 390);
            this.maxY.Name = "maxY";
            this.maxY.Size = new System.Drawing.Size(47, 20);
            this.maxY.TabIndex = 32;
            this.maxY.Text = "0";
            this.maxY.TextChanged += new System.EventHandler(this.maxY_TextChanged);
            // 
            // maxZ
            // 
            this.maxZ.Location = new System.Drawing.Point(703, 416);
            this.maxZ.Name = "maxZ";
            this.maxZ.Size = new System.Drawing.Size(47, 20);
            this.maxZ.TabIndex = 33;
            this.maxZ.Text = "0";
            this.maxZ.TextChanged += new System.EventHandler(this.maxZ_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(683, 339);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Бокс";
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(593, 479);
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(104, 45);
            this.trackBar1.TabIndex = 35;
            // 
            // VoxelImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(774, 540);
            this.Controls.Add(this.trackBar1);
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
            this.Controls.Add(this.lz);
            this.Controls.Add(this.ly);
            this.Controls.Add(this.lx);
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
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
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
        private System.Windows.Forms.ComboBox lx;
        private System.Windows.Forms.ComboBox ly;
        private System.Windows.Forms.ComboBox lz;
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
        private System.Windows.Forms.TrackBar trackBar1;

    }
}
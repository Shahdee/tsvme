namespace vme
{
    partial class ColoredTF
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.coloredTF_text = new System.Windows.Forms.Label();
            this.Color = new System.Windows.Forms.Button();
            this.reset_fn = new System.Windows.Forms.Button();
            this.ColorDialog = new System.Windows.Forms.ColorDialog();
            this.Apply = new System.Windows.Forms.Button();
            this.presets = new System.Windows.Forms.ComboBox();
            this.active = new System.Windows.Forms.Label();
            this.cordX = new System.Windows.Forms.Label();
            this.cordY = new System.Windows.Forms.Label();
            this.red = new System.Windows.Forms.Label();
            this.green = new System.Windows.Forms.Label();
            this.blue = new System.Windows.Forms.Label();
            this.alpha = new System.Windows.Forms.Label();
            this.preset_text = new System.Windows.Forms.Label();
            this.opacity = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // coloredTF_text
            // 
            this.coloredTF_text.AutoSize = true;
            this.coloredTF_text.BackColor = System.Drawing.SystemColors.Control;
            this.coloredTF_text.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.coloredTF_text.ForeColor = System.Drawing.Color.OliveDrab;
            this.coloredTF_text.Location = new System.Drawing.Point(143, 10);
            this.coloredTF_text.Name = "coloredTF_text";
            this.coloredTF_text.Size = new System.Drawing.Size(252, 16);
            this.coloredTF_text.TabIndex = 6;
            this.coloredTF_text.Text = "Гистограмма/Передаточная функция";
            // 
            // Color
            // 
            this.Color.Location = new System.Drawing.Point(570, 3);
            this.Color.Name = "Color";
            this.Color.Size = new System.Drawing.Size(47, 35);
            this.Color.TabIndex = 16;
            this.Color.Text = "Цвет";
            this.Color.UseVisualStyleBackColor = true;
            this.Color.Click += new System.EventHandler(this.Color_Click);
            // 
            // reset_fn
            // 
            this.reset_fn.Location = new System.Drawing.Point(517, 3);
            this.reset_fn.Name = "reset_fn";
            this.reset_fn.Size = new System.Drawing.Size(47, 35);
            this.reset_fn.TabIndex = 15;
            this.reset_fn.Text = "По умолч. функция";
            this.reset_fn.UseVisualStyleBackColor = true;
            this.reset_fn.Click += new System.EventHandler(this.reset_fn_Click);
            // 
            // ColorDialog
            // 
            this.ColorDialog.AnyColor = true;
            // 
            // Apply
            // 
            this.Apply.Location = new System.Drawing.Point(570, 44);
            this.Apply.Name = "Apply";
            this.Apply.Size = new System.Drawing.Size(47, 35);
            this.Apply.TabIndex = 17;
            this.Apply.Text = "Прим.";
            this.Apply.UseVisualStyleBackColor = true;
            this.Apply.Click += new System.EventHandler(this.Apply_Click);
            // 
            // presets
            // 
            this.presets.FormattingEnabled = true;
            this.presets.Items.AddRange(new object[] {
            "---",
            "Кости1",
            "Кости2"});
            this.presets.Location = new System.Drawing.Point(473, 130);
            this.presets.Name = "presets";
            this.presets.Size = new System.Drawing.Size(121, 21);
            this.presets.TabIndex = 19;
            this.presets.TextChanged += new System.EventHandler(this.presets_TextChanged);
            // 
            // active
            // 
            this.active.AutoSize = true;
            this.active.Location = new System.Drawing.Point(479, 173);
            this.active.Name = "active";
            this.active.Size = new System.Drawing.Size(62, 13);
            this.active.TabIndex = 20;
            this.active.Text = "Неактивно";
            // 
            // cordX
            // 
            this.cordX.AutoSize = true;
            this.cordX.Location = new System.Drawing.Point(483, 196);
            this.cordX.Name = "cordX";
            this.cordX.Size = new System.Drawing.Size(18, 13);
            this.cordX.TabIndex = 21;
            this.cordX.Text = "x: ";
            // 
            // cordY
            // 
            this.cordY.AutoSize = true;
            this.cordY.Location = new System.Drawing.Point(483, 218);
            this.cordY.Name = "cordY";
            this.cordY.Size = new System.Drawing.Size(15, 13);
            this.cordY.TabIndex = 22;
            this.cordY.Text = "y:";
            // 
            // red
            // 
            this.red.AutoSize = true;
            this.red.Location = new System.Drawing.Point(535, 196);
            this.red.Name = "red";
            this.red.Size = new System.Drawing.Size(18, 13);
            this.red.TabIndex = 23;
            this.red.Text = "R ";
            // 
            // green
            // 
            this.green.AutoSize = true;
            this.green.Location = new System.Drawing.Point(535, 214);
            this.green.Name = "green";
            this.green.Size = new System.Drawing.Size(15, 13);
            this.green.TabIndex = 24;
            this.green.Text = "G";
            // 
            // blue
            // 
            this.blue.AutoSize = true;
            this.blue.Location = new System.Drawing.Point(535, 234);
            this.blue.Name = "blue";
            this.blue.Size = new System.Drawing.Size(14, 13);
            this.blue.TabIndex = 25;
            this.blue.Text = "B";
            // 
            // alpha
            // 
            this.alpha.AutoSize = true;
            this.alpha.Location = new System.Drawing.Point(535, 254);
            this.alpha.Name = "alpha";
            this.alpha.Size = new System.Drawing.Size(14, 13);
            this.alpha.TabIndex = 26;
            this.alpha.Text = "A";
            // 
            // preset_text
            // 
            this.preset_text.AutoSize = true;
            this.preset_text.Location = new System.Drawing.Point(470, 105);
            this.preset_text.Name = "preset_text";
            this.preset_text.Size = new System.Drawing.Size(84, 13);
            this.preset_text.TabIndex = 27;
            this.preset_text.Text = "Предуст. пар-ы";
            // 
            // opacity
            // 
            this.opacity.AutoSize = true;
            this.opacity.Location = new System.Drawing.Point(535, 274);
            this.opacity.Name = "opacity";
            this.opacity.Size = new System.Drawing.Size(15, 13);
            this.opacity.TabIndex = 28;
            this.opacity.Text = "O";
            // 
            // ColoredTF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.opacity);
            this.Controls.Add(this.preset_text);
            this.Controls.Add(this.alpha);
            this.Controls.Add(this.blue);
            this.Controls.Add(this.green);
            this.Controls.Add(this.red);
            this.Controls.Add(this.cordY);
            this.Controls.Add(this.cordX);
            this.Controls.Add(this.active);
            this.Controls.Add(this.presets);
            this.Controls.Add(this.Apply);
            this.Controls.Add(this.Color);
            this.Controls.Add(this.reset_fn);
            this.Controls.Add(this.coloredTF_text);
            this.Name = "ColoredTF";
            this.Size = new System.Drawing.Size(620, 350);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.ColoredTF_Paint);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.ColoredTF_MouseClick);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label coloredTF_text;
        private System.Windows.Forms.Button Color;
        private System.Windows.Forms.Button reset_fn;
        private System.Windows.Forms.ColorDialog ColorDialog;
        private System.Windows.Forms.Button Apply;
        private System.Windows.Forms.ComboBox presets;
        private System.Windows.Forms.Label active;
        private System.Windows.Forms.Label cordX;
        private System.Windows.Forms.Label cordY;
        private System.Windows.Forms.Label red;
        private System.Windows.Forms.Label green;
        private System.Windows.Forms.Label blue;
        private System.Windows.Forms.Label alpha;
        private System.Windows.Forms.Label preset_text;
        private System.Windows.Forms.Label opacity;
        
    }
}

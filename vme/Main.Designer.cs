namespace vme
{
    partial class Main
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
            this.Open = new System.Windows.Forms.Button();
            this.Reset = new System.Windows.Forms.Button();
            this.text_width = new System.Windows.Forms.Label();
            this.text_min = new System.Windows.Forms.Label();
            this.text_centre = new System.Windows.Forms.Label();
            this.text_max = new System.Windows.Forms.Label();
            this.AssignCA = new System.Windows.Forms.Button();
            this.ColorTFobj = new vme.ColoredTF();
            this.TransferFunction = new vme.TransferFunction();
            this.ImagePlane = new vme.Canvas();
            this.SuspendLayout();
            // 
            // Open
            // 
            this.Open.Location = new System.Drawing.Point(36, 21);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(118, 36);
            this.Open.TabIndex = 0;
            this.Open.Text = "Открыть DICOM ";
            this.Open.UseVisualStyleBackColor = true;
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(283, 39);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(118, 35);
            this.Reset.TabIndex = 4;
            this.Reset.Text = "По умолч. область ";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click_1);
            // 
            // text_width
            // 
            this.text_width.AutoSize = true;
            this.text_width.Location = new System.Drawing.Point(422, 95);
            this.text_width.Name = "text_width";
            this.text_width.Size = new System.Drawing.Size(51, 13);
            this.text_width.TabIndex = 8;
            this.text_width.Text = "winWidth";
            // 
            // text_min
            // 
            this.text_min.AutoSize = true;
            this.text_min.Location = new System.Drawing.Point(422, 178);
            this.text_min.Name = "text_min";
            this.text_min.Size = new System.Drawing.Size(40, 13);
            this.text_min.TabIndex = 9;
            this.text_min.Text = "winMin";
            // 
            // text_centre
            // 
            this.text_centre.AutoSize = true;
            this.text_centre.Location = new System.Drawing.Point(422, 122);
            this.text_centre.Name = "text_centre";
            this.text_centre.Size = new System.Drawing.Size(54, 13);
            this.text_centre.TabIndex = 10;
            this.text_centre.Text = "winCentre";
            // 
            // text_max
            // 
            this.text_max.AutoSize = true;
            this.text_max.Location = new System.Drawing.Point(422, 149);
            this.text_max.Name = "text_max";
            this.text_max.Size = new System.Drawing.Size(43, 13);
            this.text_max.TabIndex = 11;
            this.text_max.Text = "winMax";
            // 
            // AssignCA
            // 
            this.AssignCA.Location = new System.Drawing.Point(1073, 21);
            this.AssignCA.Name = "AssignCA";
            this.AssignCA.Size = new System.Drawing.Size(118, 35);
            this.AssignCA.TabIndex = 13;
            this.AssignCA.Text = "Присвоить ц/п";
            this.AssignCA.UseVisualStyleBackColor = true;
            // 
            // ColorTFobj
            // 
            this.ColorTFobj.BackColor = System.Drawing.SystemColors.Control;
            this.ColorTFobj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColorTFobj.Location = new System.Drawing.Point(23, 265);
            this.ColorTFobj.Name = "ColorTFobj";
            this.ColorTFobj.Size = new System.Drawing.Size(620, 350);
            this.ColorTFobj.TabIndex = 14;
            // 
            // TransferFunction
            // 
            this.TransferFunction.BackColor = System.Drawing.SystemColors.Control;
            this.TransferFunction.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TransferFunction.Location = new System.Drawing.Point(23, 80);
            this.TransferFunction.Name = "TransferFunction";
            this.TransferFunction.Size = new System.Drawing.Size(378, 170);
            this.TransferFunction.TabIndex = 12;
            // 
            // ImagePlane
            // 
            this.ImagePlane.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImagePlane.Location = new System.Drawing.Point(679, 64);
            this.ImagePlane.Name = "ImagePlane";
            this.ImagePlane.Size = new System.Drawing.Size(512, 512);
            this.ImagePlane.TabIndex = 1;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1213, 640);
            this.Controls.Add(this.ColorTFobj);
            this.Controls.Add(this.AssignCA);
            this.Controls.Add(this.TransferFunction);
            this.Controls.Add(this.text_max);
            this.Controls.Add(this.text_centre);
            this.Controls.Add(this.text_min);
            this.Controls.Add(this.text_width);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.ImagePlane);
            this.Controls.Add(this.Open);
            this.Name = "Main";
            this.Text = "vme";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Open;
        private Canvas ImagePlane;
        private System.Windows.Forms.Button Reset;
        public System.Windows.Forms.Label text_width;
        public System.Windows.Forms.Label text_min;
        public System.Windows.Forms.Label text_centre;
        public System.Windows.Forms.Label text_max;
        private TransferFunction TransferFunction;
        private System.Windows.Forms.Button AssignCA;
        private ColoredTF ColorTFobj;
        
    }
}

 
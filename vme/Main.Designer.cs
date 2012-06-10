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
            this.AssignCA = new System.Windows.Forms.Button();
            this.ImagePlane = new vme.Canvas();
            this.Windowing = new vme.Windowing();
            this.ColoredTFobj = new vme.ColoredTF();
            this.volume = new System.Windows.Forms.Button();
            this.image_label = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Open
            // 
            this.Open.Location = new System.Drawing.Point(36, 21);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(107, 36);
            this.Open.TabIndex = 0;
            this.Open.Text = "Открыть DICOM ";
            this.Open.UseVisualStyleBackColor = true;
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(425, 39);
            this.Reset.Name = "Reset";
            this.Reset.Size = new System.Drawing.Size(95, 35);
            this.Reset.TabIndex = 4;
            this.Reset.Text = "По умолч. область ";
            this.Reset.UseVisualStyleBackColor = true;
            this.Reset.Click += new System.EventHandler(this.Reset_Click);
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
            // ImagePlane
            // 
            this.ImagePlane.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImagePlane.Location = new System.Drawing.Point(679, 64);
            this.ImagePlane.Name = "ImagePlane";
            this.ImagePlane.Size = new System.Drawing.Size(512, 512);
            this.ImagePlane.TabIndex = 1;
            // 
            // Windowing
            // 
            this.Windowing.BackColor = System.Drawing.SystemColors.Control;
            this.Windowing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Windowing.Location = new System.Drawing.Point(36, 80);
            this.Windowing.Name = "Windowing";
            this.Windowing.Size = new System.Drawing.Size(484, 180);
            this.Windowing.TabIndex = 5;
            // 
            // ColoredTFobj
            // 
            this.ColoredTFobj.BackColor = System.Drawing.SystemColors.Control;
            this.ColoredTFobj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColoredTFobj.Location = new System.Drawing.Point(36, 281);
            this.ColoredTFobj.Name = "ColoredTFobj";
            this.ColoredTFobj.Size = new System.Drawing.Size(620, 350);
            this.ColoredTFobj.TabIndex = 6;
            // 
            // volume
            // 
            this.volume.Location = new System.Drawing.Point(679, 28);
            this.volume.Name = "volume";
            this.volume.Size = new System.Drawing.Size(75, 30);
            this.volume.TabIndex = 7;
            this.volume.Text = "3D";
            this.volume.UseVisualStyleBackColor = true;
            this.volume.Click += new System.EventHandler(this.volume_Click);
            // 
            // image_label
            // 
            this.image_label.AutoSize = true;
            this.image_label.Location = new System.Drawing.Point(1016, 39);
            this.image_label.Name = "image_label";
            this.image_label.Size = new System.Drawing.Size(77, 13);
            this.image_label.TabIndex = 8;
            this.image_label.Text = "Изображение";
            // 
            // TestDataSet
            // 
            this.button1.Location = new System.Drawing.Point(173, 22);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(107, 36);
            this.button1.TabIndex = 9;
            this.button1.Text = "загрузить тест";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.TestDataSet_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1213, 640);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.image_label);
            this.Controls.Add(this.volume);
            this.Controls.Add(this.ColoredTFobj);
            this.Controls.Add(this.Windowing);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.ImagePlane);
            this.Controls.Add(this.Open);
            this.KeyPreview = true;
            this.Name = "Main";
            this.Text = "vme";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Open;
        private Canvas ImagePlane;
        private System.Windows.Forms.Button Reset;
        private System.Windows.Forms.Button AssignCA;
        private Windowing Windowing;
        private ColoredTF ColoredTFobj;
        private System.Windows.Forms.Button volume;
        private System.Windows.Forms.Label image_label;
        private System.Windows.Forms.Button button1;
        
    }
}

 
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
            this.volume = new System.Windows.Forms.Button();
            this.image_label = new System.Windows.Forms.Label();
            this.test_chest = new System.Windows.Forms.Button();
            this.backward = new System.Windows.Forms.Button();
            this.forward = new System.Windows.Forms.Button();
            this.test_head = new System.Windows.Forms.Button();
            this.ColoredTFobj = new vme.ColoredTF();
            this.Windowing = new vme.Windowing();
            this.ImagePlane = new vme.Canvas();
            this.inkDialog = new System.Windows.Forms.ColorDialog();
            this.inkButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Open
            // 
            this.Open.Location = new System.Drawing.Point(36, 22);
            this.Open.Name = "Open";
            this.Open.Size = new System.Drawing.Size(107, 36);
            this.Open.TabIndex = 0;
            this.Open.Text = "Открыть DICOM ";
            this.Open.UseVisualStyleBackColor = true;
            this.Open.Click += new System.EventHandler(this.Open_Click);
            // 
            // Reset
            // 
            this.Reset.Location = new System.Drawing.Point(416, 39);
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
            // volume
            // 
            this.volume.Location = new System.Drawing.Point(662, 30);
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
            this.image_label.Location = new System.Drawing.Point(863, 39);
            this.image_label.Name = "image_label";
            this.image_label.Size = new System.Drawing.Size(77, 13);
            this.image_label.TabIndex = 8;
            this.image_label.Text = "Изображение";
            // 
            // test_chest
            // 
            this.test_chest.Location = new System.Drawing.Point(173, 22);
            this.test_chest.Name = "test_chest";
            this.test_chest.Size = new System.Drawing.Size(75, 36);
            this.test_chest.TabIndex = 9;
            this.test_chest.Text = "грудная клетка - тест";
            this.test_chest.UseVisualStyleBackColor = true;
            this.test_chest.Click += new System.EventHandler(this.TestDataSet_Click);
            // 
            // backward
            // 
            this.backward.Location = new System.Drawing.Point(581, 110);
            this.backward.Name = "backward";
            this.backward.Size = new System.Drawing.Size(75, 36);
            this.backward.TabIndex = 10;
            this.backward.Text = "В начало";
            this.backward.UseVisualStyleBackColor = true;
            this.backward.Click += new System.EventHandler(this.backward_Click);
            // 
            // forward
            // 
            this.forward.Location = new System.Drawing.Point(581, 162);
            this.forward.Name = "forward";
            this.forward.Size = new System.Drawing.Size(75, 36);
            this.forward.TabIndex = 11;
            this.forward.Text = "В конец";
            this.forward.UseVisualStyleBackColor = true;
            this.forward.Click += new System.EventHandler(this.forward_Click);
            // 
            // test_head
            // 
            this.test_head.Location = new System.Drawing.Point(255, 22);
            this.test_head.Name = "test_head";
            this.test_head.Size = new System.Drawing.Size(75, 36);
            this.test_head.TabIndex = 12;
            this.test_head.Text = "голова - тест";
            this.test_head.UseVisualStyleBackColor = true;
            this.test_head.Click += new System.EventHandler(this.test_head_Click);
            // 
            // ColoredTFobj
            // 
            this.ColoredTFobj.BackColor = System.Drawing.SystemColors.Control;
            this.ColoredTFobj.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ColoredTFobj.Location = new System.Drawing.Point(27, 266);
            this.ColoredTFobj.Name = "ColoredTFobj";
            this.ColoredTFobj.Size = new System.Drawing.Size(620, 350);
            this.ColoredTFobj.TabIndex = 6;
            // 
            // Windowing
            // 
            this.Windowing.BackColor = System.Drawing.SystemColors.Control;
            this.Windowing.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Windowing.Location = new System.Drawing.Point(27, 80);
            this.Windowing.Name = "Windowing";
            this.Windowing.Size = new System.Drawing.Size(484, 180);
            this.Windowing.TabIndex = 5;
            // 
            // ImagePlane
            // 
            this.ImagePlane.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ImagePlane.Location = new System.Drawing.Point(662, 64);
            this.ImagePlane.Name = "ImagePlane";
            this.ImagePlane.Size = new System.Drawing.Size(539, 539);
            this.ImagePlane.TabIndex = 1;
            // 
            // inkDialog
            // 
            this.inkDialog.Color = System.Drawing.Color.OrangeRed;
            // 
            // inkButton
            // 
            this.inkButton.Location = new System.Drawing.Point(1126, 30);
            this.inkButton.Name = "inkButton";
            this.inkButton.Size = new System.Drawing.Size(75, 30);
            this.inkButton.TabIndex = 13;
            this.inkButton.Text = "Заливка";
            this.inkButton.UseVisualStyleBackColor = true;
            this.inkButton.Click += new System.EventHandler(this.inkButton_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1213, 640);
            this.Controls.Add(this.inkButton);
            this.Controls.Add(this.test_head);
            this.Controls.Add(this.forward);
            this.Controls.Add(this.backward);
            this.Controls.Add(this.test_chest);
            this.Controls.Add(this.image_label);
            this.Controls.Add(this.volume);
            this.Controls.Add(this.ColoredTFobj);
            this.Controls.Add(this.Windowing);
            this.Controls.Add(this.Reset);
            this.Controls.Add(this.ImagePlane);
            this.Controls.Add(this.Open);
            this.KeyPreview = true;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
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
        private System.Windows.Forms.Button test_chest;
        private System.Windows.Forms.Button backward;
        private System.Windows.Forms.Button forward;
        private System.Windows.Forms.Button test_head;
        private System.Windows.Forms.ColorDialog inkDialog;
        private System.Windows.Forms.Button inkDialogButton;
        private System.Windows.Forms.Button inkButton;
        
    }
}

 
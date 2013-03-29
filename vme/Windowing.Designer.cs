namespace vme
{
    partial class Windowing
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
            this.label4 = new System.Windows.Forms.Label();
            this.text_max = new System.Windows.Forms.Label();
            this.text_centre = new System.Windows.Forms.Label();
            this.text_min = new System.Windows.Forms.Label();
            this.text_width = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.ForeColor = System.Drawing.Color.OliveDrab;
            this.label4.Location = new System.Drawing.Point(181, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 16);
            this.label4.TabIndex = 5;
            this.label4.Text = "ROI";
            // 
            // text_max
            // 
            this.text_max.AutoSize = true;
            this.text_max.Location = new System.Drawing.Point(380, 84);
            this.text_max.Name = "text_max";
            this.text_max.Size = new System.Drawing.Size(27, 13);
            this.text_max.TabIndex = 15;
            this.text_max.Text = "Max";
            // 
            // text_centre
            // 
            this.text_centre.AutoSize = true;
            this.text_centre.Location = new System.Drawing.Point(380, 57);
            this.text_centre.Name = "text_centre";
            this.text_centre.Size = new System.Drawing.Size(38, 13);
            this.text_centre.TabIndex = 14;
            this.text_centre.Text = "Centre";
            // 
            // text_min
            // 
            this.text_min.AutoSize = true;
            this.text_min.Location = new System.Drawing.Point(380, 113);
            this.text_min.Name = "text_min";
            this.text_min.Size = new System.Drawing.Size(24, 13);
            this.text_min.TabIndex = 13;
            this.text_min.Text = "Min";
            // 
            // text_width
            // 
            this.text_width.AutoSize = true;
            this.text_width.Location = new System.Drawing.Point(380, 30);
            this.text_width.Name = "text_width";
            this.text_width.Size = new System.Drawing.Size(35, 13);
            this.text_width.TabIndex = 12;
            this.text_width.Text = "Width";
            // 
            // Windowing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.text_max);
            this.Controls.Add(this.text_centre);
            this.Controls.Add(this.text_min);
            this.Controls.Add(this.text_width);
            this.Controls.Add(this.label4);
            this.Name = "Windowing";
            this.Size = new System.Drawing.Size(484, 180);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Windowing_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label text_max;
        public System.Windows.Forms.Label text_centre;
        public System.Windows.Forms.Label text_min;
        public System.Windows.Forms.Label text_width;
    }
}

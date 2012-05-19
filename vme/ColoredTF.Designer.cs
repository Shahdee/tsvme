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
            this.label4 = new System.Windows.Forms.Label();
            this.Color = new System.Windows.Forms.Button();
            this.reset_fn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Green;
            this.label4.Location = new System.Drawing.Point(184, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(230, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Гистограмма/Передаточная функция";
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
            // ColoredTF
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Color);
            this.Controls.Add(this.reset_fn);
            this.Controls.Add(this.label4);
            this.MouseClick +=new System.Windows.Forms.MouseEventHandler(ColoredTF_MouseClick);
            this.Name = "ColoredTF";
            this.Size = new System.Drawing.Size(620, 350);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button Color;
        private System.Windows.Forms.Button reset_fn;
        
    }
}

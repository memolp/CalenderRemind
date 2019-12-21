namespace Calendar
{
    partial class RoundedControlButton
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
            this.arrow = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.arrow)).BeginInit();
            this.SuspendLayout();
            // 
            // arrow
            // 
            this.arrow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(28)))), ((int)(((byte)(35)))));
            this.arrow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.arrow.Image = global::Calendar.Properties.Resources.arrow;
            this.arrow.Location = new System.Drawing.Point(0, 0);
            this.arrow.Margin = new System.Windows.Forms.Padding(0);
            this.arrow.Name = "arrow";
            this.arrow.Size = new System.Drawing.Size(30, 30);
            this.arrow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.arrow.TabIndex = 1;
            this.arrow.TabStop = false;
            // 
            // RoundedControlButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.arrow);
            this.Name = "RoundedControlButton";
            this.Size = new System.Drawing.Size(30, 30);
            ((System.ComponentModel.ISupportInitialize)(this.arrow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox arrow;
    }
}

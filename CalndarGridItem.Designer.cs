namespace Calendar
{
    partial class CalndarGridItem
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
            this.uiBackImage = new System.Windows.Forms.PictureBox();
            this.uiText = new System.Windows.Forms.Label();
            this.uiBottomLine = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.uiBackImage)).BeginInit();
            this.SuspendLayout();
            // 
            // uiBackImage
            // 
            this.uiBackImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiBackImage.Image = global::Calendar.Properties.Resources.circle;
            this.uiBackImage.Location = new System.Drawing.Point(0, 0);
            this.uiBackImage.Margin = new System.Windows.Forms.Padding(15, 14, 15, 14);
            this.uiBackImage.Name = "uiBackImage";
            this.uiBackImage.Padding = new System.Windows.Forms.Padding(5);
            this.uiBackImage.Size = new System.Drawing.Size(50, 36);
            this.uiBackImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.uiBackImage.TabIndex = 1;
            this.uiBackImage.TabStop = false;
            this.uiBackImage.Visible = false;
            // 
            // uiText
            // 
            this.uiText.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(28)))), ((int)(((byte)(35)))));
            this.uiText.Cursor = System.Windows.Forms.Cursors.Default;
            this.uiText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.uiText.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.uiText.ForeColor = System.Drawing.Color.White;
            this.uiText.Location = new System.Drawing.Point(0, 0);
            this.uiText.Name = "uiText";
            this.uiText.Size = new System.Drawing.Size(50, 36);
            this.uiText.TabIndex = 2;
            this.uiText.Text = "12";
            this.uiText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.uiText.Click += new System.EventHandler(this.onGridItemClicked);
            // 
            // uiBottomLine
            // 
            this.uiBottomLine.Location = new System.Drawing.Point(15, 24);
            this.uiBottomLine.Name = "uiBottomLine";
            this.uiBottomLine.Size = new System.Drawing.Size(20, 3);
            this.uiBottomLine.TabIndex = 3;
            // 
            // CalndarGridItem
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.uiBottomLine);
            this.Controls.Add(this.uiText);
            this.Controls.Add(this.uiBackImage);
            this.Name = "CalndarGridItem";
            this.Size = new System.Drawing.Size(50, 36);
            ((System.ComponentModel.ISupportInitialize)(this.uiBackImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox uiBackImage;
        private System.Windows.Forms.Label uiText;
        private System.Windows.Forms.Panel uiBottomLine;



    }
}

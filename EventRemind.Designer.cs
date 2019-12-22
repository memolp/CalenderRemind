namespace Calendar
{
    partial class EventRemind
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventRemind));
            this.eventDate = new System.Windows.Forms.Label();
            this.eventTitle = new Calendar.TextBoxInput();
            this.eventTime = new System.Windows.Forms.Label();
            this.cancel = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cancel)).BeginInit();
            this.SuspendLayout();
            // 
            // eventDate
            // 
            this.eventDate.AutoSize = true;
            this.eventDate.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.eventDate.Location = new System.Drawing.Point(12, 9);
            this.eventDate.Name = "eventDate";
            this.eventDate.Size = new System.Drawing.Size(123, 19);
            this.eventDate.TabIndex = 0;
            this.eventDate.Text = "2019年12月11日";
            // 
            // eventTitle
            // 
            this.eventTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(61)))), ((int)(((byte)(85)))));
            this.eventTitle.Font = new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventTitle.ForeColor = System.Drawing.Color.White;
            this.eventTitle.Location = new System.Drawing.Point(12, 34);
            this.eventTitle.Multiline = true;
            this.eventTitle.Name = "eventTitle";
            this.eventTitle.Size = new System.Drawing.Size(441, 193);
            this.eventTitle.TabIndex = 8;
            // 
            // eventTime
            // 
            this.eventTime.AutoSize = true;
            this.eventTime.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.eventTime.Location = new System.Drawing.Point(240, 9);
            this.eventTime.Name = "eventTime";
            this.eventTime.Size = new System.Drawing.Size(49, 19);
            this.eventTime.TabIndex = 9;
            this.eventTime.Text = "20:05";
            // 
            // cancel
            // 
            this.cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancel.Image = global::Calendar.Properties.Resources.icon_cancel;
            this.cancel.Location = new System.Drawing.Point(428, 5);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(25, 23);
            this.cancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cancel.TabIndex = 14;
            this.cancel.TabStop = false;
            this.cancel.Click += new System.EventHandler(this.onHideDialog);
            // 
            // EventRemaind
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(61)))), ((int)(((byte)(85)))));
            this.ClientSize = new System.Drawing.Size(465, 240);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.eventTime);
            this.Controls.Add(this.eventTitle);
            this.Controls.Add(this.eventDate);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EventRemaind";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "任务提醒";
            ((System.ComponentModel.ISupportInitialize)(this.cancel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label eventDate;
        private TextBoxInput eventTitle;
        private System.Windows.Forms.Label eventTime;
        private System.Windows.Forms.PictureBox cancel;
    }
}
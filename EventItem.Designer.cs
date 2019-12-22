namespace Calendar
{
    partial class EventItem
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
            this.title = new System.Windows.Forms.Label();
            this.brightPanel = new System.Windows.Forms.Panel();
            this.desc_type = new System.Windows.Forms.Label();
            this.time = new System.Windows.Forms.Label();
            this.brightPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.title.ForeColor = System.Drawing.Color.White;
            this.title.Location = new System.Drawing.Point(26, 15);
            this.title.MaximumSize = new System.Drawing.Size(280, 50);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(205, 17);
            this.title.TabIndex = 12;
            this.title.Text = "Meeting with investors 2           ";
            this.title.DoubleClick += new System.EventHandler(this.OnEventItemClicked);
            // 
            // brightPanel
            // 
            this.brightPanel.Controls.Add(this.desc_type);
            this.brightPanel.Controls.Add(this.time);
            this.brightPanel.Controls.Add(this.title);
            this.brightPanel.Dock = System.Windows.Forms.DockStyle.Right;
            this.brightPanel.Location = new System.Drawing.Point(3, 0);
            this.brightPanel.Name = "brightPanel";
            this.brightPanel.Size = new System.Drawing.Size(317, 47);
            this.brightPanel.TabIndex = 15;
            this.brightPanel.DoubleClick += new System.EventHandler(this.OnEventItemClicked);
            // 
            // desc_type
            // 
            this.desc_type.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.desc_type.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.desc_type.ForeColor = System.Drawing.Color.OrangeRed;
            this.desc_type.Location = new System.Drawing.Point(1, 14);
            this.desc_type.Name = "desc_type";
            this.desc_type.Size = new System.Drawing.Size(23, 20);
            this.desc_type.TabIndex = 14;
            this.desc_type.Text = "定";
            this.desc_type.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // time
            // 
            this.time.AutoSize = true;
            this.time.Dock = System.Windows.Forms.DockStyle.Right;
            this.time.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.time.ForeColor = System.Drawing.Color.White;
            this.time.Location = new System.Drawing.Point(268, 0);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(49, 19);
            this.time.TabIndex = 13;
            this.time.Text = "12:00";
            this.time.Visible = false;
            // 
            // EventItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(63)))), ((int)(((byte)(86)))));
            this.Controls.Add(this.brightPanel);
            this.Name = "EventItem";
            this.Size = new System.Drawing.Size(320, 47);
            this.brightPanel.ResumeLayout(false);
            this.brightPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel brightPanel;
        private System.Windows.Forms.Label time;
        private System.Windows.Forms.Label desc_type;
    }
}

namespace Calendar
{
    partial class MainCalendar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainCalendar));
            this.currentYear = new System.Windows.Forms.Label();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.closeApp = new System.Windows.Forms.PictureBox();
            this.gridView = new System.Windows.Forms.FlowLayoutPanel();
            this.currentMonth = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.addNoteToDay = new System.Windows.Forms.PictureBox();
            this.eventsScrollingView = new System.Windows.Forms.FlowLayoutPanel();
            this.weatherConditionText = new System.Windows.Forms.Label();
            this.weatherDegree = new System.Windows.Forms.Label();
            this.currentDayOfWeek = new System.Windows.Forms.Label();
            this.currentDayOfMonth = new System.Windows.Forms.Label();
            this.prevMonthBtn = new Calendar.RoundedControlButton();
            this.nextMonthBtn = new Calendar.RoundedControlButton();
            this.mainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closeApp)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addNoteToDay)).BeginInit();
            this.SuspendLayout();
            // 
            // currentYear
            // 
            this.currentYear.AutoSize = true;
            this.currentYear.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentYear.ForeColor = System.Drawing.Color.White;
            this.currentYear.Location = new System.Drawing.Point(191, 18);
            this.currentYear.Name = "currentYear";
            this.currentYear.Size = new System.Drawing.Size(83, 36);
            this.currentYear.TabIndex = 0;
            this.currentYear.Text = "2018";
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(28)))), ((int)(((byte)(35)))));
            this.mainPanel.Controls.Add(this.closeApp);
            this.mainPanel.Controls.Add(this.prevMonthBtn);
            this.mainPanel.Controls.Add(this.nextMonthBtn);
            this.mainPanel.Controls.Add(this.gridView);
            this.mainPanel.Controls.Add(this.currentMonth);
            this.mainPanel.Controls.Add(this.currentYear);
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.mainPanel.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.mainPanel.Location = new System.Drawing.Point(0, 0);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(463, 503);
            this.mainPanel.TabIndex = 2;
            // 
            // closeApp
            // 
            this.closeApp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.closeApp.Image = global::Calendar.Properties.Resources.closeApp;
            this.closeApp.Location = new System.Drawing.Point(6, 4);
            this.closeApp.Name = "closeApp";
            this.closeApp.Size = new System.Drawing.Size(23, 21);
            this.closeApp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.closeApp.TabIndex = 5;
            this.closeApp.TabStop = false;
            // 
            // gridView
            // 
            this.gridView.AllowDrop = true;
            this.gridView.Font = new System.Drawing.Font("微软雅黑", 7.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.gridView.Location = new System.Drawing.Point(24, 110);
            this.gridView.Name = "gridView";
            this.gridView.Size = new System.Drawing.Size(420, 385);
            this.gridView.TabIndex = 2;
            // 
            // currentMonth
            // 
            this.currentMonth.Font = new System.Drawing.Font("微软雅黑", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentMonth.ForeColor = System.Drawing.Color.White;
            this.currentMonth.Location = new System.Drawing.Point(27, 66);
            this.currentMonth.Name = "currentMonth";
            this.currentMonth.Size = new System.Drawing.Size(412, 24);
            this.currentMonth.TabIndex = 1;
            this.currentMonth.Text = "December";
            this.currentMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(42)))), ((int)(((byte)(58)))));
            this.panel1.Controls.Add(this.addNoteToDay);
            this.panel1.Controls.Add(this.eventsScrollingView);
            this.panel1.Controls.Add(this.weatherConditionText);
            this.panel1.Controls.Add(this.weatherDegree);
            this.panel1.Controls.Add(this.currentDayOfWeek);
            this.panel1.Controls.Add(this.currentDayOfMonth);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(460, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(340, 503);
            this.panel1.TabIndex = 6;
            // 
            // addNoteToDay
            // 
            this.addNoteToDay.Cursor = System.Windows.Forms.Cursors.Hand;
            this.addNoteToDay.Image = global::Calendar.Properties.Resources.icon_add;
            this.addNoteToDay.Location = new System.Drawing.Point(6, 87);
            this.addNoteToDay.Name = "addNoteToDay";
            this.addNoteToDay.Size = new System.Drawing.Size(24, 22);
            this.addNoteToDay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.addNoteToDay.TabIndex = 6;
            this.addNoteToDay.TabStop = false;
            this.addNoteToDay.Click += new System.EventHandler(this.addNoteToDay_Click_1);
            // 
            // eventsScrollingView
            // 
            this.eventsScrollingView.AllowDrop = true;
            this.eventsScrollingView.AutoScroll = true;
            this.eventsScrollingView.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.eventsScrollingView.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.eventsScrollingView.Location = new System.Drawing.Point(0, 115);
            this.eventsScrollingView.Name = "eventsScrollingView";
            this.eventsScrollingView.Size = new System.Drawing.Size(340, 388);
            this.eventsScrollingView.TabIndex = 5;
            this.eventsScrollingView.WrapContents = false;
            // 
            // weatherConditionText
            // 
            this.weatherConditionText.AutoSize = true;
            this.weatherConditionText.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weatherConditionText.ForeColor = System.Drawing.Color.White;
            this.weatherConditionText.Location = new System.Drawing.Point(197, 36);
            this.weatherConditionText.Name = "weatherConditionText";
            this.weatherConditionText.Size = new System.Drawing.Size(0, 16);
            this.weatherConditionText.TabIndex = 4;
            // 
            // weatherDegree
            // 
            this.weatherDegree.AutoSize = true;
            this.weatherDegree.Font = new System.Drawing.Font("Segoe UI Emoji", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weatherDegree.ForeColor = System.Drawing.Color.White;
            this.weatherDegree.Location = new System.Drawing.Point(198, 21);
            this.weatherDegree.Name = "weatherDegree";
            this.weatherDegree.Size = new System.Drawing.Size(0, 16);
            this.weatherDegree.TabIndex = 3;
            // 
            // currentDayOfWeek
            // 
            this.currentDayOfWeek.AutoSize = true;
            this.currentDayOfWeek.Font = new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentDayOfWeek.ForeColor = System.Drawing.Color.White;
            this.currentDayOfWeek.Location = new System.Drawing.Point(230, 42);
            this.currentDayOfWeek.Name = "currentDayOfWeek";
            this.currentDayOfWeek.Size = new System.Drawing.Size(89, 24);
            this.currentDayOfWeek.TabIndex = 1;
            this.currentDayOfWeek.Text = "Thursday";
            // 
            // currentDayOfMonth
            // 
            this.currentDayOfMonth.Font = new System.Drawing.Font("微软雅黑", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.currentDayOfMonth.ForeColor = System.Drawing.Color.White;
            this.currentDayOfMonth.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.currentDayOfMonth.Location = new System.Drawing.Point(67, 4);
            this.currentDayOfMonth.Name = "currentDayOfMonth";
            this.currentDayOfMonth.Size = new System.Drawing.Size(108, 75);
            this.currentDayOfMonth.TabIndex = 0;
            this.currentDayOfMonth.Text = "15";
            this.currentDayOfMonth.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // prevMonthBtn
            // 
            this.prevMonthBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.prevMonthBtn.Location = new System.Drawing.Point(145, 21);
            this.prevMonthBtn.Name = "prevMonthBtn";
            this.prevMonthBtn.Size = new System.Drawing.Size(30, 28);
            this.prevMonthBtn.TabIndex = 4;
            // 
            // nextMonthBtn
            // 
            this.nextMonthBtn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.nextMonthBtn.Location = new System.Drawing.Point(287, 21);
            this.nextMonthBtn.Name = "nextMonthBtn";
            this.nextMonthBtn.Size = new System.Drawing.Size(30, 28);
            this.nextMonthBtn.TabIndex = 3;
            // 
            // MainCalendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 503);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainCalendar";
            this.Text = "日历备忘";
            this.Load += new System.EventHandler(this.OnStartup);
            this.mainPanel.ResumeLayout(false);
            this.mainPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.closeApp)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.addNoteToDay)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.Label currentYear;
        private System.Windows.Forms.FlowLayoutPanel gridView;
        private System.Windows.Forms.Label currentMonth;
        private RoundedControlButton nextMonthBtn;
        private RoundedControlButton prevMonthBtn;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox addNoteToDay;
        private System.Windows.Forms.FlowLayoutPanel eventsScrollingView;
        private System.Windows.Forms.Label weatherConditionText;
        private System.Windows.Forms.Label weatherDegree;
        private System.Windows.Forms.Label currentDayOfWeek;
        private System.Windows.Forms.Label currentDayOfMonth;
        private System.Windows.Forms.PictureBox closeApp;
    }
}


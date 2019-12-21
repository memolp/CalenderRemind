namespace Calendar
{
    partial class EventUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventUI));
            this.btn_primary = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.event_type = new System.Windows.Forms.ComboBox();
            this.btn_remove = new System.Windows.Forms.Button();
            this.event_id = new System.Windows.Forms.Label();
            this.minuteTxt = new Calendar.TextBoxInput();
            this.hourTxt = new Calendar.TextBoxInput();
            this.eventTitle = new Calendar.TextBoxInput();
            this.selectedDate = new Calendar.TextBoxInput();
            ((System.ComponentModel.ISupportInitialize)(this.cancel)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_primary
            // 
            this.btn_primary.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_primary.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_primary.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_primary.ForeColor = System.Drawing.Color.White;
            this.btn_primary.Location = new System.Drawing.Point(374, 254);
            this.btn_primary.Name = "btn_primary";
            this.btn_primary.Size = new System.Drawing.Size(96, 30);
            this.btn_primary.TabIndex = 12;
            this.btn_primary.Text = "新增";
            this.btn_primary.UseVisualStyleBackColor = true;
            this.btn_primary.Click += new System.EventHandler(this.add_Click);
            // 
            // cancel
            // 
            this.cancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.cancel.Image = global::Calendar.Properties.Resources.icon_cancel;
            this.cancel.Location = new System.Drawing.Point(445, 5);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(25, 23);
            this.cancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.cancel.TabIndex = 13;
            this.cancel.TabStop = false;
            this.cancel.Click += new System.EventHandler(this.close_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 20);
            this.label1.TabIndex = 16;
            this.label1.Text = "输入事件内容:";
            // 
            // event_type
            // 
            this.event_type.AutoCompleteCustomSource.AddRange(new string[] {
            "普通任务",
            "提醒任务"});
            this.event_type.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.event_type.FormattingEnabled = true;
            this.event_type.Items.AddRange(new object[] {
            "普通任务",
            "定时任务",
            "备忘任务"});
            this.event_type.Location = new System.Drawing.Point(7, 256);
            this.event_type.Name = "event_type";
            this.event_type.Size = new System.Drawing.Size(95, 28);
            this.event_type.TabIndex = 17;
            this.event_type.Text = "普通任务";
            // 
            // btn_remove
            // 
            this.btn_remove.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_remove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_remove.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_remove.Location = new System.Drawing.Point(271, 254);
            this.btn_remove.Name = "btn_remove";
            this.btn_remove.Size = new System.Drawing.Size(96, 30);
            this.btn_remove.TabIndex = 18;
            this.btn_remove.Text = "删除";
            this.btn_remove.UseVisualStyleBackColor = true;
            this.btn_remove.Click += new System.EventHandler(this.del_Click);
            // 
            // event_id
            // 
            this.event_id.AutoSize = true;
            this.event_id.Location = new System.Drawing.Point(108, 48);
            this.event_id.Name = "event_id";
            this.event_id.Size = new System.Drawing.Size(53, 12);
            this.event_id.TabIndex = 19;
            this.event_id.Text = "event_id";
            this.event_id.Visible = false;
            // 
            // minuteTxt
            // 
            this.minuteTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(61)))), ((int)(((byte)(85)))));
            this.minuteTxt.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minuteTxt.ForeColor = System.Drawing.Color.White;
            this.minuteTxt.Location = new System.Drawing.Point(161, 254);
            this.minuteTxt.MaxLength = 2;
            this.minuteTxt.Name = "minuteTxt";
            this.minuteTxt.Size = new System.Drawing.Size(42, 34);
            this.minuteTxt.TabIndex = 14;
            this.minuteTxt.Text = "00";
            this.minuteTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // hourTxt
            // 
            this.hourTxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(61)))), ((int)(((byte)(85)))));
            this.hourTxt.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hourTxt.ForeColor = System.Drawing.Color.White;
            this.hourTxt.Location = new System.Drawing.Point(113, 254);
            this.hourTxt.MaxLength = 2;
            this.hourTxt.Name = "hourTxt";
            this.hourTxt.Size = new System.Drawing.Size(42, 34);
            this.hourTxt.TabIndex = 9;
            this.hourTxt.Text = "12";
            this.hourTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // eventTitle
            // 
            this.eventTitle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(61)))), ((int)(((byte)(85)))));
            this.eventTitle.Font = new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.eventTitle.ForeColor = System.Drawing.Color.White;
            this.eventTitle.Location = new System.Drawing.Point(7, 65);
            this.eventTitle.Multiline = true;
            this.eventTitle.Name = "eventTitle";
            this.eventTitle.Size = new System.Drawing.Size(464, 183);
            this.eventTitle.TabIndex = 7;
            // 
            // selectedDate
            // 
            this.selectedDate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(61)))), ((int)(((byte)(85)))));
            this.selectedDate.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.selectedDate.Font = new System.Drawing.Font("微软雅黑", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.selectedDate.ForeColor = System.Drawing.Color.White;
            this.selectedDate.Location = new System.Drawing.Point(9, 9);
            this.selectedDate.Name = "selectedDate";
            this.selectedDate.ReadOnly = true;
            this.selectedDate.Size = new System.Drawing.Size(168, 23);
            this.selectedDate.TabIndex = 20;
            this.selectedDate.Text = "2019年9月10日";
            // 
            // EventUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(61)))), ((int)(((byte)(85)))));
            this.ClientSize = new System.Drawing.Size(480, 293);
            this.Controls.Add(this.selectedDate);
            this.Controls.Add(this.event_id);
            this.Controls.Add(this.btn_remove);
            this.Controls.Add(this.event_type);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.minuteTxt);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.btn_primary);
            this.Controls.Add(this.hourTxt);
            this.Controls.Add(this.eventTitle);
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "EventUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "添加任务";
            ((System.ComponentModel.ISupportInitialize)(this.cancel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox cancel;
        private System.Windows.Forms.Button btn_primary;
        private TextBoxInput hourTxt;
        private TextBoxInput eventTitle;
        private TextBoxInput minuteTxt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox event_type;
        private System.Windows.Forms.Button btn_remove;
        private System.Windows.Forms.Label event_id;
        private TextBoxInput selectedDate;
    }
}
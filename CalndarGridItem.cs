using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public partial class CalndarGridItem : UserControl
    {
        DateTime date;

        public CalndarGridItem()
        {
            InitializeComponent();
        }

        private void backImage_Click(object sender, EventArgs e)
        {

        }

        public void setText(String txt)
        {
            text.Text = txt;
        }

        public void setDateTime(DateTime dt)
        {
            date = new DateTime(dt.Year, dt.Month, int.Parse(text.Text.ToString()));


        }

        public DateTime getDateTime()
        {

            return date;
        }

        public void makeToDay()
        {
            text.Image = Calendar.Properties.Resources.circle;
            bottomLine.Visible = false;
        }

        public void setTextColor(Color color)
        {
            text.ForeColor = color;
        }

        public void hasNote()
        {
            bottomLine.BackColor = Color.FromArgb(255, 0, 117);
        }

        public void hadNote()
        {
            bottomLine.BackColor = Color.FromArgb(65, 84, 93);
        }

        public Boolean daysAreEqual(DateTime dt)
        {
            if (dt.Year == date.Year && dt.Month == date.Month && dt.Day == date.Month)

                return true;

            else
                return false;

        }

        public String getDateString()
        {
            //return date.Day + " " + date.ToString("MMMM").Substring(0, 3) + " " + date.Year;
            return date.Year + "年" + date.Month + "月" + date.Day + "日";
        }

        private void text_Click(object sender, EventArgs e)
        {

        }

        public Label getTextView()
        {
            return text;
        }

        public void setOnGridItemClickListener(EventHandler handler)
        {
            this.text.Click += handler;
        }

        private void onDropEventEnd(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.None;
        }

        private void onDropEventBegin(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            
        }

        private void onDropEventOut(object sender, EventArgs e)
        {

        }
    }
}

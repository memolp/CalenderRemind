using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using System.Drawing;


namespace Calendar
{
    class RoundPic : Button
    {
        public RoundPic()
        {
            this.BackColor = Color.DarkGray;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            GraphicsPath rgPath = new GraphicsPath();
            rgPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new Region(rgPath);
            base.OnPaint(e);
        }



    }
}

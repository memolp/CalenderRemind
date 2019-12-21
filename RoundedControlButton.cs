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
    public partial class RoundedControlButton : UserControl
    {
        public RoundedControlButton()
        {
            InitializeComponent();

           
        }

        public void RotateLeft() {
            Image img = arrow.Image;
            img.RotateFlip(RotateFlipType.Rotate270FlipNone);
            arrow.Image = img;
        }

        public void RotateRight()
        {
            Image img = arrow.Image;
            img.RotateFlip(RotateFlipType.Rotate90FlipNone);
            arrow.Image = img;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void addOnButtonClickHandler(EventHandler handler)
        {
            this.arrow.Click += handler;
        }
    }
}

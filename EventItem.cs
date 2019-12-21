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
    public delegate void EventItemClickHandler(Event obj);

    public partial class EventItem : UserControl
    {
        //将事件传入对象
        private Event mEventData = null;
        private EventItemClickHandler mClickCallback = null;

        public EventItem(Event data)
        {
            mEventData = data;
            InitializeComponent();
            InitView();
            RoundBorderForm(brightPanel);
        }

        private void InitView()
        {
            time.Text = mEventData.Time;
            title.Text = mEventData.Title;
            title.Tag = mEventData.EventID;
            if(mEventData.Type == 0)
            {
                desc_type.Text = "普";
                time.Visible = false;
            }
            else if(mEventData.Type == 1)
            {
                desc_type.Text = "定";
                time.Visible = true;
            }
            else
            {
                desc_type.Text = "备";
                time.Visible = false;
            }
        }


        public static void RoundBorderForm(Panel frm)
        {

            Rectangle Bounds = new Rectangle(0, 0, frm.Width, frm.Height);
            int CornerRadius = 20;
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            path.AddArc(Bounds.X, Bounds.Y, CornerRadius, CornerRadius, 180, 90);
            path.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y, CornerRadius, CornerRadius, 270, 90);
            path.AddArc(Bounds.X + Bounds.Width - CornerRadius, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 0, 90);
            path.AddArc(Bounds.X, Bounds.Y + Bounds.Height - CornerRadius, CornerRadius, CornerRadius, 90, 90);
            path.CloseAllFigures();

            frm.Region = new Region(path);
           
        }

        public Label getTime() {
            return time;
        }

        public Label getTitle()
        {
            return title;
        }

        public void setOnEventItemClickListener(EventItemClickHandler handler)
        {
            mClickCallback = handler;
        }

        private void OnEventItemClicked(object sender, EventArgs e)
        {
            if(mClickCallback != null)
            {
                mClickCallback(mEventData);
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calendar
{
    public partial class EventRemind : Form
    {
        private Event mEventData = null;
        public EventRemind()
        {
            InitializeComponent();
        }

        public void initView(Event evt, string time)
        {
            mEventData = evt;
            eventTime.Text = time;
            eventDate.Text = evt.Date;
            eventTitle.Text = evt.Title;
        }

        private void onHideDialog(object sender, EventArgs e)
        {
            mEventData.closed = 1;
            EventDataDict.GetInstance().UpdateEvent(mEventData, mEventData.Type);
            this.Close();
        }
    }
}

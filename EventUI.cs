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
    public partial class EventUI : Form
    {
        /**
         * 默认打开UI是创建
         */
        private bool mIsCreate = true;
        private static string[] g_time_split = { ":" };
        private string mCurrentSelectedDate = "";
        public EventUI()
        {
            InitializeComponent();
        }

        public void setInitUIView(string date, string hour="12", string minute="00")
        {
            mIsCreate = true;
            selectedDate.Text = date;
            btn_remove.Hide();
            btn_primary.Text = "添加";
            hourTxt.Text = hour;
            minuteTxt.Text = minute;
        }

        public void setInitUIView(Event e, string cur_selected_date)
        {
            mIsCreate = false;
            selectedDate.Text = e.Date;
            eventTitle.Text = e.Title;
            mCurrentSelectedDate = cur_selected_date;
            string[] hour_munite = e.Time.Split(g_time_split,StringSplitOptions.RemoveEmptyEntries);
            if(hour_munite.Length >= 1)
            {
                hourTxt.Text = hour_munite[0];
            }
            if(hour_munite.Length >= 2)
            {
                minuteTxt.Text = hour_munite[1];
            }
            event_type.SelectedIndex = e.Type;
            event_id.Text = "" + e.EventID;
            btn_remove.Show();
            btn_primary.Text = "保存";
        }

        /**
         * 添加事件
         */ 
        private void add_Click(object sender, EventArgs e)
        {

            int etype = event_type.SelectedIndex;
            //创建任务
            if (mIsCreate == true)
            {
                Event evt = new Event(eventTitle.Text, hourTxt.Text + ":" + minuteTxt.Text, selectedDate.Text, etype);
                EventDataDict.GetInstance().AddEvent(evt);
            }
            // 编辑任务
            else
            {
                //如果是备忘任务，这个会显示到所有的日期列表的最后面 - 暂时这样显示
                Event evt = EventDataDict.GetInstance().GetEventWithID(long.Parse(event_id.Text));
                if(evt != null)
                {
                    evt.Time = hourTxt.Text + ":" + minuteTxt.Text;
                    evt.Title = eventTitle.Text;
                    //改变类型的情况下,备忘任务改成其他任务会自动改变日期
                    if (evt.Type != etype && evt.Type == 2)
                    {
                        EventDataDict.GetInstance().EventMoveToDate(evt, etype, mCurrentSelectedDate);
                    }
                    else
                    {
                        EventDataDict.GetInstance().UpdateEvent(evt, etype);
                    }
                }
            }
        }

        private void del_Click(object sender, EventArgs e)
        {
            List<Event> eventslist = new List<Event>();
            //如果是备忘任务，这个会显示到所有的日期列表的最后面 - 暂时这样显示
            EventDataDict.GetInstance().RemoveEventWithID(long.Parse(event_id.Text));
        }

        private void close_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}

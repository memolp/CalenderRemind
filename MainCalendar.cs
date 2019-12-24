using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Device.Location;
using System.IO;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using System.Data.SqlClient;
using System.Security.AccessControl;
using System.Security.Principal;

namespace Calendar
{
    public partial class MainCalendar : Form
    {
        // 消息ID
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;
        public static string[] g_weeklabels = { "周日", "周一", "周二", "周三", "周四", "周五", "周六" };
        public static String eventFileName = ".\\events.bin";
        // 当前的月份偏移
        private int currentMonthCounter = 0;
        // 今天日期
        private DateTime TODAY;
        // 当前选中的日期item
        private CalndarGridItem selectedGridItem = null;
        //记录格子列表
        private List<CalndarGridItem> mCalenderItemList = new List<CalndarGridItem>();
        // 定时器 保存数据和定时任务检查
        private Timer mTimer = new Timer();
        // 任务提醒对话框
        private EventRemind mEventMessage = null;
        // 任务数据对象
        private EventDataDict mEventData = EventDataDict.GetInstance();
        // 上次记录存储的时间
        private DateTime mLastRecordSaveTime = DateTime.Now;

        public MainCalendar(Boolean desktop_)
        {

            InitializeComponent();
            if (desktop_)
            {
                SetToDeskTop();
            }
            initView();
            create_timer();
        }

        private void initView()
        {
            //创建日期网格
            createCalenderGrid();
            // 加载本地日期数据
            mEventData.LoadEventData(eventFileName);
            // 界面拖动消息
            mainPanel.MouseDown += dragger_MouseDown;
            closeApp.Click += stopApp;

            TODAY = DateTime.Today;
            // 切月份的按钮
            nextMonthBtn.RotateLeft();
            prevMonthBtn.RotateRight();
            prevMonthBtn.addOnButtonClickHandler(new EventHandler(prevMonthBtn_onClick));
            nextMonthBtn.addOnButtonClickHandler(new EventHandler(nextMonthBtn_onClick));

            // 刷新格子为当前月
            refreshCalenderGrid(0);
            // 设置任务列表垂直滚动
            this.eventsScrollingView.AutoScroll = false;
            this.eventsScrollingView.FlowDirection = FlowDirection.TopDown;
            this.eventsScrollingView.HorizontalScroll.Maximum = 0;
            this.eventsScrollingView.AutoScroll = true;
        }

        private void create_timer()
        {
            mTimer.Interval = 1000;
            mTimer.Tick += onTimerTick;
            mTimer.Start();
        }

        private void onTimerTick(object sender, EventArgs e)
        {
            DateTime current_datetime = DateTime.Now;
            String key = Utils.GetDateString(current_datetime);
            int hash_key = key.GetHashCode();
            List<Event> events = mEventData.DateOfEvents(hash_key);
            if (events != null)
            {
                foreach (Event evt in events)
                {
                    if (evt.Type != 1) continue;
                    if (evt.closed == 1) continue;
                    if(this.inTimer(evt.Time , current_datetime))
                    {
                        if(mEventMessage == null)
                        {
                            mEventMessage = new EventRemind();
                            mEventMessage.FormClosed += onEventCloseHandler;
                            mEventMessage.Show();
                        }
                        mEventMessage.initView(evt, string.Format("{0:00}:{1:00}:{2:00}", current_datetime.Hour, current_datetime.Minute, current_datetime.Second));
                    }
                }
            }
            //每隔10分钟存储数据一次
            TimeSpan diff = current_datetime - mLastRecordSaveTime;
            if(diff.Minutes > 10)
            {
                mLastRecordSaveTime = current_datetime;
                mEventData.SaveEventData();
            }
        }
        private static string[] g_time_split = { ":" };
        private bool inTimer(string time, DateTime now)
        {
            string[] hour_munite = time.Split(g_time_split, StringSplitOptions.RemoveEmptyEntries);
            int hour = 0;
            int minute = 0;
            if (hour_munite.Length >= 1)
            {
                hour = int.Parse(hour_munite[0]);
            }
            if (hour_munite.Length >= 2)
            {
                minute = int.Parse(hour_munite[1]);
            }
            if(now.Hour == hour && (now.Minute - minute) < 1)
            {
                return true;
            }
            return false;
        }

        private void onEventCloseHandler(object sender, EventArgs e)
        {
            mEventMessage.FormClosed -= onEventCloseHandler;
            mEventMessage = null;
            refreshEventList();
        }
        /**
         * 创建一个7x7的日期网格
         */ 
        private void createCalenderGrid()
        {
            //创建一个7×7的网格
            for(int i = 0; i < 49; i++)
            {
                CalndarGridItem item = new CalndarGridItem();
                // 第一行为星期页签
                if (i < 7)
                {
                    item.setWeekDay(g_weeklabels[i]);
                    item.setTextColor(Color.FromArgb(50, 63, 86));
                }
                else
                {
                    // 注册点击事件
                    item.setOnGridItemClickListener(new CalndarGridItemClickHandler(onGridItemClickListener));
                }
                gridView.Controls.Add(item);
                mCalenderItemList.Add(item);
            }
        }
        /**
         * 创建日期格子，包括星期页签
         */
        private void refreshCalenderGrid(int offsetMonth)
        {
            // 重置当前月
            currentMonthCounter = offsetMonth;
            if(selectedGridItem != null)
            {
                selectedGridItem.ClearSelectedEffect();
            }
            // 计算当前选择的月 以及上一个月 下一个月
            DateTime today = DateTime.Today;
            // 如果不是本月
            if (offsetMonth != 0)
                today = today.AddMonths(offsetMonth);
            // 下个月
            DateTime nextMonth = today.AddMonths(1);
            // 上个月
            DateTime prevMonth = today.AddMonths(-1);
            // 本月的第一天
            DateTime temp = new DateTime(today.Year, today.Month, 1);

            int dayOfWeek = (int)temp.DayOfWeek;
            int list_index = 7;
            // 显示上个月剩余的天数
            int dayOfPrevMonth = System.DateTime.DaysInMonth(prevMonth.Year, prevMonth.Month);
            for (int i = dayOfWeek - 1; i >= 0; i--)
            {
                CalndarGridItem item = mCalenderItemList[list_index++];
                item.ResetItem();
                //item.setDayText((dayOfPrevMonth - i) + "");
                item.setDateTime(new DateTime(prevMonth.Year, prevMonth.Month, (dayOfPrevMonth - i)));
                item.setTextColor(Color.FromArgb(50, 63, 86));
            }
            // 显示本月的天数
            int daysOfCurrentMonth = System.DateTime.DaysInMonth(today.Year, today.Month);
            for (int i = 1; i <= daysOfCurrentMonth && list_index < mCalenderItemList.Count; i++)
            {
                string day = i.ToString();
                // 创建日期格子
                CalndarGridItem item = mCalenderItemList[list_index++];
                item.ResetItem();
                item.setDateTime(new DateTime(today.Year, today.Month, i));
                item.setTextColor(Color.FromArgb(255, 255, 255));
                // 今天
                if (offsetMonth == 0 && i == DateTime.Today.Day)
                {
                    item.makeToDay();
                    //首次启动没有选择item，就选中今天
                    if(selectedGridItem == null)
                        selectedGridItem = item;
                }
                    
                String key = Utils.GetDateString(today, day);
                if (mEventData.ContainsKey(key.GetHashCode()))
                {
                    if (offsetMonth <= 0 && i < TODAY.Day)
                        item.hadNote();
                    else
                        item.hasNote();
                }
            }
            // 显示下一个月的前几天
            int daysOfNextMonth = dayOfWeek - 1 + daysOfCurrentMonth;
            for (int i = 1; i < 42 - daysOfNextMonth; i++)
            {
                CalndarGridItem item = mCalenderItemList[list_index++];
                item.ResetItem();
                item.setDateTime(new DateTime(nextMonth.Year, nextMonth.Month, i));
                item.setTextColor(Color.FromArgb(50, 63, 86));
            }
            // 设置界面年月
            currentMonth.Text = today.ToString("MMMM");
            currentYear.Text = today.Year + "";
            // 设置选择
            if(!selectedGridItem.daysAreEqual(TODAY))
            {
                selectedGridItem.SetSelectedEffect();
            }
            refreshEventList();
        }
        /**
         * 上个月
         */ 
        private void prevMonthBtn_onClick(object sender, EventArgs e)
        {
            currentMonthCounter--;
            refreshCalenderGrid(currentMonthCounter);
        }
        /**
         * 下个月
         */ 
        private void nextMonthBtn_onClick(object sender, EventArgs e)
        {
            currentMonthCounter++;
            refreshCalenderGrid(currentMonthCounter);
        }
        /**
         * 点击添加任务按钮
         */
        private void addNoteToDay_Click(object sender, EventArgs e)
        {
            //任务事件对话框
            EventUI dialog = new EventUI();
            // 获取时间
            string datetime = Utils.GetDateString(selectedGridItem.getDateTime());
            // 初始化对话框    
            dialog.setInitUIView(datetime);
            // 显示对话框
            DialogResult dr = dialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                refreshCalenderGrid(currentMonthCounter);
            }
        }

        private void onGridItemClickListener(CalndarGridItem sender)
        {
            // 更新选中效果
            selectedGridItem.ClearSelectedEffect();
            if (!sender.daysAreEqual(TODAY))
                sender.SetSelectedEffect();
            selectedGridItem = sender;
            // 更新任务事件列表
            refreshEventList();
        }

        private void onEventItemClickListener(Event obj)
        {
            EventUI dialog = new EventUI();
            String datetime = Utils.GetDateString(selectedGridItem.getDateTime());
            dialog.setInitUIView(obj, datetime);
            DialogResult dr = dialog.ShowDialog();
            if (dr == DialogResult.OK)
            {
                refreshCalenderGrid(currentMonthCounter);
            }
        }
        /**
         *  初始化事件列表
         */
        private void initEventsList(List<Event> events)
        {
            if (events == null) return;
            for (int i = 0; i < events.Count; i++)
            {
                EventItem item = new EventItem(events[i]);
                item.setOnEventItemClickListener(new EventItemClickHandler(onEventItemClickListener));
                eventsScrollingView.Controls.Add(item);
            }
        }
        /**
         * 刷新事件列表
         */ 
        private void refreshEventList()
        {
            DateTime gridDate = selectedGridItem.getDateTime();
            string datetime = Utils.GetDateString(gridDate);
            currentDayOfMonth.Text = gridDate.Day.ToString();
            currentDayOfWeek.Text = g_weeklabels[(int)gridDate.DayOfWeek];

            eventsScrollingView.Controls.Clear();
            List<Event> events = mEventData.DateOfEvents(datetime.GetHashCode());
            initEventsList(events);

            List<Event> remaindEvents = mEventData.DateOfEvents(0);
            initEventsList(remaindEvents);

        }

        private void dragger_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Win32.ReleaseCapture();
                Win32.SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void stopApp(object sender, EventArgs e)
        {
            mEventData.SaveEventData();
            Application.Exit();
        }

        #region 将窗体钉在桌面上
        private void SetToDeskTop()
        {
            try
            {
                if (Environment.OSVersion.Version.Major < 6)
                {
                    base.SendToBack();
                    IntPtr hWndNewParent = Win32.FindWindow("Progman", null);
                    Win32.SetParent(base.Handle, hWndNewParent);
                }
                else
                {
                    IntPtr desktopHwnd = GetDesktopPtr();
                    IntPtr ownHwnd = base.Handle;
                    IntPtr result = Win32.SetParent(ownHwnd, desktopHwnd);

                }

            }
            catch (ApplicationException exx)
            {
                MessageBox.Show(this, exx.Message, "Pin to Desktop");
            }
        }

        private IntPtr GetDesktopPtr()
        {
            //http://blog.csdn.net/mkdym/article/details/7018318
            // 情况一
            IntPtr hwndWorkerW = IntPtr.Zero;
            IntPtr hShellDefView = IntPtr.Zero;
            IntPtr hwndDesktop = IntPtr.Zero;
            IntPtr hProgMan = Win32.FindWindow("ProgMan", null);
            if (hProgMan != IntPtr.Zero)
            {
                hShellDefView = Win32.FindWindowEx(hProgMan, IntPtr.Zero, "SHELLDLL_DefView", null);
                if (hShellDefView != IntPtr.Zero)
                {
                    hwndDesktop = Win32.FindWindowEx(hShellDefView, IntPtr.Zero, "SysListView32", null);
                }
            }
            if (hwndDesktop != IntPtr.Zero) return hwndDesktop;

            // 情况二
            while (hwndDesktop == IntPtr.Zero)
            {//必须存在桌面窗口层次  
                hwndWorkerW = Win32.FindWindowEx(IntPtr.Zero, hwndWorkerW, "WorkerW", null);//获得WorkerW类的窗口  
                if (hwndWorkerW == IntPtr.Zero) break;//未知错误
                hShellDefView = Win32.FindWindowEx(hwndWorkerW, IntPtr.Zero, "SysListView32", null);
                if (hShellDefView == IntPtr.Zero) continue;
                hwndDesktop = Win32.FindWindowEx(hShellDefView, IntPtr.Zero, "SysListView32", null);
            }
            return hwndDesktop;
        }


        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (Environment.OSVersion.Version.Major >= 6)
            {
                Win32.SetWindowPos(base.Handle, 1, 0, 0, 0, 0, Win32.SE_SHUTDOWN_PRIVILEGE);
            }

        }

        private void MainForm_Paint(object sender, PaintEventArgs e)
        {

            if (Environment.OSVersion.Version.Major >= 6)
            {
                Win32.SetWindowPos(base.Handle, 1, 0, 0, 0, 0, Win32.SE_SHUTDOWN_PRIVILEGE);
            }
        }
        #endregion

        private void OnStartup(object sender, EventArgs e)
        {
            // this.SetDesktopLocation(DesktopBounds.Right, 10);
            // this.Left = DesktopBounds.Right;// - this.Width;
            //this.Top = 0;
           // this.Left = Screen.PrimaryScreen.WorkingArea.Width - this.Width;
           // this.Top = 0;
        }
    }
}

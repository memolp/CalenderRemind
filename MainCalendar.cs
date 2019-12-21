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

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();

        public static string[] g_weeklabels = { "周日", "周一", "周二", "周三", "周四", "周五", "周六" };
        int currentMonthCounter = 0;

        DateTime TODAY;

        CalndarGridItem selectedGridItem;

        Label previouslySelected;

        public static String eventFileName =  ".\\events.bin";

        private Timer mTimer = new Timer();

        private EventRemaind mEventMessage = null;

        private EventDataDict mEventData = EventDataDict.GetInstance();

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

            mEventData.LoadEventData(eventFileName);

            mainPanel.MouseDown += dragger_MouseDown;
            closeApp.Click += stopApp;

            TODAY = DateTime.Today;
            selectedGridItem = new CalndarGridItem();
            previouslySelected = selectedGridItem.getTextView();

            selectedGridItem.setText(TODAY.Day + "");
            selectedGridItem.setDateTime(TODAY);


            nextMonthBtn.RotateLeft();
            prevMonthBtn.RotateRight();


            prevMonthBtn.addOnButtonClickHandler(new EventHandler(prevMonthBtn_onClick));
            nextMonthBtn.addOnButtonClickHandler(new EventHandler(nextMonthBtn_onClick));


            createGrid(0);

            String currenDayOfMonthString = (int)DateTime.Today.Day + "";
            currentDayOfMonth.Text = (currenDayOfMonthString.Length < 2 ? "0" + currenDayOfMonthString : currenDayOfMonthString);
            currentDayOfWeek.Text = TODAY.DayOfWeek + "";

            this.eventsScrollingView.AutoScroll = false;
            this.eventsScrollingView.FlowDirection = FlowDirection.TopDown;
            this.eventsScrollingView.HorizontalScroll.Maximum = 0;
            this.eventsScrollingView.AutoScroll = true;

            startEventsList();

        }

        private void create_timer()
        {
            mTimer.Interval = 1000;
            mTimer.Tick += onTimerTick;
            mTimer.Start();
        }

        private void onTimerTick(object sender, EventArgs e)
        {
            DateTime today = DateTime.Now;
            String key = today.Year + "年" + today.Month + "月" + today.Day + "日";
            int hash_key = key.GetHashCode();
            List<Event> events = mEventData.DateOfEvents(hash_key);
            if (events != null)
            {
                foreach (Event evt in events)
                {
                    if (evt.Type != 1) continue;
                    if (evt.closed == 1) continue;
                    if(this.inTimer(evt.Time , today))
                    {
                        if(mEventMessage == null)
                        {
                            mEventMessage = new EventRemaind();
                            mEventMessage.FormClosed += onEventCloseHandler;
                            mEventMessage.Show();
                        }
                        mEventMessage.initView(evt, string.Format("{0:00}:{1:00}:{2:00}", today.Hour, today.Minute, today.Second));
                    }
                }
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
            startEventsList();
        }

        private void createGrid(int addMonth)
        {
       
            gridView.Controls.Clear();

            // 创建星期item
            for (int i = 0; i < 7; i++)
            {
                CalndarGridItem item = new CalndarGridItem();
                item.setText(g_weeklabels[i]);
                item.setTextColor(Color.FromArgb(50, 63, 86));
                gridView.Controls.Add(item);
            }

            DateTime temp;

            DateTime today = DateTime.Today;

            if (addMonth != 0)
                today = today.AddMonths(addMonth);

            DateTime nextMonth = today.AddMonths(1);

            DateTime prevMonth = today.AddMonths(-1);


            temp = new DateTime(today.Year, today.Month, 1);


            int dayOfWeek = (int)temp.DayOfWeek;

            int dayOfPrevMonth = System.DateTime.DaysInMonth(prevMonth.Year, prevMonth.Month);

            for (int i = dayOfWeek - 1; i >= 0; i--)
            {
                CalndarGridItem item = new CalndarGridItem();
                item.setText((dayOfPrevMonth - i) + "");
                item.setTextColor(Color.FromArgb(50, 63, 86));
                gridView.Controls.Add(item);
            }


            int daysOfCurrentMonth = System.DateTime.DaysInMonth(today.Year, today.Month);


            for (int i = 1; i <= daysOfCurrentMonth; i++)
            {
                CalndarGridItem item = new CalndarGridItem();
                item.setText(i + "");

                if (addMonth == 0 && i == (int)DateTime.Today.Day)
                    item.makeToDay();

                item.setDateTime(today);

                item.getTextView().Cursor = Cursors.Hand;

                item.setOnGridItemClickListener(new EventHandler(onGridItemClickListener));

                //String key = i + " " + today.ToString("MMMM").Substring(0, 3) + " " + today.Year;
                String key = today.Year + "年" + today.Month + "月" + i + "日";

                if (mEventData.ContainsKey(key.GetHashCode()))
                {
                    if (addMonth <= 0 && i < TODAY.Day)
                        item.hadNote();
                    else
                        item.hasNote();
                }

                gridView.Controls.Add(item);
            }

            int daysOfNextMonth = dayOfWeek - 1 + daysOfCurrentMonth;

            for (int i = 1; i < 35 - daysOfNextMonth; i++)
            {
                CalndarGridItem item = new CalndarGridItem();
                item.setText(i + "");
                item.setTextColor(Color.FromArgb(50, 63, 86));
                gridView.Controls.Add(item);
            }

            currentMonth.Text = today.ToString("MMMM");
            currentYear.Text = today.Year + "";

        }

        private void prevMonthBtn_onClick(object sender, EventArgs e)
        {
            currentMonthCounter--;
            createGrid(currentMonthCounter);
        }

        private void nextMonthBtn_onClick(object sender, EventArgs e)
        {
            currentMonthCounter++;
            createGrid(currentMonthCounter);
        }

        private void prevMonthBtn_Load(object sender, EventArgs e)
        {

        }

        private Bitmap changeColor(Bitmap sourceBitmap, float blueTint, float greenTint, float redTint)
        {
            BitmapData sourceData = sourceBitmap.LockBits(new Rectangle(0, 0,
                                    sourceBitmap.Width, sourceBitmap.Height),
                                    ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);


            byte[] pixelBuffer = new byte[sourceData.Stride * sourceData.Height];


            Marshal.Copy(sourceData.Scan0, pixelBuffer, 0, pixelBuffer.Length);


            sourceBitmap.UnlockBits(sourceData);


            float blue = 0;
            float green = 0;
            float red = 0;


            for (int k = 0; k + 4 < pixelBuffer.Length; k += 4)
            {
                blue = pixelBuffer[k] + (255 - pixelBuffer[k]) * blueTint;
                green = pixelBuffer[k + 1] + (255 - pixelBuffer[k + 1]) * greenTint;
                red = pixelBuffer[k + 2] + (255 - pixelBuffer[k + 2]) * redTint;


                if (blue > 255)
                { blue = 255; }


                if (green > 255)
                { green = 255; }


                if (red > 255)
                { red = 255; }


                pixelBuffer[k] = (byte)blue;
                pixelBuffer[k + 1] = (byte)green;
                pixelBuffer[k + 2] = (byte)red;


            }


            Bitmap resultBitmap = new Bitmap(sourceBitmap.Width, sourceBitmap.Height);


            BitmapData resultData = resultBitmap.LockBits(new Rectangle(0, 0,
                                    resultBitmap.Width, resultBitmap.Height),
                                    ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);


            Marshal.Copy(pixelBuffer, 0, resultData.Scan0, pixelBuffer.Length);
            resultBitmap.UnlockBits(resultData);


            return resultBitmap;
        }

        private void initEventList()
        {



        }

        private void addNoteToDay_Click_1(object sender, EventArgs e)
        {

            EventUI dialog = new EventUI();

            DateTime dt = DateTime.Now;

            dt = dt.AddMonths(currentMonthCounter);
            //String datetime = previouslySelected.Text + " " + dt.ToString("MMMM").Substring(0, 3) + " " + dt.Year;
            String datetime = dt.Year + "年" + dt.Month + "月" + previouslySelected.Text + "日";
            dialog.setInitUIView(datetime , string.Format("{0:00}",dt.Hour) , string.Format("{0:00}", dt.Minute));

            DialogResult dr = dialog.ShowDialog();

            if (dr == DialogResult.OK)
            {
                //createGrid(currentMonthCounter);
                startEventsList();

            }



        }

        private void onGridItemClickListener(object sender, EventArgs e)
        {
            previouslySelected.BorderStyle = BorderStyle.None;

            if (int.Parse(((Label)sender).Text.ToString()) != TODAY.Day)
                ((Label)sender).BorderStyle = BorderStyle.Fixed3D;

            previouslySelected = ((Label)sender);

            startEventsList();

        }

        private void onEventItemClickListener(Event obj)
        {
            EventUI dialog = new EventUI();

            DateTime dt = DateTime.Now;
            dt = dt.AddMonths(currentMonthCounter);
            String datetime = dt.Year + "年" + dt.Month + "月" + previouslySelected.Text + "日";

            dialog.setInitUIView(obj, datetime);
            DialogResult dr = dialog.ShowDialog();

            if (dr == DialogResult.OK)
            {
                //createGrid(currentMonthCounter);
                startEventsList();
            }
        }

        /**
         *  初始化事件列表
         */
        private void initEventsList(List<Event> events)
        {

            for (int i = 0; i < events.Count; i++)
            {
                EventItem item = new EventItem(events[i]);
                item.setOnEventItemClickListener(new EventItemClickHandler(onEventItemClickListener));
                eventsScrollingView.Controls.Add(item);
            }

        }

        private void startEventsList()
        {
            DateTime temp = TODAY;
            temp = temp.AddMonths(currentMonthCounter);
            //String key_temp = previouslySelected.Text + " " + temp.ToString("MMMM").Substring(0, 3) + " " + temp.Year;
            String key_temp = temp.Year + "年" + temp.Month + "月" + previouslySelected.Text + "日";
            currentDayOfMonth.Text = previouslySelected.Text;
            currentDayOfWeek.Text = g_weeklabels[(int)new DateTime(temp.Year, temp.Month,int.Parse(previouslySelected.Text)).DayOfWeek];
            eventsScrollingView.Controls.Clear();

            List<Event> events = mEventData.DateOfEvents(key_temp.GetHashCode());
            if (events != null)
                initEventsList(events);
            else
                initEventsList(new List<Event>());

            List<Event> remaindEvents = mEventData.DateOfEvents(0);
            if(remaindEvents != null)
            {
                initEventsList(remaindEvents);
            }

        }

        private void dragger_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
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

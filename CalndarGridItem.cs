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
    /**日历日期格子点击事件*/
    public delegate void CalndarGridItemClickHandler(CalndarGridItem obj);

    /**
     *  日历日期格子类
     */ 
    public partial class CalndarGridItem : UserControl
    {
        //当前格子的日期
        private DateTime mItemDate;
        //记录当前格子的点击事件
        private CalndarGridItemClickHandler mHandler = null;

        public CalndarGridItem()
        {
            InitializeComponent();
        }
        /**
         *  设置当前格子的日期，会自动更新界面的天数
         */ 
        public void setDateTime(DateTime dt)
        {
            mItemDate = new DateTime(dt.Year, dt.Month, dt.Day);
            uiText.Text = dt.Day.ToString();
            // 设置鼠标效果
            uiText.Cursor = Cursors.Hand; 
        }
        /**
         * 设置星期
         * @注意 这个和日期的不能共用，但为了节省暂时由这个类代替
         */ 
        public void setWeekDay(string dayofWeek)
        {
            uiText.Text = dayofWeek;
        }
        /**
         * 设置日期天数
         * @注意 这个主要是给上一个月和下一个月使用，不会有点击事件
         */ 
        public void setDayText(string day)
        {
            uiText.Text = day;
        }
        /**
         * 获取当前日期的天
         */ 
        public string getDayText()
        {
            return uiText.Text;
        }
        /**
         *  获取当前格子的日期
         */ 
        public DateTime getDateTime()
        {

            return mItemDate;
        }

        public void makeToDay()
        {
            uiText.Image = Calendar.Properties.Resources.circle;
            uiBottomLine.Visible = false;
        }

        public void setTextColor(Color color)
        {
            uiText.ForeColor = color;
        }
        /**
         * 接口设置这天任务标记（之前，今天，以后）
         * @注意 有没有任务需要自己判断
         */ 
        public void setDateNote()
        {

        }

        public void hasNote()
        {
            uiBottomLine.BackColor = Color.FromArgb(255, 0, 117);
        }

        public void hadNote()
        {
            uiBottomLine.BackColor = Color.FromArgb(65, 84, 93);
        }
        /**
         * 清除选中效果
         */ 
        public void ClearSelectedEffect()
        {
            uiText.BorderStyle = BorderStyle.None;
        }
        /**
         * 重设格子
         */ 
        public void ResetItem()
        {
            this.ClearSelectedEffect();
            uiBottomLine.BackColor = Color.Transparent;
            uiText.Image = null;
            uiBottomLine.Visible = true;
        }
        /**
         * 设置为选中效果
         * @注意 条件判断什么的，外面判断好了再调用
         */ 
        public void SetSelectedEffect()
        {
            uiText.BorderStyle = BorderStyle.Fixed3D;
        }
        /**
         * 日期对比
         */ 
        public Boolean daysAreEqual(DateTime dt)
        {
            if (dt.Year == mItemDate.Year && dt.Month == mItemDate.Month && dt.Day == mItemDate.Day)
                return true;
            else
                return false;
        }
        /**
         * 记录点击事件
         */ 
        public void setOnGridItemClickListener(CalndarGridItemClickHandler handler)
        {
            mHandler = handler;
        }
        /**
         * 格子点击事件
         */ 
        private void onGridItemClicked(object sender, EventArgs e)
        {
            if(mHandler != null)
            {
                mHandler(this);
            }
        }
    }
}

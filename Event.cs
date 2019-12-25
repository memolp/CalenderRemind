using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Calendar
{
    /**
     *  备忘事件
     */ 
    [Serializable]
    public class Event
    {
        // 事件内容
        public String Title;
        // 时间
        public String Time;
        // 日期
        public String Date;
        // 类型 0普通 1定时 2备忘
        public int Type = 0;
        // 事件id
        public String EventID;
        // 关闭
        public int closed = 0;

        public Event()
        {
            EventID = Guid.NewGuid().ToString();
        }

        public Event(String Title, String Time, String Date, int _type)
        {
            this.Title = Title;
            this.Time = Time;
            this.Date = Date;
            this.Type = _type;
            this.EventID = Guid.NewGuid().ToString();
        }

        public String getTitle()
        {
            return Title;
        }

        public String getTime()
        {
            return Time;
        }

        public String getDate()
        {
            return Date;
        }

        public int getType()
        {
            return Type;
        }
    }
}

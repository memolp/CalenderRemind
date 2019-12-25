using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    /**
     * 事件数据字典
     */ 
    class EventDataDict
    {
        private Dictionary<int, List<Event>> mEvents = new Dictionary<int, List<Event>>();
        private string mEventFile = null;
        // 单例类
        private static EventDataDict _instance = new EventDataDict();
        public static EventDataDict GetInstance()
        {
            return _instance;
        }

        public EventDataDict()
        {
            
        }

        /**
         *  加载数据
         */ 
        public void LoadEventData(string data_file)
        {
            mEventFile = data_file;
            if (File.Exists(data_file))
            {
                SaveXML<Dictionary<int, List<Event>>> saver = new SaveXML<Dictionary<int, List<Event>>>();
                mEvents = saver.GetData(mEvents, mEventFile);
            }
        }

        /**
         * 创建文件
         */ 
        protected void CreateFile(string data_file)
        {
            if (!File.Exists(data_file))
                Directory.CreateDirectory(data_file);

            DirectoryInfo dInfo = new DirectoryInfo(data_file);
            DirectorySecurity dSecurity = dInfo.GetAccessControl();
            dSecurity.AddAccessRule(new FileSystemAccessRule("everyone", FileSystemRights.FullControl,
                                                             InheritanceFlags.ObjectInherit | InheritanceFlags.ContainerInherit,
                                                             PropagationFlags.NoPropagateInherit, AccessControlType.Allow));
            dInfo.SetAccessControl(dSecurity);
            dInfo.SetAccessControl(dSecurity);
        }

        /**
         * 保存数据
         */ 
        public void SaveEventData()
        {
            SaveXML<Dictionary<int, List<Event>>> saver = new SaveXML<Dictionary<int, List<Event>>>();
            saver.SaveData(mEvents, mEventFile);
        }

        /**
         *  返回全部的事件
         */ 
        public Dictionary<int, List<Event>> Events()
        {
            return mEvents;
        }

        /**
         * 返回指定日期的事件
         */ 
        public List<Event> DateOfEvents(int date_hash_code)
        {
            if(mEvents == null || !mEvents.ContainsKey(date_hash_code))
            {
                return null;
            }
            return mEvents[date_hash_code];
        }

        /**
         * 是否包含某个key
         */ 
        public bool ContainsKey(int hash_key)
        {
            if (mEvents == null) return false;
            return mEvents.ContainsKey(hash_key);
        }

        /**
         * 根据事件的id获取event
         */
        public Event GetEventWithID(String eventID)
        {
            if (mEvents == null)
            {
                return null;
            }
            foreach (int key in mEvents.Keys)
            {
                foreach(Event evt in mEvents[key])
                {
                    if(evt.EventID == eventID)
                    {
                        return evt;
                    }
                }
            }
            return null;
        }

        /**
         * 添加事件
         */
        public void AddEvent(Event evt)
        {
            int hash_key = GetEventHashKey(evt);
            if(mEvents == null)
            {
                return;
            }
            if(!mEvents.ContainsKey(hash_key))
            {
                mEvents.Add(hash_key, new List<Event>());
            }
            mEvents[hash_key].Add(evt);
        }

        /**
         *  更新事件
         */ 
        public void UpdateEvent(Event evt, int etype)
        {
            if (mEvents == null)
            {
                return;
            }
            int hash_key = GetEventHashKey(evt);
            List<Event> events = DateOfEvents(hash_key);
            if(events != null)
            {
                if(etype != evt.Type)
                {
                    RemoveEvent(evt);
                    evt.Type = etype;
                    AddEvent(evt);
                }
            }
        }

        public void EventMoveToDate(Event evt, int etype, string target_date)
        {
            if (mEvents == null)
            {
                return;
            }
            int hash_key = GetEventHashKey(evt);
            List<Event> events = DateOfEvents(hash_key);
            if (events != null)
            {
                if (etype != evt.Type)
                {
                    RemoveEvent(evt);
                    if (evt.Type == 2)
                    {
                        DateTime temp = DateTime.Today;
                        evt.Date = target_date;
                    }
                    evt.Type = etype;
                    AddEvent(evt);
                }
            }
        }

        /**
         * 移除事件
         */ 
        public void RemoveEvent(Event evt)
        {
            if (mEvents == null)
            {
                return;
            }
            int hash_key = GetEventHashKey(evt);
            if (mEvents.ContainsKey(hash_key))
            {
                mEvents[hash_key].Remove(evt);
                if(mEvents[hash_key].Count == 0)
                {
                    mEvents.Remove(hash_key);
                }
            }
        }
        /**
         *  移除事件根据id
         */ 
        public void RemoveEventWithID(String eventID)
        {
            if (mEvents == null)
            {
                return;
            }
            Event evt = GetEventWithID(eventID);
            if(evt == null)
            {
                return;
            }
            int hash_key = GetEventHashKey(evt);
            if (mEvents.ContainsKey(hash_key))
            {
                mEvents[hash_key].Remove(evt);
            }
        }

        protected int GetEventHashKey(Event evt)
        {
            int hash_key = 0;
            if (evt.Type != 2)
            {
                hash_key = evt.Date.GetHashCode();
            }
            return hash_key;
        }
    }
}

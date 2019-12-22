using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar
{
    /**
     *  工具包
     */ 
    class Utils
    {
        /**
         *  返回日期的字符串格式
         */ 
        public static string GetDateString(DateTime date)
        {
            return date.Year + "年" + date.Month + "月" + date.Day + "日";
        }
        /**
         * 返回日期的字符串，天数传入
         */ 
        public static string GetDateString(DateTime date, string day)
        {
            return date.Year + "年" + date.Month + "月" + day + "日";
        }
    }
}

/* *********************************************** 
* 作者：王杰，创建于2016/2/29 17:55:47 
* 邮箱：wangjie.magic@gmail.com 
* QQ ：2354557520
* ***********************************************/
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.Extension
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// 获取指定时间周数
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static int GetWeekofYear(this DateTime dateTime) {
            var gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(dateTime, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            return weekOfYear;
        }

        /// <summary>
        /// 获取指定时间当周第一天
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfWeek(this DateTime dateTime)
        {
            var dayOfWeek = Convert.ToInt32(dateTime.DayOfWeek.ToString("d"));
            return dateTime.AddDays(1 - ((dayOfWeek == 0) ? 7 : dayOfWeek));
        }

        /// <summary>
        /// 获取指定时间当周最后一天
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime GetLastDayOfWeek(this DateTime dateTime)
        {
            return dateTime.GetFirstDayOfWeek().AddDays(6);
        }

        /// <summary>
        /// 获取指定时间月初
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfMonth(this DateTime dateTime)
        {
            return dateTime.AddDays(1 - dateTime.Day);
        }

        /// <summary>
        /// 获取指定时间月末
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime GetLastDayOfMonth(this DateTime dateTime)
        {
            return dateTime.GetFirstDayOfMonth().AddMonths(1).AddDays(-1);
        }

        /// <summary>
        /// 获取指定时间季初
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfQuarter(this DateTime dateTime)
        {
            return dateTime.AddMonths(0 - (dateTime.Month - 1) % 3).AddDays(1 - dateTime.Day);
        }

        /// <summary>
        /// 获取指定时间季末
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime GetLastDayOfQuarter(this DateTime dateTime)
        {
            return dateTime.GetFirstDayOfQuarter().AddMonths(3).AddDays(-1);
        }

        /// <summary>
        /// 获取指定时间年初
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime GetFirstDayOfYear(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, 1, 1);
        }

        /// <summary>
        /// 获取指定时间年末
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static DateTime GetLastDayOfYear(this DateTime dateTime)
        {
            return new DateTime(dateTime.Year, 12, 31);
        }
    }
}

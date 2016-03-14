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

namespace MagicBox.Common
{
    public static class DateTimeExtension
    {
        public static int GetWeekofYear(this DateTime dateTime) {
            var gc = new GregorianCalendar();
            int weekOfYear = gc.GetWeekOfYear(dateTime, CalendarWeekRule.FirstDay, DayOfWeek.Monday);
            return weekOfYear;
        }
    }
}

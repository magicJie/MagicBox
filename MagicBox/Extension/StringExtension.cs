/* *********************************************** 
* 作者：王杰 建于2016/1/5 11:24:10 
* 邮箱：wangjie.magic@gmil.com 
* QQ ：2354557520
* ***********************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MagicBox.Extension
{
    public static class StringExtension
    {
        /// <summary>
        /// 从源字符串中截取指定左右连个子字符串中间的字符串，
        /// <br/>（如果左右两个字符串在源中可以查到多个，则left取搜寻的第一个，right取离left最近的一个）.如果指定的left或者right不是源的子字符串，抛异常
        /// </summary>
        /// <param name="str"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <param name="comparison">匹配规则</param>
        /// <returns></returns>
        public static string Substring(this string str, string left, string right,StringComparison comparison)
        {
            var leftIndex = str.IndexOf(left, comparison);
            var rightIndex = str.IndexOf(right, leftIndex + left.Length, comparison);
            return str.Substring(leftIndex + left.Length, rightIndex - (leftIndex + left.Length));
        }

        /// <summary>
        /// 校验字符串是否为布尔型。注意不区分大小写！
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsBool(this string value)
        {
            return Regex.IsMatch(value, "^(true|false)$", RegexOptions.IgnoreCase);
        }

        /// <summary>
        /// 校验字符串是否为整数。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsInteger(this string value)
        {
            return Regex.IsMatch(value, "^(0|[1-9][0-9]*|-[1-9][0-9]*)$");
        }

        /// <summary>
        /// 校验字符串是否为小数。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDouble(this string value)
        {
            return Regex.IsMatch(value, @"^[+-]?([0-9]*\.?[0-9]+|[0-9]+\.?[0-9]*)$");
        }

        /// <summary>
        /// 校验字符串是否为小数。
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsDate(this string value)
        {
            return Regex.IsMatch(value,
                        @"^(?:(?!0000)[0-9]{4}-(?:(?:0[1-9]|1[0-2])-(?:0[1-9]|1[0-9]|2[0-8])|(?:0[13-9]|1[0-2])-(?:29|30)" +
                        "|(?:0[13578]|1[02])-31)" +
                        "|(?:[0-9]{2}(?:0[48]|[2468][048]|[13579][26])" +
                        "|(?:0[48]|[2468][048]|[13579][26])00)-02-29)$");
        }
    }
}

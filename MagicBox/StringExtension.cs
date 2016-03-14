/* *********************************************** 
* 作者：王杰 建于2016/1/5 11:24:10 
* 邮箱：wangjie.magic@gmil.com 
* QQ ：2354557520
* ***********************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox
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
    }
}

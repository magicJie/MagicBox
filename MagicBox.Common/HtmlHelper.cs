using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MagicBox.Common
{
    public class HtmlHelper
    {
        public string OpenHtml(string path)
        {
            var sr = new StreamReader(path, Encoding.UTF8);
            var content = sr.ReadToEnd();
            sr.Close();
            sr.Dispose();
            return content;
        }

        public string ReplaceData(string content,Dictionary<string,string> dic)
        {
            var sb = new StringBuilder(content);
            foreach (var item in dic)
            {
                sb.Replace(item.Key, item.Value);
            }
            return sb.ToString();
        }
        /// <summary>
        /// 打开模板，并根据Diction<"标记"，"替换值">完成数据填充
        /// </summary>
        /// <param name="path">模板路径</param>
        /// <param name="dic"></param>
        /// <returns>替换后得到的html页</returns>
        public string OpenAndReplaceData(string path, Dictionary<string, string> dic)
        {
            var content = OpenHtml(path);
            return ReplaceData(content,dic);
        }
    }
}

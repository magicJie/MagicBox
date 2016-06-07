using System;
using System.Collections.Generic;
using System.Web;
using MagicBox.Common;

namespace Demo.Web.MagicBox.Common
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           var m= HttpRuntime.AppDomainAppPath.ToString();
        }

        protected void button1_click(object sender, EventArgs e)
        {
            var htmlHelper = new HtmlHelper();
            var path = AppDomain.CurrentDomain.BaseDirectory+@"\resource\工票打印.htm";
            Dictionary<string, string> dic = new Dictionary<string, string>
            {
                {"$工作编号$", "OD123456"},
                {"$订单类型$", "东电无物料生产订单"}
            };
            var content = htmlHelper.OpenAndReplaceData(path, dic);
            Response.Write(content);
            Response.End();
        }
    }
}
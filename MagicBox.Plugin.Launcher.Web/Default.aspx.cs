using System;
using System.IO;
using System.Web;
using NPOI.HSSF.UserModel;

namespace MagicBox.Plugin.Launcher.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                var templatePath = HttpRuntime.AppDomainAppPath + @"App_File\工票批20141022100929467.xls";
                var fs = new FileStream(templatePath, FileMode.Open, FileAccess.Read);
                var workbook = new HSSFWorkbook(fs);
                fs.Close();
                MemoryStream memoryStream = new MemoryStream(); //创建内存流
                workbook.Write(memoryStream); //npoi将创建好的工作簿写入到内存流
                HttpContext.Current.Response.AppendHeader("Content-Disposition", "attachment;filename=" + "a.xls");
                HttpContext.Current.Response.BinaryWrite(memoryStream.ToArray());
                //HttpContext.Current.Response.End();
            }
        }
    }
}

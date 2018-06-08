using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Demo.Web.MagicBox.
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var xlsFile = HttpContext.Current.Request.UserHostAddress + @"\resource\工票批20141119045605496.xls";
            var jsFile = HttpContext.Current.Request.UserHostAddress + @"\resource\js\printWorkticket.js";
            var js = string.Format("xlPrint(\"{0}\")", xlsFile);
            string content = string.Format("<script type=\"text/javascript\" src=\"{0}\"></script>", jsFile);
            Response.Write(content);
            Response.Write(String.Format("<script>window.onload={0}</script>",js));
            Response.End();
        }
    }
}
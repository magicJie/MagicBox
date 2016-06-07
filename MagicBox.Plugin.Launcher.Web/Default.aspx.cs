using System;
using System.IO;
using System.Web;
using NPOI.HSSF.UserModel;
using System.Web.UI.WebControls;
 
namespace MagicBox.Plugin.Launcher.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        protected Label Label1 { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected override void OnPreInit(EventArgs e)
        {
            base.OnPreInit(e);
            Label1 = new Label
            {
                ID = "Label1",
                Text = B.ToString()
            };
            var m = this.Master.FindControl("MainContent");
            m.Controls.Add(Label1);
        }

        protected override void OnInit(EventArgs e)
        {

            base.OnInit(e);
        }
    }
}

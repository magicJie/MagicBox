using System;
using System.IO;
using System.Web;
using NPOI.HSSF.UserModel;
 
namespace MagicBox.Plugin.Launcher.Web
{
    public partial class Default1 : _Default
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
            }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            
        }
    }
}

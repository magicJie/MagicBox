using System.Web;

namespace MagicBox.AgileWeb.Infrastructure
{
    public class UserSession:HttpSessionStateBase
    {
        public string UserName { set; get; }

        public string LoginIpAddress { set; get; }
    }
}
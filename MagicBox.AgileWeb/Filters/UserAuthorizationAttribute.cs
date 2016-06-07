using System;
using System.Web.Mvc;
using MagicBox.AgileWeb.Infrastructure;

namespace MagicBox.AgileWeb.Filters
{
    public class UserAuthorizationAttribute : ActionFilterAttribute
    {
        public const string CookieUserName = "username";
        public const string UserLoginUrl = "/home/login";

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var context = filterContext.HttpContext;
            if (context.Request.Cookies[CookieUserName] == null ||
                context.Session == null ||
                context.Session[context.Session.SessionID] == null)
            {
                filterContext.Result = new RedirectResult(UserLoginUrl);
            }
            else
            {
                var cookieUserName = context.Request.Cookies[CookieUserName].Value;
                var currentUserSession = context.Session[context.Session.SessionID] as UserSession;
                if (string.IsNullOrWhiteSpace(cookieUserName) || 
                    currentUserSession == null||
                    string.Compare(cookieUserName,currentUserSession.UserName,StringComparison.CurrentCultureIgnoreCase)!=0||
                    string.Compare(currentUserSession.LoginIpAddress,context.Request.UserHostAddress,StringComparison.CurrentCultureIgnoreCase)!=0)
                {
                    filterContext.Result=new RedirectResult(UserLoginUrl);
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
}
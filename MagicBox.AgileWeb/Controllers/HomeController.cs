using System.Web;
using System.Web.Mvc;
using MagicBox.AgileWeb.Filters;
using MagicBox.AgileWeb.Models;
using MagicBox.AgileWeb.Service;

namespace MagicBox.AgileWeb.Controllers
{
    public class HomeController : Controller
    {
        public IUserInfoManager UserInfoManager { set; get; }

        [UserAuthorization]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View(new HomeLoginRequest());
        }
        [HttpPost]
        [ValidateModelState]
        public ActionResult Login(HomeLoginRequest model)
        {
            model.Trim();
            var loginUserSession = UserInfoManager.GetUserSession(model.UserName, model.Password, Request.UserHostAddress);
            if (loginUserSession != null)
            {
                Session[Session.SessionID] = loginUserSession;
                var userCookie = new HttpCookie(UserAuthorizationAttribute.CookieUserName, model.UserName);
                Response.Cookies.Add(userCookie);
                return new RedirectResult("Index");
            }
            ModelState.AddModelError("_error","登陆密码错误或用户不存在或用户被禁用");
            return View();
        }
        [UserAuthorization]
        public ActionResult LoginOut()
        {
            if (Request.Cookies[UserAuthorizationAttribute.CookieUserName] != null &&
                !string.IsNullOrWhiteSpace(Request.Cookies[UserAuthorizationAttribute.CookieUserName].Value))
            {
                UserInfoManager.LoginOut(Request.Cookies[UserAuthorizationAttribute
                    .CookieUserName].Value, Request.UserHostAddress);
                Session[Session.SessionID] = null;
                Request.Cookies.Add(new HttpCookie(UserAuthorizationAttribute.CookieUserName,string.Empty));                
            }
            return RedirectToAction("Login");
        }
    }
}
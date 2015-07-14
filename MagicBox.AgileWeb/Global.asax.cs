using System;
using System.Runtime.ExceptionServices;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using log4net;
using log4net.Config;
using MagicBox.AgileWeb.Service;
using MagicBox.MF;
using MagicBox.MF.Domain;
using Spring.Context.Support;
using Spring.Web.Mvc;

namespace MagicBox.AgileWeb
{
    public class WebApiApplication : SpringMvcApplication
    {
        private readonly ILog _logger = LogManager.GetLogger(typeof (WebApiApplication));

        protected void Application_Start(object sender, EventArgs e)
        {            
            //初始化log4net
            XmlConfigurator.Configure();

            AppDomain.CurrentDomain.FirstChanceException+=CurrentDomain_FirstChanceException;
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            _logger.Debug("Application_Start执行完毕");
        }

        protected override void Application_BeginRequest(object sender, EventArgs e)
        {
            SetInitAccount();
            base.Application_BeginRequest(sender, e);
        }

        /// <summary>
        /// 设置初始账号
        /// </summary>
        private void SetInitAccount()
        {
            var context = ContextRegistry.GetContext();
            var userManager = (IPermissionManager) context.GetObject("Manager.UserInfo");
            const string account = "admin";
            var user = userManager.Get("198515fd-9aae-45ed-b287-fe0355853628");
            if(user!=null)return;
            user = new User
            {
                Account = account,
                Name = "管理员",
                ID = Guid.NewGuid().ToString(),
                Password = "admin",
                LoginNum = 0
            };
            userManager.SaveOrUpdata(user);
        }        

        private void CurrentDomain_FirstChanceException(object sender, FirstChanceExceptionEventArgs e)
        {
            _logger.Error(e.Exception);
        }

        protected void Application_Error(object sender, EventArgs args)
        {
            var lastError = Server.GetLastError().GetBaseException();
            _logger.Error(lastError);
        }

        protected void Session_Start()
        {
            //TODO
        }
    }
}

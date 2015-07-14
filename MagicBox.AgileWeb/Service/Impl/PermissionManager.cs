using System;
using MagicBox.AgileWeb.Infrastructure;
using MagicBox.MF;
using MagicBox.MF.Domain;

namespace MagicBox.AgileWeb.Service.Impl
{
    public class PermissionManager : GenericManager<BaseModel>, IPermissionManager
    {
        /// <summary>
        /// 根据前台输入登陆信息判断是否能个允许登陆，若允许则创建一个会话
        /// </summary>
        /// <param name="account">登陆名</param>
        /// <param name="password">密码</param>
        /// <param name="ipAddress">ip地址</param>
        /// <returns>验证成功返回一个Session、否则返回null</returns>
        public UserSession GetUserSession(string account, string password, string ipAddress)
        {
            if (User.Validate(account, password))
            {
                return new UserSession
                {
                    LoginIpAddress = ipAddress,
                    UserName = account
                };
            }
            return null;
        }
        /// <summary>
        /// 用户注销
        /// </summary>
        /// <param name="account">账户名</param>
        /// <param name="ipAddress">登陆的ip地址</param>
        public void LoginOut(string account, string ipAddress)
        {
            //从上下文中获取当前登陆用户实例            
            User user = RumtimeContext.Current.User;
            if(user==null)throw new Exception("用户状态异常");
            user.Logoff();
        }
    }
}
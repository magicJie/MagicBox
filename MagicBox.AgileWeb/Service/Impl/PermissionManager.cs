using System;
using MagicBox.AgileWeb.Infrastructure;
using MagicBox.MF;

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
        /// <returns></returns>
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

        public void LoginOut(string account, string ipAddress)
        {
            var user = Get(account) as User;
            if(user==null)throw new Exception("用户状态异常");
            user.LoginNum--;
            SaveOrUpdata(user);
        }
    }
}
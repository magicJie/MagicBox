using System;
using MagicBox.AgileWeb.Domain;
using MagicBox.AgileWeb.Infrastructure;

namespace MagicBox.AgileWeb.Service.Impl
{
    public class UserInfoManager:GenericManagerBase<IBaseModel>,IUserInfoManager
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
            var user = Get("198515fd-9aae-45ed-b287-fe0355853628") as User;
            if (user != null && user.Password == password)
            {
                user.LoginNum++;
                Updata(user);
                return new UserSession
                {
                    UserName = account,
                    LoginIpAddress = ipAddress,                    
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
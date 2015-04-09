using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicBox.MF
{
    public class User : Model, System.Security.Principal.IIdentity
    {
        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        public string AuthenticationType
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsAuthenticated
        {
            get { throw new NotImplementedException(); }
        }
        /// <summary>
        /// 根据登陆名和密码进行验证
        /// </summary>
        /// <param name="account">账号</param>
        /// <param name="password">密码</param>
        /// <returns>验证成功返回true，否则为false</returns>
        public static bool Validate(string account, string password)
        {
            throw new NotImplementedException();
        }
    }
}

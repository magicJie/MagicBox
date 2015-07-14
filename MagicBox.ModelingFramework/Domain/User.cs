using System;
using System.Security.Principal;

namespace MagicBox.MF.Domain
{
    /// <summary>
    /// MF提供的用户类型，具备用户基本的登陆信息验证、注销以及用户名、密码等属性
    /// </summary>
    public class User : Model, IIdentity
    {
        #region Field

        private string _account;
        private string _authenticationType;
        private bool _isAuthenticated;
        #endregion Field

        #region Propertity
        public string Name
        {
            get { return _account; }
        }

        public string AuthenticationType
        {
            get { return _authenticationType; }
        }

        public bool IsAuthenticated
        {
            get { return _isAuthenticated; }
        }
        #endregion Propertity

        #region Method
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
        /// <summary>
        /// 注销
        /// </summary>
        public void Logoff()
        {
            throw new NotImplementedException();
        }
        #endregion Method

        #region Constructor

        public User(string account="", string authenticationType="", bool isAuthenticated=false)
        {
            _account = account;
            _authenticationType = authenticationType;
            _isAuthenticated = isAuthenticated;
        }

        #endregion Constructor
    }
}

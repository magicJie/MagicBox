using MagicBox.MF;
using MagicBox.AgileWeb.Infrastructure;

namespace MagicBox.AgileWeb.Service
{
    /// <summary>
    /// 权限服务接口
    /// </summary>
    public interface IPermissionManager:IGenericManager<BaseModel>
    {
        /// <summary>
        /// 根据登陆信息尝试产生一个会话
        /// </summary>
        /// <param name="name">登陆名</param>
        /// <param name="password">密码</param>
        /// <param name="ipAddress">登陆ip</param>
        /// <returns>验证通过返回UserSession,否则返回null</returns>
        UserSession GetUserSession(string name, string password, string ipAddress);
        /// <summary>
        /// 注销
        /// </summary>
        /// <param name="name">登陆名</param>
        /// <param name="ipAddress">ip</param>
        void LoginOut(string name, string ipAddress);
    }
}
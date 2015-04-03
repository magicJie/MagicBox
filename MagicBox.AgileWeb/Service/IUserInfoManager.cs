using MagicBox.AgileWeb.Domain;
using MagicBox.AgileWeb.Infrastructure;

namespace MagicBox.AgileWeb.Service
{
    public interface IUserInfoManager:IGenericManager<IBaseModel>
    {
        UserSession GetUserSession(string name, string password, string ipAddress);
        void LoginOut(string name, string ipAddress);
    }
}
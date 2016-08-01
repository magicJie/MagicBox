using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Demo.Web.MagicBox.Common
{
    public class MyConnection:PersistentConnection
    {
        protected override Task OnReceived(IRequest request, string connectionId, string data)
        {
            data = string.Format("数据是：{0} 时间是：{1}", data, DateTime.Now.ToString());
            return Connection.Send(connectionId, data);
        }
    }
}
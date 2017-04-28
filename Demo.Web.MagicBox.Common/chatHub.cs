using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace Demo.Web.MagicBox.Common
{
    public class chatHub:Hub
    {
        public void Send(string name, string message)    //接收傳送來的訊息
        {
            //傳送訊息到用戶端            
            Clients.All.broadcastMessage(name, message);  //廣播訊息 (這邊用到了動態方法)
        }
    }
}
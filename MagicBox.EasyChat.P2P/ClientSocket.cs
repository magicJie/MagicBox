using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Demo.EasyChat.P2P
{
    internal class ClientSocket : BaseSocket
    {
        public override void Access(string IP, Action accessAction)
        {
            base.CommunicateSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            base.CommunicateSocket.Bind(new IPEndPoint(IPAddress.Any, 9051));

            //服务器的iP和端口
            IPEndPoint serverIP;
            try
            {
                serverIP=new IPEndPoint(IPAddress.Parse(IP),9050);
            }
            catch (Exception)
            {
                throw new Exception(string.Format("{0}不是一个有效的IP",IP));
            }

            //客户端只用来指定的服务器发送消息，不需要绑定本机的IP和端口
            try
            {
                base.CommunicateSocket.BeginConnect(serverIP, ar => { accessAction(); }, null);
            }
            catch (Exception)
            {
                throw new Exception(string.Format("尝试连接{0}不成功！",IP));
            }
        }
    }
}

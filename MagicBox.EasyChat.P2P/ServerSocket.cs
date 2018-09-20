using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Demo.EasyChat.P2P
{
    class ServerSocket:BaseSocket
    {
        public override void Access(string IP, Action accessAction)
        {
            Socket serverSocket=new Socket(AddressFamily.InterNetwork,SocketType.Stream,ProtocolType.Tcp);
            //本机预使用的IP和端口
            IPEndPoint serverIP=new IPEndPoint(IPAddress.Any,9050);
            //绑定服务端设置的IP
            serverSocket.Bind(serverIP);
            //设置监听个数
            serverSocket.Listen(1);
            //异步接收连接请求
            serverSocket.BeginAccept(ar =>
            {
                base.CommunicateSocket = serverSocket.EndAccept(ar);
                accessAction();
            }, null);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;

namespace MagicBox.EasyChat.P2P
{
    public abstract class BaseSocket
    {
        public Socket CommunicateSocket = null;
        public abstract void Access(String IP, Action accessAction);

        public void Send(string message)
        {
            if (CommunicateSocket.Connected == false)
            {
                throw new Exception("还没有建立连接，不能发送消息");
            }
            Byte[] msg = Encoding.UTF8.GetBytes(message);
            CommunicateSocket.BeginSend(msg, 0, msg.Length, SocketFlags.None, ar => { }, null);
        }

        public void Receive(Action<string> receiveAction)
        {
            byte[] msg=new byte[1024];
            CommunicateSocket.BeginReceive(msg, 0, msg.Length, SocketFlags.None, ar =>
            {
                CommunicateSocket.EndReceive(ar);
                receiveAction(Encoding.UTF8.GetString(msg).Trim('\0', ' '));
                Receive(receiveAction);
            }, null);
        }
    }
}

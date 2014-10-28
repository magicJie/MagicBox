using System;
using System.Drawing;
using System.Windows.Forms;

namespace MagicBox.EasyChat.P2P
{
    public partial class Form1 : Form
    {
        private BaseSocket socket;
        private Action AccessAction;
        private Action<string> ReceiveAction; 
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AccessAction = () => this.Invoke((MethodInvoker) delegate()
            {
                labIP.Visible = false;
                textBox3.Visible = false;
                btnAccess.Visible = false;
                btnWaitAccess.Visible = false;

                string friendIP = socket.CommunicateSocket.RemoteEndPoint.ToString();
                labIP.Text = String.Format("连接成功，对方IP：{0}", friendIP);

                try
                {
                    socket.Receive(ReceiveAction);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "错误");
                }
            });

            ReceiveAction = msg =>
            {
                textBox1.Invoke((MethodInvoker) delegate()
                {
                    UpdateGetMsgTextBox(false, msg, Color.Red);
                });
            };
        }

        private void UpdateGetMsgTextBox(bool sendMsg, string msg, Color color)
        {
            string appendText;
            if (sendMsg)
            {
                appendText = "Me:         " + DateTime.Now + Environment.NewLine + msg + Environment.NewLine;
            }
            else
            {
                appendText = "Friend:         " + DateTime.Now + Environment.NewLine + msg + Environment.NewLine;
            }
            int text1Length = textBox1.Text.Length;
            textBox1.AppendText(appendText);
            textBox1.Select(text1Length,appendText.Length-Environment.NewLine.Length*2-msg.Length);
            textBox1.SelectionColor = color;
            textBox1.ScrollToCaret();
        }

        private void sendMsgBtn_Click(object sender, EventArgs e)
        {
            string msg = textBox2.Text.Trim();
            if (string.IsNullOrEmpty(msg))
            {
                MessageBox.Show("消息内容不能为空！", "错误");
                textBox2.Focus();
                return;
            }
            try
            {
                socket.Send(msg);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,"错误");
                return;
            }

            UpdateGetMsgTextBox(true,msg,Color.Blue);
            textBox2.Text = "";
        }

        private void btnAccess_Click(object sender, EventArgs e)
        {
            this.socket=new ClientSocket();
            try
            {
                this.socket.Access(textBox3.Text,this.AccessAction);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误");
            }
            label1.Text = "正在连接对方。。。";
        }

        private void btnWaitAccess_Click(object sender, EventArgs e)
        {
            this.socket=new ServerSocket();
            try
            {
                this.socket.Access("",this.AccessAction);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误！");
            }
            label1.Text = "正在等待连接。。。";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

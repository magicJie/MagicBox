using System;
using System.Windows.Forms;
using MagicBox;
using MagicBox.Security.Cryptography;
using System.IO;

namespace GetMachineInfo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void 获取机器码_Click(object sender, EventArgs e)
        {
            try
            {
                File.WriteAllText("Machine.txt", License.GetMachineCode());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"提取失败!原因:\r\n{ex.ToString()}");
            }
            MessageBox.Show("提取成功!");
        }
    }
}

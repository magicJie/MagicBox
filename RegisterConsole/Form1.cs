using MagicBox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Register
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                var key = File.ReadAllText("key.txt");
                Guard.HoldString(key, "Key");
                var machineCode = textBox1.Text;
                Guard.HoldString(machineCode, "机器码");
                var registerName = textBox2.Text;
                Guard.HoldString(registerName, "注册用户");
                var time = dateTimePicker1.Value;
                Guard.HoldString(time.ToString(), "有效截止日期");
                var licenseKey = MagicBox.License.Genarate(machineCode, registerName, time, key);
                File.WriteAllText("license.txt", $"{licenseKey}\r\n注册用户：{registerName}\r\n有效截止日期：{time.ToString("yyyy-MM-dd")}", Encoding.UTF8);
                MessageBox.Show("生成License成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"生成License失败！原因：\r\n{ex.ToString()}");
            }
        }
    }
}

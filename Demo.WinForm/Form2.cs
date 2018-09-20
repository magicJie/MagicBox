using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MagicBox.;

namespace Demo.WinForm
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var printer = new Printer();
            printer.SendStringToPrinter(textBox1.Text, textBox2.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var printer = new Printer();
            string sBarCodeCMD = "";            //条码打印命令
            StringBuilder sb1 = new StringBuilder(10240);
            int i1;
            i1 = Printer.GETFONTHEX("测试", "宋体", 0, 30, 20, 0, 0, sb1);
            sBarCodeCMD = sb1.ToString().Replace("OUTSTR01", "temp1") + "^XA^MD30^LH20,20^FO20,20^XGtemp1,1,1^FS^XZ";
            printer.SendStringToPrinter(textBox1.Text, sBarCodeCMD);
        }
    }
}

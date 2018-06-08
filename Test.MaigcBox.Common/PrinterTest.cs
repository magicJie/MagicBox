/* *********************************************** 
* 作者：王杰，创建于2016/2/16 15:47:41 
* 邮箱：wangjie.magic@gmail.com 
* QQ ：2354557520
* ***********************************************/
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagicBox;
using System.Drawing.Printing;

namespace Test.MaigcBox.Common
{
    [TestClass]
    public class PrinterTest
    {
        private const string Code = "7000000020011410000001001200035605301Z";

        [TestMethod]
        public void Test() {
            //var sb = new StringBuilder();
            //sb.AppendLine("^XA");
            //sb.AppendLine("^MD20");
            //sb.AppendLine("^LH60,10");
            //sb.AppendLine("^FO20,10");
            //sb.AppendLine("^ACN,18,10");
            //sb.AppendLine("^BQN,2,10");
            //sb.AppendLine("^FDMM,7000000020011410000001001200035605301Z^FS");
            //sb.AppendLine("^XZ");

            var str="CT~~CD,~CC^~CT~"+
                    "^XA~TA000~JSN^LT0^MNW^MTD^PON^PMN^LH0,0^JMA^PR4,4~SD15^JUS^LRN^CI0^XZ"+
                    "^XA"+
                    "^MMT"+
                    "^PW900"+
                    "^LL0600"+
                    "^LS0"+
                    "^FT572,281^BQN,2,9"+
                    "^FDLA,7000000020011410000001001200035605301Z^FS"+
                    "^PQ1,0,1,Y^XZ";
            var printer = new Printer();
            //printer.SendStringToPrinter(new PrintDocument().PrinterSettings.PrinterName, str);
            printer.SendStringToPrinter(@"EPSON LQ-630K ESCP 2 Ver 2.0", "测试指令集");
        }

        [TestMethod]
        public void Test1() 
        {
        
        }
    }
}

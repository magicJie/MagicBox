using System;
using System.Data;
using System.Windows.Forms;

namespace Demo.WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            CompareForAndForeach();
        }

        private void CompareForAndForeach()
        {
            var table = new DataTable();
            table.Columns.Add("操作次数", typeof (long));
            table.Columns.Add("for时间消耗", typeof(string));
            table.Columns.Add("foreach消耗", typeof(string));
            table.Columns.Add("时间消耗比(for/foreach）", typeof(string));
            table.Columns.Add("操作内容", typeof(string));
            TestRead(table, 1000);
            TestRead(table, 10000);
            TestRead(table, 100000);
            TestRead(table, 150000);
            TestRead(table, 1000000);
            TestRead(table, 1500000);
            TestRead(table, 10000000);
            TestRead(table, 15000000);
            TestRead(table, 100000000);
            TestWrite(table, 1000);
            TestWrite(table, 10000);
            TestWrite(table, 100000);
            TestWrite(table, 150000);
            TestWrite(table, 1000000);
            TestWrite(table, 1500000);
            TestWrite(table, 10000000);
            TestWrite(table, 15000000);
            TestWrite(table, 100000000);
            dataGridView1.DataSource = table;
        }

        private void TestWrite(DataTable table, int n)
        {
            var array = new string[n];
            var dateNow = DateTime.Now.Ticks;
            for (int i = 0; i < n; i++)
            {
                array[i]="0";
            }
            var m1 = DateTime.Now.Ticks - dateNow;
            
            table.Rows.Add(n, m1, "NA", "NA", "写");
        }

        private static void TestRead(DataTable table, int n)
        {
            var array = new string[n];
            var dateNow = DateTime.Now.Ticks;
            for (int i = 0; i < n; i++)
            {
                var a =array[i] ;
            }
            var m1 = DateTime.Now.Ticks - dateNow;

            dateNow = DateTime.Now.Ticks;
            foreach (var item in array)
            {
                var a = item;
            }
            var n1 = DateTime.Now.Ticks - dateNow;
            if (n1!=0)
            {
                table.Rows.Add(n, m1, n1, (double)m1 / (double)n1, "读");
            }
            else
            {
                table.Rows.Add(n, m1, n1, "NA", "读");
            }
        }
    }
}

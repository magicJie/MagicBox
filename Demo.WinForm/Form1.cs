using System;
using System.Data;
using System.Windows.Forms;
using System.IO;

namespace Demo.WinForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //选择文件
            var fileDilog = new FolderBrowserDialog
            {
                RootFolder = Environment.SpecialFolder.Desktop,
                ShowNewFolderButton = false
            };
            var result=fileDilog.ShowDialog();
            if (result == DialogResult.OK ||
                result == DialogResult.Yes)
            {
                textBox1.Text = fileDilog.SelectedPath;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(textBox1.Text))
            {
                MessageBox.Show("指定目录不存在");
                return;            
            }
            //执行删除
            DeleteDirectory(new DirectoryInfo(textBox1.Text));
            MessageBox.Show("删除成功！");
        }

        private void DeleteDirectory(FileSystemInfo fileSystemInfo)
        {
            //win8有bug在调用了FileSystemInfo.Exists之后执行Delete方法仍然可能报DirectoryNotFoundException
            if (!fileSystemInfo.Exists)
                return;
            if (fileSystemInfo.Attributes == FileAttributes.Directory)
            {
                foreach (FileSystemInfo child in (fileSystemInfo as DirectoryInfo).GetFileSystemInfos())
                {
                    DeleteDirectory(child);
                }
            }
            else
                fileSystemInfo.Delete();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}

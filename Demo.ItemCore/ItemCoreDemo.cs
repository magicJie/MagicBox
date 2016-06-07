using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using Wisense.ItemCore;
using MagicBox;
using Wisense.Common.Utils;

namespace Demo.ItemCore
{
    public class ItemStateDemo
    {
        public void ShowState()
        {
            WisenseMiddleLayer.Current.BinaryDirectory = AppDomain.CurrentDomain.BaseDirectory;
            WisenseMiddleLayer.Current.FppDataDirectory = AppDomain.CurrentDomain.BaseDirectory+"Data";
            ItemFactory.Init();
        }

        public void TestUpdate()
        {
            const string path = @"d:\db\test\";

            var dir=new DirectoryInfo(path);
            var files = dir.GetFiles("*", SearchOption.AllDirectories);
            foreach (var fileInfo in files)
            {
                var extension = Path.GetExtension(fileInfo.FullName);
                switch (extension.ToLower())
                {
                    case ".txt":
                        break;
                    case ".code":
                        ExecuteUpdateCode(fileInfo.FullName);
                        break;
                    default:
                        CheckFileFormate(fileInfo.FullName);
                        ExecuteSqlScript(fileInfo.FullName);
                        break;
                }
            }
        }

        private void ExecuteUpdateCode(string fileFullName)
        {
            using (var sr = new StreamReader(fileFullName))
            {
                try
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        if (line.StartsWith("//")) continue;
                        var array = line.Split(',');
                        var asm = Assembly.Load(array[0]);
                        var type = asm.GetType(array[1]);
                        var instance = asm.CreateInstance(array[1]);
                        var method = type.GetMethod(array[2]);
                        method.Invoke(instance, null);
                    }
                }
                catch (IndexOutOfRangeException ex)
                {                    
                    throw new Exception("代码升级脚本格式不正确，正确的格式为：程序集名，类型名,方法名。",ex);
                }
            }
        }

        private void RunCmd(string cmd, out string output,out string errorMsg)
        {
            cmd = cmd.Trim().TrimEnd('&') + "&exit";
            using (Process pr = new Process
            {
                StartInfo =
                {
                    FileName = @"cmd.exe",
                    UseShellExecute = false,
                    RedirectStandardInput = true,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    CreateNoWindow = true,
                }
            })
            {
                pr.Start();
                pr.StandardInput.WriteLine(cmd);
                pr.StandardInput.AutoFlush = true;
                output = pr.StandardOutput.ReadToEnd();
                errorMsg = pr.StandardError.ReadToEnd();
                pr.WaitForExit();
                pr.Close();
            }
        }

        private void ExecuteSqlScript(string fileFullName)
        {
            const string conn =
                "Data Source=10.100.3.55/orcl;User ID=fpp5.0.0; Password=fpp5.0.0;Unicode=True; min pool size = 25; max pool size = 100";
            var dataSource = conn.Substring("Data Source=", ";", StringComparison.CurrentCultureIgnoreCase);
            var user = conn.Substring("User ID=", ";", StringComparison.CurrentCultureIgnoreCase);
            var password = conn.Substring("Password=", ";", StringComparison.CurrentCultureIgnoreCase);
            var m = conn.Substring(";", ";", StringComparison.CurrentCultureIgnoreCase);
            var cmd = string.Format("sqlplus -s {0}/{1}@{2} @{3}", user, password, dataSource, fileFullName);
            string output;
            string errorMsg;
            RunCmd(cmd, out output, out errorMsg);
            if (!string.IsNullOrWhiteSpace(errorMsg))
                throw new Exception(errorMsg);
            var sr = new StringReader(output);
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                //这样写是有风险的，如果在sqlplus执行结果中包含以waring或者error开头但是没有出错，这样的情况是否存在？
                if (line.TrimStart().ToLower().StartsWith("warning") || line.TrimStart().ToLower().StartsWith("error"))
                {
                    throw new Exception("在执行脚本" + fileFullName + "发生错误。sqlplus的输出为：" + line);
                }
            }
            Console.WriteLine(output);
        }

        private void CheckFileFormate(string fullName)
        {
            var extension = Path.GetExtension(fullName);
            if (extension == null) throw new Exception("脚本" + fullName + "没有扩展名，系统无法识别");
            if (extension.ToLower().Equals("txt") || extension.ToLower().Equals("code"))
                return;
            string str;
            using (var sr = new StreamReader(fullName, Encoding.UTF8))
            {
                str = sr.ReadToEnd();
            }           
            if (!str.TrimEnd().EndsWith("exit"))//如果sql文件不是以exit结尾要加上exit
            {
                System.IO.File.AppendAllLines(fullName, new[] { "exit" });
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using MagicBox.Plugin;

namespace Demo.EasyChat.P2P
{
    /// <summary>
    /// 主插件调度文件，提供对插件运行的管理
    /// </summary>
    public class EasyChat:MainPlugin
    {
        public override string Name {
            get { return "EasyChat"; }
        }
        public override string Description {
            get { return "EasyChat的主插件，提供了EasyChat的基本功能"; }
        }

        public override void Init()
        {
        }

        public override void Load()
        {
            throw new NotImplementedException();
        }

        public override void Start()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}

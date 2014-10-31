using System;

namespace MagicBox.Plugin.Launcher.WinForm
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            ConfigLoader.Init();
            PluginTree.Current.MainPlugin.Start();
        }
    }
}

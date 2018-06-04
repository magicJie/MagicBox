
namespace MagicBox.Plugin.Launcher.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ConfigLoader.Init();
            PluginTree.Current.MainPlugin.Start();
        }
    }
}

namespace MagicBox.Plugin
{
    /// <summary>
    /// 主插件接口，应用程序主插件必须实现的接口
    /// </summary>
    public interface IMainPlugin:IPlugin
    {
        /// <summary>
        /// 定义主插件启动行为
        /// </summary>
        void Start();
    }
}

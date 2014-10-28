using System;
using System.Collections.Generic;

namespace MagicBox.Plugin
{
    /// <summary>
    /// 提供对系统所有的插件进行管理。由插件树可以轻松的在运行时访问插件以及插件相关资源
    /// </summary>
    public class PluginTree
    {
        private static PluginTree _current;

        public PluginTree()
        {
            Plugins=new List<IPlugin>();
        }

        /// <summary>
        /// 当前的插件树
        /// </summary>
        public static PluginTree Current
        { 
            get
            {
                if (_current == null)
                {
                    return new PluginTree();
                }
                return _current;
            }
            set { _current = value; }
        }

        /// <summary>
        /// 插件树的子插件集合
        /// </summary>
        public List<IPlugin> Plugins { get; set; }

        /// <summary>
        /// 主插件
        /// </summary>
        public IMainPlugin MainPlugin { get; set; }

        /// <summary>
        /// 搜索插件文件夹的配置文件，根据配置文件将插件安放到插件数上
        /// </summary>
        public void Init()
        {

        }

        /// <summary>
        /// 根据索引获取相应的插件
        /// </summary>
        /// <param name="index">插件索引</param>
        /// <returns>对应索引的插件</returns>
        public IPlugin GetPlugin(int index)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据插件id获取相应的插件
        /// </summary>
        /// <param name="pluginId">插件id</param>
        /// <returns>对应id的插件</returns>
        public IPlugin GetPlugin(string pluginId)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 根据插件索引卸载插件
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public bool UnloadPlugin(int index)
        {
            throw new NotImplementedException();
        }
        /// <summary>
        /// 根据插件id卸载插件
        /// </summary>
        /// <param name="pluginId"></param>
        /// <returns></returns>
        public bool UnloadPlugin(string pluginId)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 根据插件配置文件卸载插件
        /// </summary>
        /// <param name="configPath">插件配置文件路径</param>
        /// <returns>成功为true,否则为false</returns>
        public bool LoadPlugin(string configPath)
        {
            throw new NotImplementedException();
        }
    }
}

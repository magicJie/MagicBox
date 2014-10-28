using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using System.Xml;

namespace MagicBox.Plugin
{
    /// <summary>
    /// 提供对插件配置文件的解析以及动态配置
    /// </summary>
    public class ConfigLoader
    {
        private static string _pluginRootPath = Application.StartupPath + "../../../Plugins";
        /// <summary> 
        /// 初始化配置文件加载器
        /// </summary>
        public static void Init()
        {
            //将配置文件数据加载到插件树中
            PluginTree.Current = CreatePluginTree();
        }

        /// <summary>
        /// 根据配置文件生成插件树
        /// </summary>
        /// <exception cref="ApplicationException">主插件配置不正确会抛出此异常</exception>
        /// <returns>插件树</returns>
        private static PluginTree CreatePluginTree()
        {
            PluginTree pluginTree = new PluginTree();
            try
            {
                var configList = GetConfigs();
                //根据配置文件集读取xml文件
                XmlDocument doc=new XmlDocument();
                foreach (string config in configList)
                {
                    doc.Load(config);
                    var dllPath = Path.GetDirectoryName(configList[0]) + "/bin/" + doc.SelectSingleNode("/Plugin").Attributes["dll"].Value;
                    Assembly assembly = Assembly.LoadFile(dllPath);
                    foreach (var type in assembly.GetTypes())
                    {
                        if (type.GetInterface("IMainPlugin") != null)
                        {
                            var mainPlugin = (IMainPlugin) Activator.CreateInstance(type);
                            pluginTree.MainPlugin = mainPlugin;
                            pluginTree.Plugins.Add(mainPlugin);
                        }
                        else if (type.GetInterface("IPlugin") != null)
                        {
                            var plugin = (IPlugin) Activator.CreateInstance(type);
                            pluginTree.MainPlugin.Children.Add(plugin);
                            pluginTree.Plugins.Add(plugin);
                        }
                    }
                }
                return pluginTree;
            }
            catch (System.Xml.XPath.XPathException)
            {
                throw new ApplicationException("主插件配置设置异常");
            }
            catch (NullReferenceException)
            {
                throw new ApplicationException("主插件配置设置异常");
            }
        }
        /// <summary>
        /// 获取所有插件配置文件路径
        /// </summary>
        /// <returns></returns>
        private static List<string> GetConfigs()
        {
            string[] pluginPaths = Directory.GetDirectories(_pluginRootPath);
            List<string> configList = new List<string> {""}; //存储所有配置文件路径。为主配置文件预留第一个位置
            foreach (var pluginPath in pluginPaths)
            {
                var files = Directory.GetFiles(pluginPath);
                foreach (var file in files)
                {
                    if (file.EndsWith(".plugin"))
                    {
                        if (file.EndsWith("main.plugin"))
                        {
                            configList[0] = file;
                        }
                        else
                        {
                            configList.Add(file);
                        }
                    }
                }
            }
            return configList;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicBox.Plugin
{
    public interface IPlugin
    {
        /// <summary>
        /// 获取、设置插件名
        /// </summary>
        String Name { get;}
        /// <summary>
        /// 获取、设置插件描述
        /// </summary>
        String Description { get;}
        /// <summary>
        /// 初始化插件
        /// </summary>
        void Init();
        /// <summary>
        /// 加载插件
        /// </summary>
        void Load();
        /// <summary>
        /// 父插件。默认为主插件
        /// </summary>
        IPlugin Parent { get; set; }
        /// <summary>
        /// 子插件
        /// </summary>
        List<IPlugin> Children { get; set; }
    }
}

using System;
using System.Collections.Generic;

namespace MagicBox.Plugin
{
    /// <summary>
    /// 提供插件的默认实现
    /// </summary>
    public abstract class Plugin:IPlugin
    {
        public abstract string Name { get; set; }
        public abstract string Description { get; set; }
        public virtual void Init()
        {
            throw new NotImplementedException();
        }

        public virtual void Load()
        {
            throw new NotImplementedException();
        }

        public virtual IPlugin Parent { get; set; }
        public virtual List<IPlugin> Children { get; set; }
    }
}

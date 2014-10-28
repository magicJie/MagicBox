using System;
using System.Collections.Generic;

namespace MagicBox.Plugin
{
    /// <summary>
    /// 提供主插件的默认实现
    /// </summary>
    public abstract class MainPlugin:IMainPlugin
    {
        public abstract string Name { get; }
        public abstract string Description { get; }
        public IPlugin Parent { get; set; }
        public List<IPlugin> Children { get; set; }

        protected MainPlugin ()
        {
            Children=new List<IPlugin>();
            Parent = null;
        }

        public virtual void Init()
        {
            throw new NotImplementedException();
        }

        public virtual void Load()
        {
            throw new NotImplementedException();
        }


        public virtual void Start()
        {
            throw new NotImplementedException();
        }
    }
}

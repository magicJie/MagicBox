using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Singleton
{
    public class Singleton
    {
        private static volatile Singleton _instance;
        private readonly static object locker = new object();

        public static Singleton Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (locker)
                    {
                        if (_instance == null)
                            _instance = new Singleton();
                    }
                }
                return _instance;
            }
        }

        private Singleton() { }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Adapter
{
    public class DuckAdapter : Duck
    {
        private Turkey _trukey;

        public DuckAdapter(Turkey turkey)
        {
            _trukey = turkey;
        }

        public override void Fly()
        {
            for (int i = 0; i < 10; i++)
            {
                _trukey.Fly();
            }
        }

        public override void Quack()
        {
            _trukey.Gobble();
        }
    }
}

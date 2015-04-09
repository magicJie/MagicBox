using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicBox.MF
{
    public abstract class Relationship : Model
    {
        public Model Related
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }

        public Model Source
        {
            get
            {
                throw new System.NotImplementedException();
            }
            set
            {
            }
        }
    }
}

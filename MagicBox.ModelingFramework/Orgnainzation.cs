using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicBox.MF
{
    public class Orgnainzation : Model, System.Security.Principal.IIdentity
    {
        public string Name
        {
            get { throw new NotImplementedException(); }
        }

        public string AuthenticationType
        {
            get { throw new NotImplementedException(); }
        }

        public bool IsAuthenticated
        {
            get { throw new NotImplementedException(); }
        }
    }
}

using System;

namespace MagicBox.MF.Models
{
    public partial class Orgnainzation : Model, System.Security.Principal.IIdentity
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

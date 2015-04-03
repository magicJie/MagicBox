using System;

namespace MagicBox.AgileWeb.Domain
{
    public class User:GeneralModel
    {
        public virtual string ID { get; set; }
        public virtual string Name { get; set; }
        public virtual string Account { get; set; }
        public virtual string Password { get; set; }
        public virtual int LoginNum { set; get; }
    }
}
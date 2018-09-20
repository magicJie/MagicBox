using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagicBox
{
    public class Guard
    {
        public static void HoldString(string guest,string guestName)
        {
            if (string.IsNullOrWhiteSpace(guest))
                throw new Exception($"{guestName}值为空！");
        }
    }
}

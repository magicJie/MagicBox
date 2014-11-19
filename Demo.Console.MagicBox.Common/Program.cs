using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Demo.Console.MagicBox.Common
{
    class Program
    {
        static void Main(string[] args)
        {
            var str1 = "OD0029294-02-30";
            var str2 = "OD0029294-01";
            var str3 = str1.Substring(str1.LastIndexOf('-') + 1);
            var str4 = str2 + "-"+str3;
        }
    }
}

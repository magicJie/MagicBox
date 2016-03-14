/* *********************************************** 
* 作者：王杰，创建于2016/2/16 10:20:14 
* 邮箱：wangjie.magic@gmail.com 
* QQ ：2354557520
* ***********************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPattern.Strategy
{
    public class RedHeadDuck:Duck
    {
        public override string Display()
        {
            return "I'm RedHeadDuck.ga...ga...ga...";
        }

        public override string Swim()
        {
            return "I'm RedHadDuck,let's swim";
        }
    }
}

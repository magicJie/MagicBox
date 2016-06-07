/* *********************************************** 
* 作者：王杰，创建于2016/2/16 10:51:58 
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
    public class FlyWithRocket:IFlyBehavior
    {
        public string PeofrmFly()
        {
            return "see,i'm flying with rocket!";
        }
    }
}

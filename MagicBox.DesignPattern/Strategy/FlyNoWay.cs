/* *********************************************** 
* 作者：王杰，创建于2016/2/16 10:50:06 
* 邮箱：wangjie.magic@gmail.com 
* QQ ：2354557520
* ***********************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Strategy
{
    public class FlyNoWay:IFlyBehavior
    {

        public string PeofrmFly()
        {
            return "sorry,i can't fly!";
        }
    }
}

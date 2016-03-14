/* *********************************************** 
* 作者：王杰，创建于2016/2/16 11:06:18 
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
    public static class Test
    {
        public static void DoTest()
        {
            Duck duck = new ModelDuck();
            duck.FlyBehavior = new FlyNoWay();
            Console.WriteLine(duck.PeformFly());
            duck.FlyBehavior = new FlyWithRocket();
            Console.WriteLine(duck.PeformFly());
            
        }
    }
}

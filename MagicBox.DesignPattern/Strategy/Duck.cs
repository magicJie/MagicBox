/* *********************************************** 
* 作者：王杰，创建于2016/2/16 10:13:42 
* 邮箱：wangjie.magic@gmail.com 
* QQ ：2354557520
* ***********************************************/
using MagicBox.DesignPattern.Strategy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.MagicBox.DesignPattern.Strategy
{
    public abstract class Duck
    {
        public IFlyBehavior FlyBehavior { get; set; }
        public IQuackBehavior QuackBehavior { get; set; }

        public abstract string Display();

        public abstract string Swim();

        public virtual string PeformFly() {
            if (FlyBehavior == null)
                throw new Exception("属性FlyBehavior值为Null");
            return FlyBehavior.PeofrmFly();
        }

        public virtual string PeformQuack() {
            if (QuackBehavior == null)
                throw new Exception("属性QuackBehavior值为Null");
            return QuackBehavior.PeformQuack();
        }
    }
}

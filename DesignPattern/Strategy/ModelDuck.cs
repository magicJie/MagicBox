/* *********************************************** 
* 作者：王杰，创建于2016/2/16 10:52:58 
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
    public class ModelDuck:Duck
    {
        public override string Display()
        {
            return "i'm a ModelDuck";
        }

        public override string Swim()
        {
            return "我只是一个模型鸭，没有安装驱动装置，不能游泳";
        }
    }
}

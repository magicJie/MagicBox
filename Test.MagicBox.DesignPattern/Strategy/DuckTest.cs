using System;
using MagicBox.DesignPattern.Strategy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Test.MagicBox.DesignPattern
{
    [TestClass]
    public class DuckTest
    {
        [TestMethod]
        public void Test()
        {
            var duck = new RedHeadDuck
            {
                FlyBehavior = new FlyWithRocket(),
                QuackBehavior = new NormalQuack()
            };
            Console.WriteLine(duck.PeformFly());
            Console.WriteLine(duck.PeformQuack());
        }
    }
}

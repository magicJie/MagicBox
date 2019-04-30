using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagicBox.DesignPattern.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Command.Tests
{
    [TestClass()]
    public class RemoteControlTests
    {
        [TestMethod()]
        public void RemoteControlTest()
        {
            var control = new RemoteControl();
            var mainRoomLight = new Light("mainRoomLight");
            control.SetCommand(0, new LightOnCommand(mainRoomLight), new LightOffCommand(mainRoomLight));
            control.OnButtonWasPushed(0);
            control.OffButtonWasPushed(0);
            control.Undo();
        }
    }
}
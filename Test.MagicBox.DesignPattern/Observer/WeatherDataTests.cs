﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using MagicBox.DesignPattern.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Observer.Tests
{
    [TestClass()]
    public class WeatherDataTests
    {
        [TestMethod()]
        public void WeatherDataTest()
        {
            var weatherData = new WeatherData();
            var display = new CurrentConditionsDisplay();
            weatherData.AddObserver(display);
            weatherData.SetMeasurements(15, 100, 1235);
        }
    }
}
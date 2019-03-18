using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Observer
{
    public class ThirdPartyDispay : DisplayElement, IObserver
    {
        private float _temperature;
        public override void Display()
        {
            Console.WriteLine($"{GetType().Name}当前温度:{_temperature}");
        }

        public void Update(object observerable)
        {
            var weatherData = (WeatherData)observerable;
            _temperature = weatherData.GetTemperature();
            Display();
        }
    }
}

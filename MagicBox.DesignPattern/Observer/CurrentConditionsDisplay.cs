using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Observer
{
    public class CurrentConditionsDisplay : IObserver
    {
        private float _temperature;
        private float _humidity;
        private float _pressure;
        public void Update(object observerable)
        {
            var weatherData = (WeatherData)observerable;
            _temperature = weatherData.GetTemperature();
            _humidity = weatherData.GetHumidity();
            _pressure = weatherData.GetPressure();
            Display();
        }

        public void Display()
        {
            Console.WriteLine($"温度：{_temperature},湿度：{_humidity},压力：{_pressure}");
        }
    }
}

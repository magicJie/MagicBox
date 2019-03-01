using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicBox.DesignPattern.Observer
{
    public class WeatherData : IObserverable
    {
        private List<IObserver> _observers = new List<IObserver>();
        private bool _isChanged = false;
        private float _temperature;
        private float _humidity;
        private float _pressure;

        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void NotifyObserver()
        {
            if(_isChanged)
            {
                foreach (var item in _observers)
                {
                    item.Update(this);
                }
                _isChanged = false;
            }
        }

        public void RemoveObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void WeatherDataChanged()
        {
            _isChanged = true;
            NotifyObserver();
        }

        public void SetMeasurements(float temperature, float humidity, float pressure)
        {
            _temperature = temperature;
            _humidity = humidity;
            _pressure = pressure;
            WeatherDataChanged();
        }

        public float GetTemperature() {
            return _temperature;
        }

        public float GetHumidity()
        {
            return _humidity;
        }
        public float GetPressure()
        {
            return _pressure;
        }
    }
}

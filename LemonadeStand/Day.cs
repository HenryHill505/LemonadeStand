using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Day
    {
        public int actualTemperature;
        public Weather actualWeather;
        public int forecastTemperature;
        public Weather forecastWeather;
        private List<Weather> weatherList = new List<Weather> { new ClearAndSunny(), new Cloudy(), new Hazy(), new Overcast(), new Rain() };

        public Day()
        {
            actualWeather = PickWeather();
            actualTemperature = PickTemperature();
            forecastWeather = ForecastWeather();
            forecastTemperature = ForecastTemperature();
        }

        public int ForecastTemperature()
        {
            Random randomObject = new Random();
            return actualTemperature + randomObject.Next(-10, 11);
        }

        public Weather ForecastWeather()
        {
            Random randomObject = new Random();
            if (randomObject.Next(0, 2) < 1)
            {
                return actualWeather;
            }
            else
            {
                return weatherList[randomObject.Next(0, weatherList.Count - 1)];
            }
        }

        public int PickTemperature()
        {
            Random randomObject = new Random();
            return 50 + randomObject.Next(0, 55);
        }

        public Weather PickWeather()
        {
            Random randomObject = new Random();
            return weatherList[randomObject.Next(0, weatherList.Count - 1)];
        }
    }
}

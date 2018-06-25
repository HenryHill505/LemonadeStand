using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStand
{
    class Day
    {
        int actualTemperature;
        Weather actualWeather;
        int forecastTemperature;
        Weather forecastWeather;
        List<Weather> weatherList;

        public Day()
        {
            
        }

        public void ForecastTemperature()
        {

        }

        public void ForecastWeather()
        {

        }

        public void PickTemperature()
        {

        }
        public Weather PickWeather()
        {
            Random randomobject = new Random();
            return weatherList[randomobject.Next(0, weatherList.Count - 1)];
        }
    }
}

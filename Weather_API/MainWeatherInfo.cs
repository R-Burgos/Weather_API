using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Weather_API
{
    public class MainWeatherInfo
    {
        public MainWeatherInfo()
        {

        }

        public double temp { get; set; } //Temperature.
        public double feels_like { get; set; } //Temperature. This temperature parameter accounts for the human perception of weather.
        public double temp_min { get; set; } //Minimum temperature at the moment. This is minimal currently observed temperature.
        public double temp_max { get; set; } //Maximum temperature at the moment. This is maximal currently observed temperature.
        public double pressure { get; set; } //Atmospheric pressure.
        public double humidity { get; set; } //Humidity %.

    }
}

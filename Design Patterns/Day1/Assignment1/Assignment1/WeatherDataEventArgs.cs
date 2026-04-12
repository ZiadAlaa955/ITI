using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    public class WeatherDataEventArgs : EventArgs
    {
        public float temperature { get; set; }
        public float humidity { get; set; }
        public float pressure { get; set; }

        public WeatherDataEventArgs(float temp, float hum, float press)
        {
            temperature = temp;
            humidity = hum;
            pressure = press;
        }
    }
}

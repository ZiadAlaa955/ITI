using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment1
{
    #region Subject
    public class WeatherData
    {
        public event EventHandler<WeatherDataEventArgs> weatherChanged;

        public void MeasurementsChanged(WeatherDataEventArgs e)
        {
            weatherChanged?.Invoke(this, e);
        }

        public void SetMeasurements(float temperature, float humidity, float pressure)
        {
            WeatherDataEventArgs args = new WeatherDataEventArgs(temperature, humidity, pressure);
            
            MeasurementsChanged(args);
        }
    }
    #endregion

    public class CurrentConditionsDisplay
    {
        private TextBox _txtTemp;
        private TextBox _txtHum;

        public CurrentConditionsDisplay(WeatherData weatherData, TextBox txtTempBox, TextBox txtHumBox)
        {
            _txtTemp = txtTempBox;
            _txtHum = txtHumBox;

            weatherData.weatherChanged += HandleWeatherChanged;
        }

        private void HandleWeatherChanged(object sender, WeatherDataEventArgs e)
        {
            _txtTemp.Text = e.temperature.ToString();
            _txtHum.Text = e.humidity.ToString();
        }
    }

    public class StatisticsDisplay
    {
        private float _maxTemp = 0.0f;
        private float _minTemp = 200.0f;
        private float _tempSum = 0.0f;
        private int _numReadings = 0;

        private TextBox _txtStats;

        public StatisticsDisplay(WeatherData weatherData, TextBox txtStatsBox)
        {
            _txtStats = txtStatsBox;

            weatherData.weatherChanged += HandleWeatherChanged;
        }

        private void HandleWeatherChanged(object sender, WeatherDataEventArgs e)
        {
            _tempSum += e.temperature;
            _numReadings++;
            if (e.temperature > _maxTemp) _maxTemp = e.temperature;
            if (e.temperature < _minTemp) _minTemp = e.temperature;

            string statsText = $"Avg: {(_tempSum / _numReadings):F1} / Max: {_maxTemp} / Min: {_minTemp}";

            _txtStats.Text = statsText;
        }
    }

    public class ForecastDisplay
    {
        private float _currentPressure = 29.92f;
        private float _lastPressure;

        private TextBox _txtForecast;

        public ForecastDisplay(WeatherData weatherData, TextBox txtForecastBox)
        {
            _txtForecast = txtForecastBox;

            weatherData.weatherChanged += HandleWeatherChanged;
        }

        private void HandleWeatherChanged(object sender, WeatherDataEventArgs e)
        {
            _lastPressure = _currentPressure;
            _currentPressure = e.pressure;

            if (_currentPressure > _lastPressure)
            {
                _txtForecast.Text = "Improving weather on the way!";
            }
            else if (_currentPressure == _lastPressure)
            {
                _txtForecast.Text = "More of the same";
            }
            else
            {
                _txtForecast.Text = "Watch out for cooler, rainy weather";
            }
        }
    }

    public class HeatIndexDisplay
    {
        private TextBox _txtHeatIndex;

        public HeatIndexDisplay(WeatherData weatherData, TextBox txtHeatIndexBox)
        {
            _txtHeatIndex = txtHeatIndexBox;

            weatherData.weatherChanged += HandleWeatherChanged;
        }

        private void HandleWeatherChanged(object sender, WeatherDataEventArgs e)
        {
            float heatIndex = ComputeHeatIndex(e.temperature, e.humidity);

            _txtHeatIndex.Text = heatIndex.ToString("F2");
        }

        private float ComputeHeatIndex(float t, float rh)
        {
            return (float)((16.923 + (0.185212 * t)) + (5.37941 * rh) - (0.100254 * t * rh) +
                (0.00941695 * (t * t)) + (0.00728898 * (rh * rh)) + (0.000345372 * (t * t * rh)) -
                (0.000814971 * (t * rh * rh)) + (0.0000102102 * (t * t * rh * rh)) -
                (0.000038646 * (t * t * t)) + (0.0000291583 * (rh * rh * rh)) +
                (0.00000142721 * (t * t * t * rh)) + (0.000000197483 * (t * rh * rh * rh)) -
                (0.0000000218429 * (t * t * t * rh * rh)) + (0.000000000843296 * (t * t * rh * rh * rh)) -
                (0.0000000000481975 * (t * t * t * rh * rh * rh)));
        }
    }

}

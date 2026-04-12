using System.Net.NetworkInformation;

namespace Assignment1
{
    public partial class Form1 : Form
    {
        WeatherData weather = new WeatherData();

        CurrentConditionsDisplay currentDisplay;
        StatisticsDisplay statsDisplay;
        ForecastDisplay forecastDisplay;
        HeatIndexDisplay heatIndexDisplay;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            currentDisplay = new CurrentConditionsDisplay(weather, txtCurrentTemp, txtCurrentHum);
            statsDisplay = new StatisticsDisplay(weather, txtStatistics);
            forecastDisplay = new ForecastDisplay(weather, txtForecast);
            heatIndexDisplay = new HeatIndexDisplay(weather, txtHeatIndex);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            weather.SetMeasurements(80, 65, 30.4f);
        }
    }
}

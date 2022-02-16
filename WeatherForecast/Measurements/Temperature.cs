namespace WeatherForecast
{
    public class Temperature
    {
        private const decimal CelsiusToFahrenheitConvertion = 1.8m;
        private const decimal CelsiusToKelvinConvertion = 273.15m;

        public Temperature(decimal temperatureCelsius)
        {
            TemperatureCelsius = temperatureCelsius;

            if (temperatureCelsius < -273.15m)
            {
                throw new ArgumentOutOfRangeException("temperatureCelsius", "The temperature cannot be lover then absolute value");
            }

            if (temperatureCelsius > 100)
            {
                throw new ArgumentOutOfRangeException("temperatureCelsius", "The temperature cannot be higher then 100 degrees");
            }
        }

        public decimal TemperatureCelsius { get; private set; }
        public decimal TemperatureFahrenheit => TemperatureCelsius * CelsiusToFahrenheitConvertion + 32;
        public decimal TemperatureKelvin => TemperatureCelsius + CelsiusToKelvinConvertion;
    }
}
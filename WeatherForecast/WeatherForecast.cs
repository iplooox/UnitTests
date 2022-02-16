namespace WeatherForecast
{
    public class WeatherForecast
    {
        public WeatherForecast(City city, decimal temperatureCelsius, decimal windSpeed, decimal cloudCoverPercetage)
        {
            City = city;
            Temperature = new Temperature(temperatureCelsius);
            WindSpeed = new Speed(windSpeed);
            CloudCoverPercetage = new Percentage(cloudCoverPercetage);
        }

        public City City { get; private set; }
        public Temperature Temperature { get; private set; }
        public bool Freezing => Temperature.TemperatureCelsius < 0;
        public Speed WindSpeed { get; private set; }
        public decimal RainMilimeters { get; private set; }
        public Percentage CloudCoverPercetage { get; private set; }
    }
}
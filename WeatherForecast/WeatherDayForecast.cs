namespace WeatherForecast
{
    public class WeatherDayForecast : WeatherForecast
    {
        // There is a bug here can you find it?
        #region Hint
            // Look at the order of parameters in the base
        #endregion
        public WeatherDayForecast(DateTime from, DateTime to, City city, decimal temperatureCelsius, decimal windSpeed, decimal cloudCoverPercetage)
            : base(city, temperatureCelsius, cloudCoverPercetage, windSpeed)
        {
            FromDate = from;
            ToDate = to;
        }

        public DateTime FromDate { get; private set; }
        public DateTime ToDate { get; private set; }
    }
}
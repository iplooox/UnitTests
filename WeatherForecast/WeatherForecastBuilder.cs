namespace WeatherForecast
{
    public class WeatherForecastBuilder
    {
        private int Days { get; set; }
        private Temperature AverageTemperature { get; set; } = new Temperature(0);
        private Speed AverageWindSpeed { get; set; } = new Speed(0);
        private Percentage AverageCloudCoverPercetage { get; set; } = new Percentage(0);
        private decimal AverageRain { get; set; }
        private City City { get; set; } = City.None;

        public WeatherForecastBuilder GenerateXDaysOfForecast(int days)
        {
            Days = days;
            return this;
        }
        public WeatherForecastBuilder WithAverageTemperature(Temperature temperature)
        {
            AverageTemperature = temperature;
            return this;
        }
        public WeatherForecastBuilder WithAverageWindSpeed(Speed speed)
        {
            AverageWindSpeed = speed;
            return this;
        }
        public WeatherForecastBuilder WithAverageCloudCoverPercetage(Percentage percentage)
        {
            AverageCloudCoverPercetage = percentage;
            return this;
        }
        public WeatherForecastBuilder WithAverageRain(decimal rain)
        {
            AverageRain = rain;
            return this;
        }

        public WeatherForecastBuilder ForCity(City city)
        {
            City = city;
            return this;
        }

        public Forecast Build()
        {
            List<WeatherDayForecast> forecasts = new List<WeatherDayForecast>();

            DateTime today = DateTime.UtcNow;

            Random random = new Random();

            for (int i = 0; i < Days; i++)
            {
                forecasts.Add(new WeatherDayForecast(
                    GetDateAtMidnightAM(today, i),
                    GetDateAtMidnightPM(today, i),
                    City,
                    AverageTemperature.TemperatureCelsius + random.Next(-5, 5),
                    Math.Max(AverageWindSpeed.WindSpeedMeterPerSeconds + random.Next(-5, 20), 0),
                    Math.Min(AverageCloudCoverPercetage.Decimal + random.Next(-100, 100), 100)
                    
                ));
            }


            // There is a bug here can you find it? :)
            #region
            // One of the parameters is not being reset on build what happens when you build 2 forecasts with it?
            #endregion
            AverageTemperature = new Temperature(0);
            AverageWindSpeed = new Speed(0);
            AverageCloudCoverPercetage = new Percentage(0);
            City = City.None;
            return new Forecast(forecasts);
        }

        private DateTime GetDateAtMidnightAM(DateTime date, int daysToAdd)
        {
            return new DateTime(date.Year, date.Month, date.Day + daysToAdd, 0, 0, 1);
        }

        private DateTime GetDateAtMidnightPM(DateTime date, int daysToAdd)
        {
            return new DateTime(date.Year, date.Month, date.Day + daysToAdd, 23, 59, 59);
        }
    }
}
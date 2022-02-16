namespace WeatherForecast
{
    public class Speed
    {
        private const decimal MeterPerSecondToKmPerHourConvertion = 3.6m;

        public Speed(decimal speedInMeters)
        {
            WindSpeedMeterPerSeconds = speedInMeters;
        }

        public decimal WindSpeedMeterPerSeconds { get; private set; }
        public decimal WindSpeedKmPerHour => WindSpeedMeterPerSeconds * MeterPerSecondToKmPerHourConvertion;
    }
}
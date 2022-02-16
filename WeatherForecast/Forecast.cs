namespace WeatherForecast
{
    public class Forecast
    {
        public Forecast(List<WeatherDayForecast> weathersIn)
        {
            weathers = weathersIn;
        }

        private readonly List<WeatherDayForecast> weathers;

        public DateTime? StartDate => weathers.OrderBy(x => x.FromDate).SingleOrDefault()?.FromDate;
        public DateTime? EndDate => weathers.OrderByDescending(x => x.ToDate).SingleOrDefault()?.ToDate;
        public IReadOnlyCollection<WeatherDayForecast> Weathers => weathers;
        public void AddWeatherToForecast(WeatherDayForecast weather)
        {
            weathers.Add(weather);
        }

        public bool RemoveWeatherToForecast(WeatherDayForecast weather)
        {
            return weathers.Remove(weather);
        }

        public void ClearWeatherList()
        {
            weathers.Clear();
        }

        // There is a bug - validation missing here, let's see if you can catch it / fix it :)
        #region Hint
        //ArgumentException
        #endregion
        public WeatherDayForecast GetWeatherAtIndex(int index)
        {
            return weathers[index];
        }
    }
}
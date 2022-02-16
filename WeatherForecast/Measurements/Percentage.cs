namespace WeatherForecast
{
    public class Percentage
    {
        public Percentage(decimal percentage)
        {
            Decimal = percentage;
        }

        public decimal Decimal { get; private set; }
        public int Integer => (int)decimal.Round(Decimal);
        public override string ToString()
        {
            return $"{Decimal}%";
        }
    }
}
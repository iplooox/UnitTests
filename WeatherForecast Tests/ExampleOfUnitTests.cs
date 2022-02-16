using FluentAssertions;
using System;
using System.Collections.Generic;
using WeatherForecast;
using Xunit;

namespace WeatherForecast_Tests
{
    public class ExampleOfUnitTests
    {
        [Fact]
        public void Percentage_Convertions_Works()
        {
            // arrange
            Percentage? measure = new Percentage(50.5m);

            // assert
            measure.Decimal.Should().Be(50.5m);
            measure.Integer.Should().Be(50);
            measure.ToString().Should().Be("50,5%");
        }

        [Fact]
        public void Forecast_Clear_Weather_List_Clears()
        {
            // arrange
            List<WeatherDayForecast>? listOfForecasts = new List<WeatherDayForecast>
            {
                new WeatherDayForecast(DateTime.UtcNow, DateTime.UtcNow, City.None, 0,0,0)
            };

            Forecast forecast = new(listOfForecasts);

            // act
            Action act = () => forecast.ClearWeatherList();

            // assert
            act.Should().NotThrow();
            forecast.Weathers.Count.Should().Be(0);
        }
    }
}
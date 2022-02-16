# UnitTests
This is a c# / js project for training unit testing for a workshop targeting quality engineers.
We are expanding on the WeatherForecast provided by Microsoft example and adding complexity to it.

## Installation

Use git bash for pulling the project, or just download it as zip (Green button saying Code top right on this page)

```bash
git pull git@github.com:iplooox/UnitTests.git
```

## Usage

All the code to be tested in laying in "WeatherForecast" project

The tests should be written in "WeatherForecast Tests" project


### Example of a test for properties
```csharp
[Fact]
public void Percentage_Convertions_Works()
{
    var measure = new Percentage(50.5m);

    measure.Decimal.Should().Be(50.5m);
    measure.Integer.Should().Be(50);
    measure.ToString().Should().Be("50,5%");
}
```
### Example of a test for a method

```csharp
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
```

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

## License
[MIT](https://choosealicense.com/licenses/mit/)

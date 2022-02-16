import React, { Component } from 'react';

export class FetchData extends Component {
  static displayName = FetchData.name;

  constructor(props) {
    super(props);
    this.state = { forecasts: [], loading: true };
  }

  componentDidMount() {
    this.populateWeatherData();
  }

  static cityEnumToString(cityEnumVal) {
    var cityMap = { 
      0: "none",
      1: "Copenhagen",
      2: "Gdansk",
      3: "Makati",
      4: "New York",
      5: "Dubai",
     }

    return cityMap[cityEnumVal];
  }

  static formatDate(dateIn)
  {
    const date = new Date(dateIn);

    return `${date.getUTCDate() + 1}/${date.getUTCMonth() + 1}/${date.getUTCFullYear()}`
  }

  static renderForecastsTable(forecasts) {
    return (
      <table className='table table-striped' aria-labelledby="tabelLabel">
        <thead>
          <tr>
            <th>Date</th>
            <th>City</th>
            <th>Temp. (C)</th>
            <th>Temp. (F)</th>
            <th>Temp. (K)</th>
            <th>Wind speed (m/s)</th>
            <th>Wind speed (km/h)</th>
            <th>Freezing</th>
            <th>Cloud coverage percentage</th>
            <th>Rain milimeters</th>
          </tr>
        </thead>
        <tbody>
          {forecasts.map(forecast =>
            <tr key={forecast.fromDate}>
              <td>{this.formatDate(forecast.fromDate)}</td>
              <td>{this.cityEnumToString(forecast.city)}</td>
              <td>{forecast.temperature.temperatureCelsius}</td>
              <td>{forecast.temperature.temperatureFahrenheit}</td>
              <td>{forecast.temperature.temperatureKelvin}</td>
              <td>{forecast.windSpeed.windSpeedMeterPerSeconds}</td>
              <td>{forecast.windSpeed.windSpeedKmPerHour}</td>
              <td>{forecast.freezing ? 'true' : 'false'}</td>
              <td>{forecast.cloudCoverPercetage.integer}%</td>
              <th>{forecast.rainMilimeters}</th>
            </tr>
          )}
        </tbody>
      </table>
    );
  }

  render() {
    let contents = this.state.loading
      ? <p><em>Loading...</em></p>
      : FetchData.renderForecastsTable(this.state.forecasts);

    return (
      <div>
        <h1 id="tabelLabel" >Weather forecast</h1>
        <p>This component demonstrates fetching data from the server.</p>
        {contents}
      </div>
    );
  }

  async populateWeatherData() {
    const response = await fetch('weatherforecast');
    const data = await response.json();
    this.setState({ forecasts: data, loading: false });
  }
}

import React from 'react';
import { connect } from 'react-redux';

class OneDayForecast extends React.PureComponent {
  render() {
    var elements = [];
    var element;
    var headerElement;
    headerElement = (
      <div className="_headerElement">
        <h2>Date: {this.props.forecast.forecasts[0].date}</h2>
        <h2>
          Country: {this.props.forecast.geo_object.country.name},
          {this.props.forecast.geo_object.province.name}
        </h2>
        <h2>City: {this.props.forecast.geo_object.locality.name}</h2>
      </div>
    );

    elements = elements.concat(headerElement);

    for (let i = 0; i < 24; i++) {
      element = '';
      element = (
        <div className="forecastOfDay">
          <div className="forecastOfDay__weather">
            <div className="weather-info">
              <p>Time {i}:00</p>
              <p>
                Temperature: {this.props.forecast.forecasts[0].hours[i].temp} C
              </p>
              <p>
                Pressure:
                {this.props.forecast.forecasts[0].hours[i].pressure_mm} mm
              </p>
              <p>
                Wind speed:
                {this.props.forecast.forecasts[0].hours[i].wind_speed} m/s
              </p>
              <p>
                Wind direction:
                {this.props.forecast.forecasts[0].hours[i].wind_dir}
              </p>
              <h2>
                Sunrise: {this.props.forecast.forecasts[0].sunrise}, Sunset:
                {this.props.forecast.forecasts[0].sunset}
              </h2>
            </div>
            <div className="weather-icon">
              <img
                className="icon"
                src={`https://yastatic.net/weather/i/icons/funky/dark/${this.props.forecast.forecasts[0].hours[i].icon}.svg`}
                alt="icon"
              />
            </div>
          </div>
        </div>
      );
      elements = elements.concat(element);
    }

    return elements.map((item, index) => (
      <div className="forecastOfDays" key={index}>
        {item}
      </div>
    ));
  }
}

function mapStateToProps(state) {
  return {
    forecastLimit: state.forecastLimit,
    forecast: state.forecast,
  };
}

export default connect(mapStateToProps)(OneDayForecast);

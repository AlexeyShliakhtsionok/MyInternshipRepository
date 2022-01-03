import React from 'react';
import { connect } from 'react-redux';

class OneDayForecast extends React.PureComponent {
  render() {
    var element;
    var icon = `https://yastatic.net/weather/i/icons/funky/dark/${this.props.forecast.forecasts[0].parts.day.icon}.svg`;
    console.log(this.props.forecast);
    element = (
      <div className="forecastOfDay">
        <div>
          <h2>
            Country: {this.props.forecast.geo_object.country.name},
            {this.props.forecast.geo_object.province.name}
          </h2>
          <h2>City: {this.props.forecast.geo_object.locality.name}</h2>
          <h2>Date: {this.props.forecast.forecasts[0].date}</h2>
          <h2 className="__icon">
            Temperature:
            {this.props.forecast.forecasts[0].parts.day.temp_avg.toFixed(1)}
            , C
            <img className="icon" src={icon} alt="icon" />
          </h2>
        </div>
      </div>
    );
    return element;
  }
}

function mapStateToProps(state) {
  return {
    forecastLimit: state.forecastLimit,
    forecast: state.forecast,
  };
}

export default connect(mapStateToProps)(OneDayForecast);

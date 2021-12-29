import React from 'react';
import { connect } from 'react-redux';
import './oneDayForecast.css';

class OneDayForecast extends React.PureComponent {
  render() {
    var element;
    var index = this.props.index;
    var temp =
      this.props.forecast.forecasts[index].parts.day.temp_avg.toFixed(1);

    var icon = `https://yastatic.net/weather/i/icons/funky/dark/${this.props.forecast.forecasts[0].parts.day.icon}.svg`;

    element = (
      <div className="forecastOfDay">
        <div>
          <h2>
            Country: {this.props.forecast.geo_object.country.name},{' '}
            {this.props.forecast.geo_object.province.name}{' '}
          </h2>
          <h2>City: {this.props.forecast.geo_object.locality.name}</h2>
          <h2>Date: {this.props.forecast.forecasts[index].date}</h2>
          <h2 className="__icon">
            Temperature: {temp}, C
            <img className="icon" src={icon} alt="icon" />
          </h2>
        </div>
      </div>
    );

    return element;
  }
}

function mapStateToProps(state) {
  return {};
}

function mapDispatchToProps(dispatch) {
  return {};
}

export default connect()(OneDayForecast);

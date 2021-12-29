import React from 'react';
import { connect } from 'react-redux';
import './threeDaysForecast.css';

class ThreeDaysForecast extends React.PureComponent {
  render() {
    var element;
    var date = [];
    var temp = [];
    var icon = [];
    var sunrise = [];
    var sunset = [];

    for (let i = 0; i < this.props.forecastLimit; i++) {
      date.push(this.props.forecast.forecasts[i].date);
      temp.push(this.props.forecast.forecasts[i].parts.day.temp_avg.toFixed(1));
      icon.push(
        `https://yastatic.net/weather/i/icons/funky/dark/${this.props.forecast.forecasts[i].parts.day.icon}.svg`,
      );
      sunrise.push(this.props.forecast.forecasts[i].sunrise);
      sunset.push(this.props.forecast.forecasts[i].sunset);
    }

    element = (
      <div className="forecastOfDay">
        <div>
          <h2>
            Country: {this.props.forecast.geo_object.country.name},{' '}
            {this.props.forecast.geo_object.province.name}{' '}
          </h2>
          <h2>City: {this.props.forecast.geo_object.locality.name}</h2>
          <h2>Date: {date[0]}</h2>
          <h2>
            Sunrise: {sunrise[0]}, Sunset:
            {sunset[0]}
          </h2>
          <h2 className="__icon">
            Temperature: {temp[0]}, C
            <img className="icon" src={icon[0]} alt="icon" />
          </h2>
        </div>
        <div>
          <h2>
            Country: {this.props.forecast.geo_object.country.name},{' '}
            {this.props.forecast.geo_object.province.name}{' '}
          </h2>
          <h2>City: {this.props.forecast.geo_object.locality.name}</h2>
          <h2>Date: {date[1]}</h2>
          <h2>
            Sunrise: {sunrise[1]}, Sunset:
            {sunset[1]}
          </h2>
          <h2 className="__icon">
            Temperature: {temp[1]}, C
            <img className="icon" src={icon[1]} alt="icon" />
          </h2>
        </div>
        <div>
          <h2>
            Country: {this.props.forecast.geo_object.country.name},{' '}
            {this.props.forecast.geo_object.province.name}{' '}
          </h2>
          <h2>City: {this.props.forecast.geo_object.locality.name}</h2>
          <h2>Date: {date[2]}</h2>
          <h2>
            Sunrise: {sunrise[2]}, Sunset:
            {sunset[2]}
          </h2>
          <h2 className="__icon">
            Temperature: {temp[2]}, C
            <img className="icon" src={icon[2]} alt="icon" />
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

export default ThreeDaysForecast;

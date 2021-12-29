import React from 'react';
import OneDayForecast from './forecasts/oneDay/oneDayForecast.js';
import ThreeDaysForecast from './forecasts/threeDays/threeDaysForecast.js';
import SevenDaysForecast from './forecasts/sevenDays/sevenDaysForecast.js';
import { connect } from 'react-redux';
import './forecast.css';

class Forecast extends React.PureComponent {
  render() {
    switch (this.props.forecastLimit) {
      case '1':
        return (
          <div className="__forecast">
            <OneDayForecast limit={this.props.forecastLimit} />
          </div>
        );
      case '3':
        return (
          <div className="__forecast">
            <ThreeDaysForecast limit={this.props.forecastLimit} />
          </div>
        );
      case '7':
        return (
          <div className="__forecast">
            <SevenDaysForecast limit={this.props.forecastLimit} />
          </div>
        );
      default:
        break;
    }
  }
}

function mapStateToProps(state) {
  return {};
}

function mapDispatchToProps(dispatch) {
  return {};
}

export default connect()(Forecast);

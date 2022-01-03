import React from 'react';
import { connect } from 'react-redux';
import OneDayForecast from './oneDayForecast.js';
import ThreeDaysForecast from './threeDaysForecast.js';
import SevenDaysForecast from './sevenDaysForecast.js';

class Forecast extends React.PureComponent {
  render() {
    switch (this.props.forecastLimit) {
      case '1':
        return (
          <div className="__forecast">
            <OneDayForecast />
          </div>
        );
      case '3':
        return (
          <div className="__forecast">
            <ThreeDaysForecast forecast={this.props.forecast} />
          </div>
        );
      case '7':
        return (
          <div className="__forecast">
            <SevenDaysForecast />
          </div>
        );
      default:
        return (
          <div className="__forecast">
            <p>NothingToDisplay</p>
          </div>
        );
    }
  }
}

function mapStateToProps(state) {
  return {
    forecast: state.forecast,
    forecastLimit: state.forecastLimit,
    userInput: state.userInput,
  };
}

export default connect(mapStateToProps)(Forecast);

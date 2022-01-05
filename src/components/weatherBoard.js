import React from 'react';
import Logotype from './logotype.js';
import SearchBar from './searchBar.js';
import { connect } from 'react-redux';
import Forecast from './forecast';

class WeatherBoard extends React.PureComponent {
  render() {
    return (
      <div className="weatherBoard">
        <div className="weatherBoard__header">
          <Logotype />
          <SearchBar />
        </div>
        <div className="weatherBoard__forecastArea">
          <Forecast />
        </div>
      </div>
    );
  }
}

function mapStateToProps(state) {
  return {
    forecast: state.forecast,
    limit: state.forecastLimit,
    userInput: state.userInput,
  };
}

function mapDispatchToProps(dispatch) {
  return {};
}

export default connect(mapStateToProps, mapDispatchToProps)(WeatherBoard);

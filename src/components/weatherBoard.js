import React from 'react';
import Logotype from './logotype.js';
import SearchBar from './searchBar.js';
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

export default WeatherBoard;

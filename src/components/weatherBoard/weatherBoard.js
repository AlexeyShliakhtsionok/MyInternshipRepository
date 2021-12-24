import React from 'react';
import Logotype from './__header/_logotype/_logotype.js';
import SearchBar from './__header/_searchBar/_searchBar.js';
import Forecast from './__forecast/forecast.js';
import './weatherBoard.css';

class WeatherBoard extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      forecastLimit: '',
      userInput: '',
    };
  }

  getForecastInfo = (limit, input) => {
    this.setState({ forecastLimit: limit, userInput: input });
  };

  render() {
    return (
      <div className="weatherBoard">
        <div className="weatherBoard__header">
          <Logotype />
          <SearchBar getForecastInfo={this.getForecastInfo} />
        </div>
        <div className="weatherBoard__forecastArea">
          <Forecast forecastLimit={this.forecastLimit} city={this.userInput} />
        </div>
      </div>
    );
  }
}
export default WeatherBoard;

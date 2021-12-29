import React from 'react';
import Logotype from '../weatherBoard/header/searchBar/logotype/logotype.js';
import SearchBar from './header/searchBar/searchBar.js';
import './weatherBoard.css';
import { connect } from 'react-redux';
class WeatherBoard extends React.PureComponent {
  render() {
    return (
      <div className="weatherBoard">
        <div className="weatherBoard__header">
          <Logotype />
          <SearchBar />
        </div>
        <div className="weatherBoard__forecastArea">{/* <Forecast /> */}</div>
      </div>
    );
  }
}

function mapStateToProps(state) {
  return {
    forecastLimit: state.forecastLimit,
    userInput: state.userInput,
    locationName: state.locationName,
    latitude: state.latitude,
    longitude: state.longitude,
    coordinates: state.coordinates,
  };
}

function mapDispatchToProps(dispatch) {
  return {};
}

export default connect(mapStateToProps, mapDispatchToProps)(WeatherBoard);

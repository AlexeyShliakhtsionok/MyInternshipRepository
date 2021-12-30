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
    coordinates: state.coordinates,
    latitude: state.latitude,
    longitude: state.longitude,
  };
}

function mapDispatchToProps(dispatch) {
  return {};
}

export default connect(mapStateToProps, mapDispatchToProps)(WeatherBoard);

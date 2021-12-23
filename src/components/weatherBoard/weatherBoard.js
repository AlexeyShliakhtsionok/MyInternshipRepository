import React from 'react';
import Logotype from './__header/_logotype/_logotype.js';
import SearchBar from './__header/_searchBar/_searchBar.js';
import './weatherBoard.css';

const WeatherBoard = () => {
  return (
    <div className="weatherBoard">
      <div className="weatherBoard__header">
        <Logotype />
        <SearchBar />
      </div>
      <div className="weatherBoard__forecastArea"></div>
    </div>
  );
};

export default WeatherBoard;

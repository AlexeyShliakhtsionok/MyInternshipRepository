import React from 'react';
import ReactDOM from 'react-dom';
import './index.css';
import WeatherBoard from './components/weatherBoard/weatherBoard';

ReactDOM.render(
  <React.StrictMode>
    <WeatherBoard />
  </React.StrictMode>,
  document.getElementById('root'),
);

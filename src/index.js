import React from 'react';
import ReactDOM from 'react-dom';
import { createStore, applyMiddleware } from 'redux';
import { Provider } from 'react-redux';
import WeatherBoard from './components/weatherBoard/weatherBoard';
import reducer from './Redux/reducer';
import reduxThunk from 'redux-thunk';
import getWeather from './yandexWeatherAPIRequest/getWeather';
import './index.css';

const store = createStore(reducer, applyMiddleware(reduxThunk));

const app = (
  <Provider store={store}>
    <React.StrictMode>
      <WeatherBoard />
    </React.StrictMode>
  </Provider>
);

ReactDOM.render(app, document.getElementById('root'));

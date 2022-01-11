import React from 'react';
import ReactDOM from 'react-dom';
import { createStore, applyMiddleware } from 'redux';
import { Provider } from 'react-redux';
import reducer from './components/Redux/reducer.js';
import thunk from 'redux-thunk';
import WeatherBoard from './components/weatherBoard';
import './index.css';

const store = createStore(reducer, applyMiddleware(thunk));

const app = (
  <Provider store={store}>
    <React.StrictMode>
      <WeatherBoard />
    </React.StrictMode>
  </Provider>
);

ReactDOM.render(app, document.getElementById('root'));

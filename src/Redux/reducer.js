import getWeather from '../yandexWeatherAPIRequest/getWeather';
import { click, onRBChange, onUIChange, addLimit } from './actions/actionTypes';

const initialState = {
  userInput: '',
  locationName: 'Minsk',
  forecastLimit: '7',
  latitude: '53.9006011',
  longitude: '27.558972',
  coordinates: [],
  forecast: '',
};

export default function reducer(state = initialState, action) {
  switch (action.type) {
    case click:
      return {
        ...state,
        coordinates: action.payload,
        latitude: state.coordinates[0],
        longitude: state.coordinates[1],
      };

    case addLimit:
      return state;

    case onUIChange:
      return { ...state, userInput: action.payload };

    case onRBChange:
      return { ...state, forecastLimit: action.payload };
    default:
      return state;
  }
}

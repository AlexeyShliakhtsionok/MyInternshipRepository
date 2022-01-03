import {
  click,
  onRBChange,
  onUIChange,
  addLimit,
} from './actions/actionTypes.js';

const initialState = {
  currentLocation: 'Minsk',
  userInput: '',
  forecastLimit: '7',
  forecast: '',
  requestCompleted: false,
};

export default function reducer(state = initialState, action) {
  switch (action.type) {
    case click:
      console.log('#2 Payload: ', action.payload);
      return {
        ...state,
        forecast: action.payload,
        requestCompleted: true,
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

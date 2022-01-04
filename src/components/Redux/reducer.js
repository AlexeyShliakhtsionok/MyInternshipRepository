import {
  click,
  onRBChange,
  onUIChange,
  addLimit,
} from './actions/actionTypes.js'

const initialState = {
  currentLocation: 'Minsk',
  userInput: '',
  forecastLimit: '7',
  forecast: '',
  firstRender: true,
}

export default function reducer(state = initialState, action) {
  switch (action.type) {
    case click:
      return {
        ...state,
        forecast: action.payload,
        firstRender: false,
      }

    case addLimit:
      return state

    case onUIChange:
      return { ...state, userInput: action.payload }

    case onRBChange:
      return {
        ...state,
        forecastLimit: action.payload,
      }

    default:
      return state
  }
}

import { onUIChange, onRBChange, addLimit, click } from './actionTypes';
import getGeoCoordinates from '../../GoogleGeocoderAPI/geocoder.js';
import { callbackForGeocode } from '../../GoogleGeocoderAPI/geocoder.js';

export function userInputChange(value) {
  return { type: onUIChange, payload: value };
}

export function radioButtonChange(value) {
  return { type: onRBChange, payload: value };
}

export function setForecastLimit() {
  return { type: addLimit };
}

export function getWeatherOnClick(value) {
  var arr = [];
  const coordinates = getGeoCoordinates(value, callbackForGeocode).then(
    (data) => {
      arr.push(data[0], data[1]);
      console.log(arr);
    },
  );
  return { type: click, payload: arr };
}

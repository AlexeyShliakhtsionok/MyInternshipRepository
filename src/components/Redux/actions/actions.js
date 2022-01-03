import { onUIChange, onRBChange, addLimit, click } from './actionTypes';
import Geocode from 'react-geocode';

Geocode.setApiKey('AIzaSyCnT9OyZBakiha93EwmXeZRl25AHdPiTVE');
Geocode.setLanguage('ru');
Geocode.setRegion('es');
Geocode.setLocationType('ROOFTOP');

export function userInputChange(value) {
  return { type: onUIChange, payload: value };
}

export function radioButtonChange(value) {
  return { type: onRBChange, payload: value };
}

// export function setForecastLimit() {
//   return { type: addLimit };
// }

export function getForecast(value, limit) {
  return (dispatch) => {
    let resultObj = {};
    let coordinatesArray = [];
    const coordinates = Geocode.fromAddress(value)
      .then((response) => {
        let coordinatesObj = response.results[0].geometry.location;
        resultObj.coordinates = coordinatesObj;
        coordinatesArray.push(Object.values(resultObj.coordinates));
        return coordinatesArray[0];
      })
      .then((value) => {
        let latitude = value[0];
        let longtitude = value[1];
        const requestURL = `https://cors-anywhere.herokuapp.com/https://api.weather.yandex.ru/v2/forecast?lat=${latitude}&lon=${longtitude}&limit=${limit}&hours=false&extra=false`;
        fetch(requestURL, {
          method: 'GET',
          headers: new Headers({
            'X-Yandex-API-Key': 'e5408689-c119-4933-af94-2bc551b71fe6',
          }),
        }).then(async (response) => {
          const data = await response.json();
          dispatch(testFunct(data));
        });
      });
  };
}

export function testFunct(obj) {
  return { type: click, payload: obj };
}

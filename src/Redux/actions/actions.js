import { onUIChange, onRBChange, addLimit, click } from './actionTypes';
import Geocode from 'react-geocode';

Geocode.setApiKey('AIzaSyCnT9OyZBakiha93EwmXeZRl25AHdPiTVE');
Geocode.setLanguage('ru');
Geocode.setRegion('es');
Geocode.setLocationType('ROOFTOP');

async function getGeoCoordinates(locationName) {
  const coordinates = await Geocode.fromAddress(locationName).then(
    (response) => {
      return response.results[0].geometry.location;
    },
  );
  return coordinates;
}

export function userInputChange(value) {
  return { type: onUIChange, payload: value };
}

export function radioButtonChange(value) {
  return { type: onRBChange, payload: value };
}

export function setForecastLimit() {
  return { type: addLimit };
}

export async function getWeatherOnClick(value) {
  let resultObj = {};
  let coordinatesArray = [];

  await getGeoCoordinates(value).then((data) => {
    console.log('1: ', data);
    resultObj.coordinates = data;
    coordinatesArray.push(Object.values(resultObj.coordinates));
  });

  console.log('2: ', resultObj);
  console.log('3', coordinatesArray);
  return { type: click, payload: coordinatesArray };
}

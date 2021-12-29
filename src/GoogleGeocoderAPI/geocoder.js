import Geocode from 'react-geocode';

Geocode.setApiKey('AIzaSyCnT9OyZBakiha93EwmXeZRl25AHdPiTVE');
Geocode.setLanguage('ru');
Geocode.setRegion('es');
Geocode.setLocationType('ROOFTOP');

async function getGeoCoordinates(locationName, callback) {
  var result;
  await Geocode.fromAddress(locationName, result).then((response) => {
    const { lat, lng } = response.results[0].geometry.location;
    result = [lat, lng];
  });
  return callback(result);
}

function callbackForGeocode(data) {
  return data;
}

export default getGeoCoordinates;
export { callbackForGeocode };

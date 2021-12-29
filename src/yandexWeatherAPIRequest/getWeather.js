async function getWeather(latitude, longitude, forecastLimit) {
  const requestURL = `https://cors-anywhere.herokuapp.com/https://api.weather.yandex.ru/v2/forecast?lat=${latitude}&lon=${longitude}&limit=${forecastLimit}&hours=false&extra=false`;
  const response = await fetch(requestURL, {
    method: 'GET',
    headers: new Headers({
      'X-Yandex-API-Key': 'e5408689-c119-4933-af94-2bc551b71fe6',
    }),
  });
  return response.json().then((data) => {
    // console.log(data);
    return data;
  });
}
export default getWeather;

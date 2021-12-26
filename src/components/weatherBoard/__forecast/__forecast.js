import React from 'react';
import Geocode from 'react-geocode';
import ForecastOfDay from './_forecastOfDay/forecastOfDay.js';

Geocode.setApiKey('AIzaSyCnT9OyZBakiha93EwmXeZRl25AHdPiTVE');
Geocode.setLanguage('ru');
Geocode.setRegion('es');
Geocode.setLocationType('ROOFTOP');
class Forecast extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      limitValue: '',
      forecast: '',
      lat: '',
      lon: '',
      errorResponse: false,
      prevState: '',
    };
  }

  componentDidUpdate() {
    if (
      this.state.prevState !==
      this.props.userInput + this.props.forecastLimit
    ) {
      Geocode.fromAddress(this.props.userInput).then(
        async (response) => {
          const { lat, lng } = response.results[0].geometry.location;
          let result = [lat, lng];
          this.setState({
            lat: result[0],
            lon: result[1],
          });
        },
        (error) => {
          console.error(error);
          this.setState({ errorResponse: !this.state.errorResponse });
        },
      );

      this.setState({
        prevState: this.props.userInput + this.props.forecastLimit,
      });

      const xhr = new XMLHttpRequest();
      const requestURL = `https://cors-anywhere.herokuapp.com/https://api.weather.yandex.ru/v2/forecast?lat=${this.state.lat}&lon=${this.state.lon}&extra=true`;

      xhr.open('GET', `${requestURL}`, true);

      xhr.setRequestHeader(
        'X-Yandex-API-Key',
        'e5408689-c119-4933-af94-2bc551b71fe6',
      );

      xhr.onload = () => {
        this.setState({ forecast: JSON.parse(xhr.response) });
      };
      xhr.send();
    }
  }

  render() {
    return (
      <div>
        <ForecastOfDay forecast={this.state.forecast} />
      </div>
    );
  }
}

export default Forecast;

// if (this.state.limitValue === 1) {
//   console.log('one');
//   test = (
//     <div>
//       <p>1</p>
//       <ForecastOfDay date={this.state.forecast.forecasts[0].date} />
//     </div>
//   );
// } else if (this.state.limitValue === 3) {
//   test = (
//     <div>
//       <p>3</p>
//       <ForecastOfDay date={this.state.forecast.forecasts[0].date} />
//       <ForecastOfDay date={this.state.forecast.forecasts[1].date} />
//       <ForecastOfDay date={this.state.forecast.forecasts[2].date} />
//     </div>
//   );
// } else if (this.state.limitValue === 7) {
//   test = (
//     <div>
//       <p>7</p>
//       <ForecastOfDay />
//       <ForecastOfDay />
//       <ForecastOfDay />
//       <ForecastOfDay />
//       <ForecastOfDay />
//       <ForecastOfDay />
//       <ForecastOfDay />
//     </div>
//   );
// }

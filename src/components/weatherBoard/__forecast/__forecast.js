import React from 'react';
import Geocode from 'react-geocode';
import ForecastOfDay from './_forecastOfDay/forecastOfDay.js';
import './__forecast.css';

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
    var result;
    if (
      this.state.prevState !==
      this.props.userInput + this.props.forecastLimit
    ) {
      Geocode.fromAddress(this.props.userInput).then(
        (response) => {
          const { lat, lng } = response.results[0].geometry.location;
          result = [lat, lng];

          const xhr = new XMLHttpRequest();
          console.log(result);
          const requestURL = `https://cors-anywhere.herokuapp.com/https://api.weather.yandex.ru/v2/forecast?lat=${result[0]}&lon=${result[1]}&limit=${this.state.limitValue}&hours=false&extra=false`;

          xhr.open('GET', `${requestURL}`, true);

          xhr.setRequestHeader(
            'X-Yandex-API-Key',
            'e5408689-c119-4933-af94-2bc551b71fe6',
          );

          xhr.onload = () => {
            console.log(JSON.parse(xhr.response));
            this.setState({ forecast: JSON.parse(xhr.response) });
          };

          xhr.send();
        },
        (error) => {
          console.error(error);
          this.setState({ errorResponse: !this.state.errorResponse });
        },
      );

      this.setState({
        prevState: this.props.userInput + this.props.forecastLimit,
      });
    }
  }

  render() {
    if (this.props.forecastLimit === '') {
      return (
        <div className="__forecast">
          <ForecastOfDay forecast={this.state.forecast} />
        </div>
      );
    } else if (this.props.forecastLimit === '1') {
      return (
        <div className="__forecast">
          <ForecastOfDay forecast={this.state.forecast} index="0" />
        </div>
      );
    } else if (this.props.forecastLimit === '3') {
      return (
        <div className="__forecast">
          <ForecastOfDay forecast={this.state.forecast} index="0" />
          <ForecastOfDay forecast={this.state.forecast} index="1" />
          <ForecastOfDay forecast={this.state.forecast} index="2" />
        </div>
      );
    } else if (this.props.forecastLimit === '7') {
      return (
        <div className="__forecast">
          <ForecastOfDay forecast={this.state.forecast} index="0" />
          <ForecastOfDay forecast={this.state.forecast} index="1" />
          <ForecastOfDay forecast={this.state.forecast} index="2" />
          <ForecastOfDay forecast={this.state.forecast} index="3" />
          <ForecastOfDay forecast={this.state.forecast} index="4" />
          <ForecastOfDay forecast={this.state.forecast} index="5" />
          <ForecastOfDay forecast={this.state.forecast} index="6" />
        </div>
      );
    }
  }
}

export default Forecast;

import React from 'react';
import Geocode from 'react-geocode';
import getWeather from './getWeather/getWeather';

Geocode.setApiKey('AIzaSyCnT9OyZBakiha93EwmXeZRl25AHdPiTVE');
Geocode.setLanguage('ru');
Geocode.setRegion('es');
Geocode.setLocationType('ROOFTOP');

class Forecast extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      limitValue: '',
      userInput: '',
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
        (response) => {
          const { lat, lng } = response.results[0].geometry.location;
          let result = [lat, lng];
          this.setState({ lon: result[0], lng: result[1] });
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
    return <div></div>;
  }
}

export default Forecast;

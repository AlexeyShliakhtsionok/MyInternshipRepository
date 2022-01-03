import React from 'react';
import { connect } from 'react-redux';

class ThreeDaysForecast extends React.PureComponent {
  render() {
    var elements = [];
    var element;

    for (let i = 0; i < this.props.forecastLimit; i++) {
      element = '';
      element = (
        <div className="forecastOfDay">
          <div>
            <h2>
              Country: {this.props.forecast.geo_object.country.name},
              {this.props.forecast.geo_object.province.name}
            </h2>
            <h2>City: {this.props.forecast.geo_object.locality.name}</h2>
            <h2>Date: {this.props.forecast.forecasts[i].date}</h2>
            <h2>
              Sunrise: {this.props.forecast.forecasts[i].sunrise}, Sunset:
              {this.props.forecast.forecasts[i].sunset}
            </h2>
            <h2 className="__icon">
              Temperature:
              {this.props.forecast.forecasts[i].parts.day.temp_avg.toFixed(1)},
              C
              <img
                className="icon"
                src={`https://yastatic.net/weather/i/icons/funky/dark/${this.props.forecast.forecasts[i].parts.day.icon}.svg`}
                alt="icon"
              />
            </h2>
          </div>
        </div>
      );
      console.log('Очередной элемент: ', element);
      elements = elements.concat(element);
      console.log('Результирующий элемент: ', elements);
    }

    return elements.map((item, index) => <div key={index}>{item}</div>);
  }
}

function mapStateToProps(state) {
  return {
    forecast: state.forecast,
    forecastLimit: state.forecastLimit,
  };
}

export default connect(mapStateToProps)(ThreeDaysForecast);

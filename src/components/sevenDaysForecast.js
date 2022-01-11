import React from 'react';
import { connect } from 'react-redux';

class SevenDaysForecast extends React.PureComponent {
  render() {
    var elements = [];
    var headerElement;
    var element;

    if (this.props.firstRender) {
      return (
        <div>
          <p>Please, wait a second...</p>
        </div>
      );
    }

    headerElement = (
      <div className="_headerElement">
        <h2>
          Country: {this.props.forecast.geo_object.country.name},
          {this.props.forecast.geo_object.province.name}
        </h2>
        <h2>City: {this.props.forecast.geo_object.locality.name}</h2>
      </div>
    );

    elements = elements.concat(headerElement);

    for (let i = 0; i < this.props.forecastLimit; i++) {
      element = '';
      element = (
        <div className="forecastOfDay">
          <div>
            <h2>Date: {this.props.forecast.forecasts[i].date}</h2>
            <h2>
              Temperature:
              {this.props.forecast.forecasts[i].parts.day.temp_avg.toFixed(1)},
              C
            </h2>
          </div>
          <div>
            <img
              className="icon"
              src={`https://yastatic.net/weather/i/icons/funky/dark/${this.props.forecast.forecasts[i].parts.day.icon}.svg`}
              alt="icon"
            />
          </div>
        </div>
      );
      elements = elements.concat(element);
    }
    console.log(elements);
    return elements.map((item, index) => (
      <div className="forecastOfDays" key={index}>
        {item}
      </div>
    ));
  }
}

function mapStateToProps(state) {
  return {
    forecast: state.forecast,
    forecastLimit: state.forecastLimit,
    firstRender: state.firstRender,
  };
}

export default connect(mapStateToProps)(SevenDaysForecast);

import React from 'react';
import './forecastOfDay.css';
class ForecastOfDay extends React.Component {
  constructor(props) {
    super(props);
    this.state = { date: 'some date' };
  }

  render() {
    var element;
    var index = this.props.index;

    if (this.props.forecast !== '') {
      var temp =
        this.props.forecast.forecasts[index].parts.day.temp_avg.toFixed(1);

      var icon = `https://yastatic.net/weather/i/icons/funky/dark/${this.props.forecast.forecasts[index].parts.day.icon}.svg`;

      element = (
        <div className="forecastOfDay">
          <div>
            <h2>Date: {this.props.forecast.forecasts[index].date}</h2>
            <h2>
              Sunrise: {this.props.forecast.forecasts[index].sunrise}, Sunset:
              {this.props.forecast.forecasts[index].sunset}
            </h2>
            <h2>Temperature: {temp}, C</h2>
          </div>
          <div>
            <img src={icon} alt="icon" />
          </div>
        </div>
      );
    } else {
      element = <div></div>;
    }

    return element;
  }
}
export default ForecastOfDay;

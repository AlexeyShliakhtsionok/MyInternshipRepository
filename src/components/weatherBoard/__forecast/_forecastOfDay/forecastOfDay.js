import React from 'react';

class ForecastOfDay extends React.Component {
  constructor(props) {
    super(props);
    this.state = { date: 'some date' };
  }

  render() {
    var element;
    if (this.props.forecast) {
      element = (
        <div>
          <h2>Date: {this.props.forecast.forecasts[0].date}</h2>
          <div>
            <h3>Temperature: {}</h3>
          </div>
        </div>
      );
    } else {
      element = (
        <div>
          <h2>Date: {this.state.date}</h2>
          <div>
            <h3>Temperature: {}</h3>
          </div>
        </div>
      );
    }

    return element;
  }
}
export default ForecastOfDay;

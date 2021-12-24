import React from 'react';
import './radioBtn.css';

class RadioButton extends React.Component {
  constructor(props) {
    super(props);
    this.state = { forecastLimit: '' };
    this.stateHandler = this.stateHandler.bind(this);
  }

  stateHandler = () => {
    this.setState({ forecastLimit: this.props.limit }, () => {
      this.props.getForecastLimit(this.state.forecastLimit);
    });
  };

  render() {
    return (
      <div>
        <h3>{this.props.title}</h3>
        <input
          type="radio"
          className="radio"
          name="forecastLimit"
          value={this.props.limit}
          onChange={this.stateHandler}
        />
      </div>
    );
  }
}

export default RadioButton;

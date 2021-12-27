import React from 'react';
import InputField from './input/input.js';
import RadioButton from './radioBtn/radioBtn.js';
import './_searchBar.css';

class SearchBar extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      forecastLimit: '',
      userInput: '',
    };
  }

  getForecastLimit = (value) => {
    this.setState({ forecastLimit: value });
  };

  getUserInput = (value) => {
    this.setState({ userInput: value });
  };

  render() {
    return (
      <div className="_searchBar">
        <div className="RadioButton">
          <RadioButton
            title="1 day forecast"
            limit="1"
            getForecastLimit={this.getForecastLimit}
          />
          <RadioButton
            title="3 days forecast"
            limit="3"
            getForecastLimit={this.getForecastLimit}
          />
          <RadioButton
            title="7 days forecast"
            limit="7"
            getForecastLimit={this.getForecastLimit}
          />
        </div>

        <div className="_search">
          <button
            className="button"
            onClick={() => {
              this.props.getForecastInfo(
                this.state.forecastLimit,
                this.state.userInput,
              );
            }}
          >
            Get weather
          </button>
          <InputField getUserInput={this.getUserInput} />
        </div>
      </div>
    );
  }
}

export default SearchBar;

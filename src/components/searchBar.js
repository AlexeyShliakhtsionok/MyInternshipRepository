import React from 'react';
import InputField from './input.js';
import RadioButton from './radioBtn.js';
import { connect } from 'react-redux';
import { getForecast } from './Redux/actions/actions.js';

class SearchBar extends React.PureComponent {
  componentDidMount() {
    if (this.props.firstRender === true) {
      this.props.initialForecast();
    }
  }

  render() {
    return (
      <div className="weatherBoard__header_searchBar">
        <div className="RadioButton">
          <RadioButton title="1 day forecast" limit="1" />
          <RadioButton title="3 days forecast" limit="3" />
          <RadioButton title="7 days forecast" limit="7" />
        </div>

        <div className="weatherBoard__header_searchBar-searchBox">
          <button
            className="weatherBoard__header_searchBar-searchBox-button"
            onClick={() => {
              this.props.getAsyncResponse(
                this.props.userInput,
                this.props.forecastLimit,
              );
            }}
          >
            Get weather
          </button>
          <InputField />
        </div>
      </div>
    );
  }
}

function mapStateToProps(state) {
  return {
    userInput: state.userInput,
    currentLocation: state.currentLocation,
    forecastLimit: state.forecastLimit,
    forecast: state.forecast,
    firstRender: state.firstRender,
  };
}

function mapDispatchToProps(dispatch) {
  return {
    initialForecast: () => dispatch(getForecast('minsk', '7')),
    getAsyncResponse: (value, limit) => dispatch(getForecast(value, limit)),
  };
}
export default connect(mapStateToProps, mapDispatchToProps)(SearchBar);

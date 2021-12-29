import React from 'react';
import InputField from './input/input.js';
import RadioButton from './radioBtn/radioBtn.js';
import { connect } from 'react-redux';
import { getWeatherOnClick } from '../../../../Redux/actions/actions.js';
import './searchBar.css';

class SearchBar extends React.PureComponent {
  render() {
    return (
      <div className="_searchBar">
        <div className="RadioButton">
          <RadioButton title="1 day forecast" limit="1" />
          <RadioButton title="3 days forecast" limit="3" />
          <RadioButton title="7 days forecast" limit="7" />
        </div>

        <div className="_search">
          <button
            className="button"
            onClick={() => {
              this.props.click('orsha');
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
  };
}

function mapDispatchToProps(dispatch) {
  return {
    click: (value) => dispatch(getWeatherOnClick(value)),
  };
}
export default connect(mapStateToProps, mapDispatchToProps)(SearchBar);

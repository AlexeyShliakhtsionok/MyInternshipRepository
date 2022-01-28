import React from 'react';
import { connect } from 'react-redux';
import { radioButtonChange } from './Redux/actions/actions.js';

class RadioButton extends React.Component {
  render() {
    return (
      <div className="weatherBoard__header_searchBar-radioBtn">
        <h3>{this.props.title}</h3>
        <input
          type="radio"
          className="weatherBoard__header_searchBar-searchBox-radioButton"
          name="forecastLimit"
          value={this.props.limit}
          id={this.props.limit}
          onChange={() => {
            this.props.onRBChange(this.props.limit);
          }}
        />
      </div>
    );
  }
}

function mapDispatchToProps(dispatch) {
  return {
    onRBChange: (value) => dispatch(radioButtonChange(value)),
  };
}

export default connect(null, mapDispatchToProps)(RadioButton);

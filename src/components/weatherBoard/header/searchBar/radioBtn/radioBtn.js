import React from 'react';
import { connect } from 'react-redux';
import { radioButtonChange } from '../../../../../Redux/actions/actions';
import './radioBtn.css';

class RadioButton extends React.Component {
  render() {
    return (
      <div className="weatherBoard__header_searchBar-radioBtn">
        <h3>{this.props.title}</h3>
        <input
          type="radio"
          className="radio"
          name="forecastLimit"
          value={this.props.limit}
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

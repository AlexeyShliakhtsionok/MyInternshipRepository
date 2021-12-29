import React from 'react';
import { connect } from 'react-redux';
import { userInputChange } from '../../../../../Redux/actions/actions';
import './input.css';

class InputField extends React.PureComponent {
  render() {
    return (
      <input
        type="text"
        id="userInput"
        className="weatherBoard__header_searchBar-input"
        placeholder="Enter location here..."
        onChange={() => {
          this.props.onUIChange(document.getElementById('userInput').value);
        }}
      />
    );
  }
}

function mapDispatchToProps(dispatch) {
  return {
    onUIChange: (value) => dispatch(userInputChange(value)),
  };
}

export default connect(null, mapDispatchToProps)(InputField);

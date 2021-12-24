import React from 'react';
import './input.css';

class InputField extends React.Component {
  constructor(props) {
    super(props);
    this.state = {
      value: '',
    };
    this.inputHandler = this.inputHandler.bind(this);
  }

  inputHandler(event) {
    this.setState({ value: event.target.value }, () => {
      this.props.getUserInput(this.state.value);
    });
  }

  render() {
    return (
      <input
        type="text"
        className="input"
        placeholder="Enter location here..."
        onChange={this.inputHandler}
      />
    );
  }
}

export default InputField;

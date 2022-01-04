import React from 'react'
import { connect } from 'react-redux'
import { userInputChange } from '../../../Redux/actions/actions.js'

class InputField extends React.PureComponent {
  render() {
    return (
      <input
        type="text"
        id="userInput"
        className="weatherBoard__header_searchBar-searchBox-input"
        placeholder="Enter location here..."
        onChange={() => {
          this.props.onUIChange(document.getElementById('userInput').value)
        }}
      />
    )
  }
}

function mapStateToProps(state) {
  return {
    userInput: state.userInput,
  }
}

function mapDispatchToProps(dispatch) {
  return {
    onUIChange: (value) => dispatch(userInputChange(value)),
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(InputField)

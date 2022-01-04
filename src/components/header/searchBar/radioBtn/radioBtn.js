import React from 'react'
import { connect } from 'react-redux'
import { radioButtonChange } from '../../../Redux/actions/actions.js'

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
          // checked={this.props.initialCheckboxChecked ? false : }
          onChange={() => {
            this.props.onRBChange(this.props.limit)
          }}
        />
      </div>
    )
  }
}

function mapStateToProps(state) {
  return {
    currentLocation: state.currentLocation,
    forecastLimit: state.forecastLimit,
    firstRender: state.firstRender,
  }
}

function mapDispatchToProps(dispatch) {
  return {
    onRBChange: (value) => dispatch(radioButtonChange(value)),
  }
}

export default connect(mapStateToProps, mapDispatchToProps)(RadioButton)

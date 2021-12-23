import React from 'react';
import './radioBtn.css';

const RadioButton = (props) => {
  return (
    <div>
      <h3>{props.title}</h3>
      <input
        type="radio"
        className="radio"
        name="forecastLimit"
        value={props.limit}
      />
    </div>
  );
};

export default RadioButton;

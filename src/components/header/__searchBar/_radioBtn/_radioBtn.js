import React from 'react';
import './_radioBtn.css';

const RadioButton = (props) => {
  return (
    <div>
      <h3>{props.title}</h3>
      <input
        type="radio"
        className="_radio"
        name="forecastLimit"
        value={props.limit}
      />
    </div>
  );
};

export default RadioButton;

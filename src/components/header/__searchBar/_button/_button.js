import React from 'react';
import './_button.css';

const Button = (props) => {
  return <button className="_button">{props.buttonName}</button>;
};

export default Button;

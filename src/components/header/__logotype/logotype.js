import React from 'react';
import './logotype.css';
import logo from './logo.png';

const logotype = () => {
  return (
    <div className="_logotype">
      <img className="logo" alt="Logotype" src={logo} />
    </div>
  );
};

export default logotype;

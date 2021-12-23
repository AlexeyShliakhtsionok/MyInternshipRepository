import React from 'react';
import './_logotype.css';
import logo from './logo.png';

const logotype = () => {
  return (
    <div className="logotype">
      <img className="logo" alt="Logotype" src={logo} />
    </div>
  );
};

export default logotype;

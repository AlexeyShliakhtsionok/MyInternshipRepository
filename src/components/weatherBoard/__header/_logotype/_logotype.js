import React from 'react';
import './_logotype.css';
import logo1 from './logo1.png';

const logotype = () => {
  return (
    <div className="logotype">
      <img className="logo" alt="Logotype" src={logo1} />
    </div>
  );
};

export default logotype;

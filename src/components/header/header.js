import React from 'react';
import Logotype from './__logotype/logotype.js';
import SearchBar from './__searchBar/__searchBar.js';
import './header.css';

const Header = () => {
  return (
    <div className="header">
      <Logotype />
      <SearchBar />
    </div>
  );
};

export default Header;

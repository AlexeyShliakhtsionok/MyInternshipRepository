import React from 'react';
import Button from './button/button.js';
import InputField from './input/input.js';
import RadioButton from './radioBtn/radioBtn.js';
import './_searchBar.css';

// const childrens = [inputField, button].map((children, index) => (
//   <div key={index}>{children}</div>
// ));

const SearchBar = () => {
  return (
    <form className="_searchBar">
      <RadioButton title="1 day forecast" limit="1" />
      <RadioButton title="3 days forecast" limit="3" />
      <RadioButton title="7 days forecast" limit="7" />
      <Button buttonName="Get weather" />,
      <InputField />,
    </form>
  );
};

export default SearchBar;

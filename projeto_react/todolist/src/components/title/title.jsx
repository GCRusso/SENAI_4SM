import React from "react";
import PropTypes from 'prop-types';
import './title.css';

const Title = ({ titleText }) => {
  return (
    <div className="title">
      <h1>
        {titleText}
      </h1>
    </div>
  );
};
export default Title;
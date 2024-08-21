import React from "react";
import "./button.css";

const Button = ({ textButton, onClick }) => {
    return (
        <button className="text-Button box-Button" onClick={onClick}>
            {textButton}
        </button>
    );
};

export default Button;
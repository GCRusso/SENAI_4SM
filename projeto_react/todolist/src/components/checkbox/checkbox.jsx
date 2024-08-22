import React, { useState } from "react";
import "./checkbox.css";
import { MdEdit } from "react-icons/md";
import { MdHighlightOff } from "react-icons/md";
import { MdOutlineCheckBox, MdOutlineCheckBoxOutlineBlank } from "react-icons/md";

const Checkbox = ({ checked, handleChange }) => {
    const options = [{ text: 'Começar a execução do projeto.' }];

    const [isChecked, setIsChecked] = useState(checked);

    const handleCheckboxChange = () => {
        setIsChecked(!isChecked);
        handleChange(!isChecked);
    };

    return (
        <label className={`box-check ${isChecked ? 'checked' : ''}`}>
            {
                checked ?
                    <MdOutlineCheckBox />
                    :
                    <MdOutlineCheckBoxOutlineBlank />

            }
            <input
                type="checkbox"
                onChange={handleCheckboxChange}
                style={{display:"none"}}
            />
            {options[0].text}
            <div className="box-icons">
                <MdEdit
                    size={25} />
                <MdHighlightOff
                    size={25} />
            </div>
        </label>
    );
};

export default Checkbox;

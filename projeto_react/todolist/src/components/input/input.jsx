import React from "react";
import "./input.css"
import { CiSearch } from "react-icons/ci";

const Input = ({ placeholder, value }) => {

    return (
        <>
            <div className="box-input">
            <CiSearch
            color="white"
            size={25}
            />
                <input
                    className={'text-button'}
                    placeholder={placeholder}
                    value={value}
                />
            </div>
        </>
    );
};
export default Input;
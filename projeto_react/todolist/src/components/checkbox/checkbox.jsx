import React from "react";
import "./checkbox.css"


const Checkbox = ({ checked, handleChange}) => {
    return
    (
        <div>
            <label>
                <input 
                type="checkbox"
                checked={checked}
                onChange={handleChange} 
                />
                Começar execução do projeto
            </label>
        </div>
    );
};

export default Checkbox;
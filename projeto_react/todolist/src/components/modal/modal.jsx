import React from "react";
import './modal.css'
import Button from "../button/button";
import showHideModal from '../../App'
import Title from "../title/title";

const Modal = ({ onClose }) => {
    return (
        <div className="blur">

            <div className="box-modal">
                <Title
                    titleText={'Descreva sua tarefa'}
                />
                <textarea className="box-text">

                </textarea>
                <Button
                    textButton={'Confirmar tarefa'}
                    onClick={onClose}
                />
            </div>

        </div>
    );
};
export default Modal;
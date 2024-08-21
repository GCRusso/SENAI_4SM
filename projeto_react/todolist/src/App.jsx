import './App.css';
import Title from './components/title/title';
import Input from './components/input/input';
import { useState } from 'react';
import React from 'react';
import Button from './components/button/button';
import Checkbox from './components/checkbox/checkbox'
import Modal from './components/modal/modal';

function App() {

  const [isChecked, setIsChecked] = useState(false);
  const [showModal, setShowModal] = useState(false);

  const handleChange = (newChecked) => {
    setIsChecked(newChecked);
  };

  //********** MOSTRA O MODAL *********** */
  const showHideModal = () => {
    setShowModal(!showModal);
  };

  return (
    <>
      <div className='background'>
        <div className='box-background'>
          <Title
            titleText={'Terca-feira, 24 de Julho'}
          />

          <Input
            placeholder={"Procurar Tarefa"}
          />

          <Checkbox
            checked={isChecked}
            handleChange={handleChange}
          />

          <Checkbox
            checked={isChecked}
            handleChange={handleChange}
          />

        </div>

        <Button
          onClick={showHideModal}
          textButton={"Nova Tarefa"}
        />

      </div>
      {showModal ? (
        <Modal onClose={showHideModal}/>
      ) : null}
    </>
  );
}

export default App;

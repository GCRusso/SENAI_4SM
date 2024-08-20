import './App.css';
import Title from './components/title/title';
import Input from './components/input/input';
import { useState } from 'react';
import React from 'react';
import Checkbox from './components/checkbox/checkbox';

function App() {

const [pesquisar, setPesquisar] = useState("");

const [checked, setChecked] = React.useState(false);

const handleChange = () => {
  setChecked(!checked);
};

  return (
    <div className='background'>
      <div className='box-background'>
        <Title
          titleText={'Terca-feira, 24 de Julho'}
        />

        <Input
          placeholder={"Procurar Tarefa"}
        />

        <Checkbox
        label="My Value"
        value={checked}
        onChange={handleChange}/>
      </div>
    </div>

  );
}

export default App;

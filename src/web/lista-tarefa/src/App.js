import React, { Component } from "react"
import './App.css';
import QuadroTarefas from './quadro-tarefas.js';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Button } from 'reactstrap';
import ModalCadastroTarefa from './modal';
class App extends Component {
  constructor(props){
    super(props);
    console.log(props)
  }
  render() {
    return (
      <div className="App">
        <QuadroTarefas />
        <Button color="danger" onClick={()=> this.props.handleClick(true) }>Danger!</Button>
        <ModalCadastroTarefa ></ModalCadastroTarefa>
      </div>
    );
  }
}

export default App;

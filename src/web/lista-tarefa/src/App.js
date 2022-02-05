import React, { Component, useState } from "react"
import './App.css';
import QuadroTarefas from './quadro-tarefas.js';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Button } from 'reactstrap';
import ModalCadastroTarefa from './modal.js';

class App extends Component {
  constructor(props){
    super(props);
    console.log(props)
    this.state = {modalShow: false};
  }

  setModalShow(show) {
    this.setState({modalShow: show});
  }
  
  render() {
    
    return (
      <div className="App">
        <>
        <QuadroTarefas />
        <Button color="danger" onClick={() => this.setModalShow(true)} >Danger!</Button>
        <ModalCadastroTarefa show={this.state.modalShow}
        onHide={() => this.setModalShow(false)}></ModalCadastroTarefa>
        </>
      </div>
    );
  }
}

export default App;

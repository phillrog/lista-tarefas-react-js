import React, { Component, useState } from "react"
import './App.css';
import QuadroTarefas from './quadro-tarefas.js';
import 'bootstrap/dist/css/bootstrap.min.css';

class App extends Component {
 
  render() {
    
    return (
      <div className="App">
        <>
        <QuadroTarefas />
        </>
      </div>
    );
  }
}

export default App;

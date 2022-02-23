
import React from "react";
import  { Component } from 'react';
import { Form, Modal, Button } from 'react-bootstrap';

export class ModalCadastroTarefa extends Component  {

  constructor(props) {
    super(props);

    this.state = {
      descricao: '',
      vencimento: new Date()
    };

    this.handleDescricaoChange = this.handleDescricaoChange.bind(this);
    this.handleVencimentoChange = this.handleVencimentoChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  componentDidMount() {
    this.setState((state) => ({      
      descricao: '',
      vencimento: new Date(new Date().setDate(new Date().getDate() + 3)).toISOString().substring(0, 10)
    }));
  }

  handleDescricaoChange(event) {
    this.setState((state) => ({  
      descricao: event.target.value,
      vencimento: state.vencimento
    }));
  }

  handleVencimentoChange(event) {
    this.setState((state) => ({  
      vencimento: event.target.value,
      descricao: state.descricao
    }));    
  }

  handleSubmit(event) {
    this.novaTarefa({ 
      descricao : this.state.descricao, 
      vencimento: this.state.vencimento,
      droppableId : this.props.droppableId, 
      columns : this.props.columns
    });
    event.preventDefault();
    this.props.onHide();
  }

  novaTarefa(valor) {
    this.props.onCriarTarefa(valor)
  }
  
  render() {  

        return (
          <>            
            <Modal
              show={this.props.show} 
              onHide={this.props.onHide}
              size="lg"
              aria-labelledby="contained-modal-title-vcenter"
              centered
            >
            <Form onSubmit={this.handleSubmit}>
                <Modal.Header closeButton>
                  <Modal.Title>Inserir nova tarefa</Modal.Title>
                </Modal.Header>
                <Modal.Body>
                  
                      <Form.Group className="mb-3" controlId="descricao">
                          <Form.Label>Descrição</Form.Label>
                          <Form.Control  as="textarea" name="descricao" placeholder="Informe a descrição da tarefa" 
                          value={this.state.descricao} 
                          onChange={this.handleDescricaoChange} 
                          />
                          
                      </Form.Group>        
                      <Form.Group className="mb-3" controlId="vencimento">
                          <Form.Label>Vencimento</Form.Label>
                          <Form.Control  type="date"  name="vencimento"  
                          value={this.state.vencimento} 
                          onChange={this.handleVencimentoChange}
                          />
                          
                      </Form.Group>                          
                </Modal.Body>
                <Modal.Footer>
                  <Button variant="primary" type="submit">Confirmar</Button>
                </Modal.Footer>
                </Form>
            </Modal>
          </>
        );
  }
}
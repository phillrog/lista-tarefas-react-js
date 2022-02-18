
import React from "react";
import  { Component } from 'react';
import { Form, Modal, Button } from 'react-bootstrap';

export class ModalCadastroTarefa extends Component  {

  constructor(props) {
    super(props);
    this.state = {
      descricao: ''
    };

    this.handleChange = this.handleChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleChange(event) {
    this.setState({descricao: event.target.value});
  }

  handleSubmit(event) {
    this.novaTarefa({ descricao : this.state.descricao, 
      droppableId : this.props.droppableId, 
      columns : this.props.columns
    });
    event.preventDefault();
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
                  
                      <Form.Group className="mb-3" controlId="formBasicEmail">
                          <Form.Label>Descrição</Form.Label>
                          <Form.Control  as="textarea" name="descricao" placeholder="Informe a descrição da tarefa" 
                          value={this.state.descricao} 
                          onChange={this.handleChange} 
                          />
                          
                      </Form.Group>                                
                </Modal.Body>
                <Modal.Footer>
                  <Button variant="primary" type="submit" onClick={this.props.onHide}>Confirmar</Button>
                </Modal.Footer>
                </Form>
            </Modal>
          </>
        );
  }
}
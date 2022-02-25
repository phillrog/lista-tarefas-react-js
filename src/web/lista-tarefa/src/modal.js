
import React from "react";
import  { Component } from 'react';
import { Form, Modal, Button } from 'react-bootstrap';

export class ModalCadastroTarefa extends Component  {

  constructor(props) {
    super(props);

    this.state = {
      campos: {
        descricao: '',
        vencimento: new Date(),
      },
      errors: {}
    };

    this.handleDescricaoChange = this.handleDescricaoChange.bind(this);
    this.handleVencimentoChange = this.handleVencimentoChange.bind(this);
    this.handleSubmit = this.handleSubmit.bind(this);
  }

  componentDidMount() {
    this.setState((state) => ({      
      campos: {
        descricao: '',
        vencimento: new Date(new Date().setDate(new Date().getDate() + 3)).toISOString().substring(0, 10)
      }, errors : {}
    }));
  }

  handleDescricaoChange(event) {
    this.setState((state) => ({  
      campos: {
        descricao: event.target.value,
        vencimento: state.campos.vencimento,
      }
    }));
  }

  handleVencimentoChange(event) {
    this.setState((state) => ({  
      campos: {
        vencimento: event.target.value,
        descricao: state.campos.descricao
      }
    }));    
  }

  handleValidation() {
    let campos = this.state.campos;
    let errors = {};
    let formIsValid = true;

    if (!campos["descricao"]) {
      formIsValid = false;
      errors["descricao"] = "Descrição é obrigatória";
    }


    if (!campos["vencimento"]) {
      formIsValid = false;
      errors["vencimento"] = "Data vencimento é obrigatório";
    }

    this.setState({ errors: errors });
    return formIsValid;
  }

  handleSubmit(event) {
    event.preventDefault();
    if (this.handleValidation()) {
        this.novaTarefa({ 
          descricao : this.state.campos.descricao, 
          vencimento: this.state.campos.vencimento,
          droppableId : this.props.droppableId, 
          columns : this.props.columns
        });
        
        this.props.onHide();
    } else alert('Dados inválidos')
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
                          value={this.state.campos.descricao} 
                          onChange={this.handleDescricaoChange} 
                          />
                          
                      </Form.Group>        
                      <Form.Group className="mb-3" controlId="vencimento">
                          <Form.Label>Vencimento</Form.Label>
                          <Form.Control  type="date"  name="vencimento"  
                          value={this.state.campos.vencimento} 
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
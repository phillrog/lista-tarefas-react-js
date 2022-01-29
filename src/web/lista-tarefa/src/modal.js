
import React from "react";
import  { Component } from 'react';
import { Form, Modal, Button } from 'reactstrap';

class ModalCadastroTarefa extends Component  {
  constructor(props) {
    super(props);
    
    this.state = {
      show: false
    };
    
  }

  handleClick(status) {
    this.setState({ show: status });
  }

  render() {  
      
        return (
          <>  
          <ModalCadastroTarefa >
            <Modal
              show={this.state.show}
              onHide={() => this.handleClick(false)}
              backdrop="static"
              keyboard={false}
              
            >
              <Modal.Header closeButton>
                <Modal.Title>Inserir nova tarefa</Modal.Title>
              </Modal.Header>
              <Modal.Body>
                <Form>
                    <Form.Group className="mb-3" controlId="formBasicEmail">
                        <Form.Label>Descrição</Form.Label>
                        <Form.Control  as="textarea" placeholder="Informe a descrição da tarefa" />
                        
                    </Form.Group>                                
                </Form>
              </Modal.Body>
              <Modal.Footer>
                <Button variant="secondary" onClick={() => this.handleClick(false)}>
                  Fechar
                </Button>
                <Button variant="primary">Confirmar</Button>
              </Modal.Footer>
            </Modal>
            </ModalCadastroTarefa>
          </>
        );
  }
}
  
  export default ModalCadastroTarefa;
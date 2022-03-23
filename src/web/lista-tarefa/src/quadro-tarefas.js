import React, { useState, useEffect } from 'react';
import styled from '@emotion/styled';
import { columnsFromBackend } from './colunas';
import { DragDropContext, Droppable } from 'react-beautiful-dnd';
import Tarefas from './tarefas';
import { FaCommentMedical, FaPlusCircle } from 'react-icons/fa';
import { ModalCadastroTarefa } from './modal';
import { v4 as uuidv4 } from "uuid"

import api from './services/api';

const Container = styled.div`
  display: flex;
  justify-content: space-around;
  flex-flow: column nowrap;
`;

const TarefasStyle = styled.div`
  display: flex;
  flex-direction: column;
  background: #f3f3f3;
  min-width: 25%;
  border-radius: 5px;
  padding: 15px 15px;
  margin-right: 45px;
  max-height: 460px;
  overflow-y: scroll;
  overflow-x: hidden;
`;

const ColumnStyles = styled.div`
  margin-left: 48px;
  margin-top: 48px;
  display: flex;
  min-height: 80vh;  
  justify-content: center;
`;

const Title = styled.span`
  color: #10957d;
  background: rgba(16, 149, 125, 0.15);
  padding: 2px 10px;
  border-radius: 5px;
  align-self: flex-start;
`;

const ButtonAddStyle = {
  color: '#5183ee',
  height: '32px',
  width: '32px',
  display: 'flex',
  cursor: 'pointer'
}

const Row = {
  display: 'flex',
  flexDirection: 'row',
  flexWrap: 'wrap',
  'width': '100%'
}

const Column = {
  display: 'flex',
  flexDirection: 'column',
  flexBasis: '100%',
  flex: 1,
  alignItems: 'end',
  maxHeight: '32em',
  textAlign: 'justify'
}

const QuadroTarefas = (props) => {
  const [isOpen, setState] = useState(false);
  const [columnId, setDroppableId] = useState(null);
  const [colunas, setColunas] = useState(null);

  const openModal = (id, listaColunas) => {
    setDroppableId(id);
    setState(true);
    setColunas(listaColunas);
  };
  const closeModal = () => {
    setState(false);
  }
  const criarTarefa = (tarefa) => {

    const novoItem = {
      id: `${uuidv4()}`,
      Task: tarefa.descricao,
      Due_Date: `${tarefa.vencimento}T00:00:00`,
    };

    const tarefaNova = gravaNoQuadro({ idQuadroTarefa: tarefa.droppableId, itens: [novoItem] });
    setColumns(tarefaNova);
    
    api.novaTarefa(tarefa.descricao, tarefa.vencimento, tarefa.status);
  }
  let [columns, setColumns] = useState(columnsFromBackend);
  const handlePointerOver = e => {
    e.target.style.color = "green";
  }
  const handlePointerOut = e => {
    e.target.style.color = "#5183ee";
  }
  const onDragEnd = (result, columns, setColumns) => {

    if (!result.destination) return;
    const { source, destination } = result;
    if (source.droppableId !== destination.droppableId) {
      const sourceColumn = columns[source.droppableId];
      const destColumn = columns[destination.droppableId];
      const sourceItems = [...sourceColumn.items];
      const destItems = [...destColumn.items];
      const [removed] = sourceItems.splice(source.index, 1);
      destItems.splice(destination.index, 0, removed);
      setColumns({
        ...columns,
        [source.droppableId]: {
          ...sourceColumn,
          items: sourceItems,
        },
        [destination.droppableId]: {
          ...destColumn,
          items: destItems,
        },
      });
    } else {
      const column = columns[source.droppableId];
      const copiedItems = [...column.items];
      const [removed] = copiedItems.splice(source.index, 1);
      copiedItems.splice(destination.index, 0, removed);
      setColumns({
        ...columns,
        [source.droppableId]: {
          ...column,
          items: copiedItems,
        },
      });
    }
  };


  const [tarefas, setTarefas] = useState([]);
  useEffect(() => {
    let isSubscribed = true;
    api.listar()
      .then(response => response)
      .then(data => {
        if (isSubscribed) {
          setTarefas(data);
          adiciona(data);
        }
        return null;
      });
    return () => (isSubscribed = false);
  }, []);

  const adiciona = (listaTarefas) => {
    const lista = Object.keys(columns)
      .map((tt, e, j) => Object.assign({
        idQuadroTarefa: tt,
        descricao: columns[tt].title,
        itens: listaTarefas.length === 0 ? [] : listaTarefas
          .filter(h => h.descricao === columns[tt].title.replace(' ', ''))
          .map(k =>
            k.tarefas
              .map(f =>
                Object.assign({
                  id: f.id,
                  Task: f.descricao,
                  Due_Date: f.vencimento
                }, {})))[0]
      }, {}));

    let novaCol = Object.assign({ ...columns }, {});
    lista.forEach((t) => {
      const tar = gravaNoQuadro(t);
      novaCol = Object.assign({ ...novaCol, ...tar }, {});
    });
    setColumns(novaCol);
  }

  const gravaNoQuadro = (t) => {
    const column = columns[t.idQuadroTarefa];
    const copiedItems = [...t.itens || [], ...column.items];
    return {
      [t.idQuadroTarefa]: {
        title: column.title,
        items: copiedItems,
      },
    };
  }

  return (
    <>
      {isOpen === true &&
        <ModalCadastroTarefa
          show={isOpen}
          onHide={closeModal}
          onCriarTarefa={criarTarefa}
          droppableId={columnId}
          columns={colunas}
        >

        </ModalCadastroTarefa>
      }
      <DragDropContext
        onDragEnd={(result) => onDragEnd(result, columns, setColumns)}
      >
        <Container>
          <ColumnStyles>
            {Object.entries(columns).map(([columnId, column], index) => {
              return (
                <Droppable key={`${columnId}${index}`} droppableId={columnId}>
                  {(provided, snapshot) => (

                    <TarefasStyle
                      key={index}
                      ref={provided.innerRef}
                      {...provided.droppableProps}
                    >
                      <div style={Row}>
                        <div style={Column}>
                          <Title>{column.title}</Title>
                        </div>
                        <div style={Column}>
                          <FaPlusCircle style={ButtonAddStyle}
                            onPointerOver={handlePointerOver}
                            onPointerOut={handlePointerOut}
                            onClick={() => openModal(columnId, columns)}
                          ></FaPlusCircle>

                        </div>
                      </div>
                      {column.items.map((item, index) => (
                        <Tarefas key={`${item}${index}`} item={item} index={index} />
                      ))}
                      {provided.placeholder}
                    </TarefasStyle>
                  )}
                </Droppable>
              );
            })}
          </ColumnStyles>
        </Container>
      </DragDropContext>
    </>
  );
};

export default QuadroTarefas;
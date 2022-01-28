import React, { useState } from 'react';
import styled from '@emotion/styled';
import { columnsFromBackend } from './colunas';
import { DragDropContext, Droppable } from 'react-beautiful-dnd';
import Tarefas from './tarefas';
import { FaPlusCircle } from 'react-icons/fa'

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
  cursor :'pointer'
}

const Row = {
  display: 'flex',
  'flex-direction': 'row',
  'flex-wrap': 'wrap',
  'width': '100%'
}

const Column = {
  display: 'flex',
  'flex-direction': 'column',
  'flex-basis': '100%',
  flex: 1,
  'align-items': 'end',  
  'max-height': '32em',
  'text-align': 'justify'
}

const QuadroTarefas = () => {
  const [columns, setColumns] = useState(columnsFromBackend);
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
  return (
    <DragDropContext
      onDragEnd={(result) => onDragEnd(result, columns, setColumns)}
    >
      <Container>
        <ColumnStyles>
          {Object.entries(columns).map(([columnId, column], index) => {
            return (
              <Droppable key={columnId} droppableId={columnId}>
                {(provided, snapshot) => (
                  <TarefasStyle
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
                            ></FaPlusCircle>
                        </div>
                    </div>
                    {column.items.map((item, index) => (
                      <Tarefas key={item} item={item} index={index} />
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
  );
};

export default QuadroTarefas;
import React from 'react';
import { Draggable } from 'react-beautiful-dnd';
import styled from '@emotion/styled';


const TarefaStyle = styled.div`
  display: flex;
  flex-direction: column;
  justify-content: center;
  align-items: flex-start;
  padding: 0 15px;
  min-height: 106px;
  border-radius: 5px;
  max-width: 311px;  
  background: white;
  margin-top: 15px;
  .secondary-details {
    display: flex;
    justify-content: space-between;
    align-items: center;
    width: 100%;
    font-size: 12px;
    font-weight: 400px;
    color: #7d7d7d;
  }  
`;

const Tarefas = ({ item, index }) => {
  return (
    <Draggable key={item.id} draggableId={item.id} index={index}>
      {(provided) => (
        <div
          ref={provided.innerRef}
          {...provided.draggableProps}
          {...provided.dragHandleProps}
        >
          <TarefaStyle>
            <p>{item.Task}</p>
            <div className="secondary-details">
              <p>
                <span>
                  {new Date(item.Due_Date).toLocaleDateString('pt-br', {
                    month: 'short',
                    day: '2-digit',
                  })}
                </span>
              </p>
            </div>
          </TarefaStyle>
        </div>
      )}
    </Draggable>
  );
};

export default Tarefas;
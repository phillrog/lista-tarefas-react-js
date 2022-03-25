import React from 'react';
import { Draggable } from 'react-beautiful-dnd';
import styled from '@emotion/styled';


const TarefaStyle = styled.div`
  display: flex;
  flex-direction: column-reverse;
  justify-content: center;
  align-items: flex-start;
  padding: 0 15px;
  min-height: 106px;
  border-radius: 5px;
  max-width: 311px;  
  background: white;
  margin-top: 15px;
  width: 100%;
  .secondary-details {
    display: flex;
    justify-content: space-between;
    align-items: flex-start;
    width: 100%;
    font-size: 12px;
    font-weight: 400px;
    color: #7d7d7d;
  } 
  p {
    text-align: left;
  } 

  .x {
    position: relative;
    width: 26px;
    height: 26px;
    border: 2px solid #eef5df;
    background-color: #ff5248;
    border-radius: 50%;
    }
  .x::before, .x::after {
    position: absolute;
    top: 10px;
    left: 5px;
    width: 13px;
    height: 3px;
    content: "";
    background-color: #eef5df;
    display: none;
    }
  .x::before {
    -ms-transform: rotate(-45deg);
    -webkit-transform: rotate(-45deg);
    transform: rotate(-45deg);
    }
  .x::after {
    -ms-transform: rotate(45deg);
    -webkit-transform: rotate(45deg);
    transform: rotate(45deg);
    }
  .x:hover { cursor: pointer; }
  .x:hover::before, .x:hover::after { display: block; }
  
 
`;


const ItemStyle = {
  display: 'flex',
  marginBotton: '10px'
}



const Tarefas = ({ item, index }) => {
  return (
    <Draggable key={item.id} draggableId={item.id} index={index}>
      {(provided) => (
        <div
          ref={provided.innerRef}
          {...provided.draggableProps}
          {...provided.dragHandleProps}
        >


          <TarefaStyle className='item'>
            <p>{item.Task}</p>
            <div className="secondary-details">
              <div style={ItemStyle}>
                <p>
                  <span>
                    {new Date(item.Due_Date).toLocaleDateString('pt-br', {
                      month: 'short',
                      day: '2-digit',
                    })}
                  </span>
                </p>
              </div>
              <div style={ItemStyle}><a className='x'></a></div>
            </div>
          </TarefaStyle>
        </div>

      )}
    </Draggable>
  );
};

export default Tarefas;
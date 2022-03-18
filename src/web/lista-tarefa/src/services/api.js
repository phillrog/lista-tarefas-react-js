import axios from 'axios';

const tarefaController = axios.create({
  baseURL: `https://localhost:7033/api/Tarefa/`
});

const quadroTarefa = ['A Fazer', 'Fazendo', 'Feito'];

const api = {
  novaTarefa: (descricao, vencimento, quadro) => {

    tarefaController.post("nova-tarefa", {
      descricao,
      vencimento,
      status: quadroTarefa.indexOf(quadro)
    })
    .then((response) => console.log(response))
    .catch((err) => {
      console.error("ops! ocorreu um erro" + err);
    });
  },
  listar: async() => {
    return await tarefaController.get("listar")
    .then((response) => {
      if(response.status === 200) return response.data.data;
      else return [];
    })
    .catch((err) => {
      console.error("ops! ocorreu um erro" + err);
    });
  } 
};

export default api;
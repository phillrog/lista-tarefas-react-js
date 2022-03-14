import axios from 'axios';

const tarefaController = axios.create({
  baseURL: `https://localhost:7033/api/Tarefa/`
});

const api = {
  novaTarefa: (descricao, vencimento) => {
    tarefaController.post("nova-tarefa", {
      descricao,
      vencimento
    })
    .then((response) => console.log(response))
    .catch((err) => {
      console.error("ops! ocorreu um erro" + err);
    });
  }
};

export default api;
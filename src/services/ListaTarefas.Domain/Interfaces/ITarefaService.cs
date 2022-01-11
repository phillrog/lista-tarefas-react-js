using ListaTarefas.Domain.Entities;

namespace ListaTarefas.Domain.Interfaces
{
    public interface ITarefaService
    {
        Task Adicionar(Tarefa tarefa);
    }
}

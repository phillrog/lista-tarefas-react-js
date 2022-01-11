using ListaTarefas.Domain.Entities;

namespace ListaTarefas.Domain.Interfaces
{
    public interface ITarefaService
    {
        Task Adicionar(Tarefa tarefa);
        Task Editar(Tarefa tarefa);
        Task Remover(Guid id);
    }
}

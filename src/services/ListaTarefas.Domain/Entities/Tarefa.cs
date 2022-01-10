using ListaTarefas.Core.DomainObjects;
using ListaTarefas.Domain.Enums;

namespace ListaTarefas.Domain.Entities
{
    public class Tarefa : Entity, IAggregateRoot
    {
        public int Descricao { get; private set; }
        public DateTime Vencimento { get; private set; }
        public StatusEnum Status { get; private set; }

        public Tarefa(int descricao, DateTime vencimento, StatusEnum status)
        {
            Descricao = descricao;
            Vencimento = vencimento;
            Status = status;
        }
    }
}

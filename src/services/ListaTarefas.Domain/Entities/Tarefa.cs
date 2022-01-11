using ListaTarefas.Core.DomainObjects;
using ListaTarefas.Domain.Enums;

namespace ListaTarefas.Domain.Entities
{
    public class Tarefa : Entity, IAggregateRoot
    {
        public string Descricao { get; private set; }
        public DateTime Vencimento { get; private set; }
        public StatusEnum Status { get; private set; }
        public DateTime? DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public Tarefa(){}
        public Tarefa(string descricao, DateTime vencimento, StatusEnum status)
        {
            Descricao = descricao;
            Vencimento = vencimento;
            Status = status;
        }
    }
}

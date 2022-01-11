using ListaTarefas.Core.Messages;
using ListaTarefas.Domain.Enums;

namespace ListaTarefas.Application.Events
{
    public class EdicaoSolicitadaEvent : Event
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Vencimento { get; set; }
        public StatusEnum Status { get; set; }

        public EdicaoSolicitadaEvent(Guid id, string descricao, DateTime vencimento, StatusEnum status)
        {
            Id = id;
            Descricao = descricao;
            Vencimento = vencimento;
            Status = (StatusEnum)status;
            AggregateId = Guid.NewGuid();
        }
    }
}

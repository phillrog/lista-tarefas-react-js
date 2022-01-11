using ListaTarefas.Core.Messages;

namespace ListaTarefas.Application.Events
{
    public class RemocaoSolicitadaEvent : Event
    {
        public Guid Id { get; set; }       

        public RemocaoSolicitadaEvent(Guid id)
        {
            Id = id;            
            AggregateId = Guid.NewGuid();
        }
    }
}

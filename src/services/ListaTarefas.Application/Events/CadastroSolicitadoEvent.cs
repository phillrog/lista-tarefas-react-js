using ListaTarefas.Core.Messages;

namespace ListaTarefas.Application.Events
{
    public class CadastroSolicitadoEvent : Event
    {
        public string Descricao { get; private set; }
        public DateTime Vencimento { get; private set; }
        public int Status { get; set; }
        public CadastroSolicitadoEvent(string descricao, DateTime vencimento, int status)
        {
            Descricao = descricao;
            Vencimento = vencimento;
            Status = status;
            AggregateId = Guid.NewGuid();
        }
    }
}

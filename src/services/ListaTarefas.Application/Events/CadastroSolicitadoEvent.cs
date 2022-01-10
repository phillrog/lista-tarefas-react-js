using ListaTarefas.Core.Messages;

namespace ListaTarefas.Application.Events
{
    public class CadastroSolicitadoEvent : Event
    {
        public string Descricao { get; private set; }
        public DateTime Vencimento { get; private set; }
        public CadastroSolicitadoEvent(string descricao, DateTime vencimento)
        {
            Descricao = descricao;
            Vencimento = vencimento;
            AggregateId = Guid.NewGuid();
        }
    }
}

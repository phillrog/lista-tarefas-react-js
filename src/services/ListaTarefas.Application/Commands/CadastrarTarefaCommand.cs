using FluentValidation;
using ListaTarefas.Core.Messages;

namespace ListaTarefas.Application.Commands
{
    public class CadastrarTarefaCommand : Command
    {
        public string Descricao { get; private set; }
        public DateTime Vencimento { get; private set; }
        public CadastrarTarefaCommand(string descricao, DateTime vencimento)
        {
            Descricao = descricao;
            Vencimento = vencimento;
        }        
    }
}

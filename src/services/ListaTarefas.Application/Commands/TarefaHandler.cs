using FluentValidation.Results;
using ListaTarefas.Core.Messages;
using MediatR;

namespace ListaTarefas.Application.Commands
{
    public class TarefaHandler : CommandHandler, IRequestHandler<CadastrarTarefaCommand, ValidationResult>
    {
        public async Task<ValidationResult> Handle(CadastrarTarefaCommand message, CancellationToken cancellationToken)
        {
            return message.ValidationResult;
        }
    }
}

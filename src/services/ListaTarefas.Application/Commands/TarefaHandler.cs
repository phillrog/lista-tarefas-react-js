using FluentValidation.Results;
using ListaTarefas.Core.Messages;
using MediatR;

namespace ListaTarefas.Application.Commands
{
    public class TarefaHandler : CommandHandler, IRequestHandler<CadastrarTarefaCommand, ValidationResult>
    {
        public Task<ValidationResult> Handle(CadastrarTarefaCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

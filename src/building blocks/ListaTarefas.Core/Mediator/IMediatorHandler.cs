using FluentValidation.Results;
using ListaTarefas.Core.Messages;

namespace ListaTarefas.Core.Mediator
{
    public interface IMediatorHandler
    {
        Task<ValidationResult> EnviarComando<T>(T comando) where T : Command;
        Task PublicarEvento<T>(T evento) where T : Event;
    }
}

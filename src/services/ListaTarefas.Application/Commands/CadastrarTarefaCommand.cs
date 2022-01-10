using FluentValidation;
using ListaTarefas.Core.Messages;

namespace ListaTarefas.Application.Commands
{
    public class CadastrarTarefaCommand : Command
    {
        public string Descricao { get; private set; }
        public DateTime Vencimento { get; private set; }
    }

    public class CadastrarTarefaValidation : AbstractValidator<CadastrarTarefaCommand>
    {
        public CadastrarTarefaValidation()
        {
            RuleFor(m => m.Descricao)
                .NotEmpty()
                .NotNull()
                .MinimumLength(3)
                .MaximumLength(250)
                .WithMessage("Descrição inválida");

            RuleFor(m => m.Vencimento)
                .NotNull()
                .WithMessage("Data de vencimento inválida");
        }
    }
}

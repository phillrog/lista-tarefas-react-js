using FluentValidation;
using ListaTarefas.Core.Messages;

namespace ListaTarefas.Application.Commands
{
    public class SolicitarRemocaoTarefaCommand : Command
    {
        public Guid Id { get; set; }
        
        public SolicitarRemocaoTarefaCommand(Guid id)
        {
            Id = id;            
        }
        public override bool EhValido()
        {
            ValidationResult = new SolicitarRemocaoTarefaCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }

    public class SolicitarRemocaoTarefaCommandValidation : AbstractValidator<SolicitarRemocaoTarefaCommand>
    {
        public SolicitarRemocaoTarefaCommandValidation()
        {
            RuleFor(m => m.Id)
                .NotEmpty()
                .NotNull()
                .WithMessage("Identificador inválido");
        }
    }
}

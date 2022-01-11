using FluentValidation;
using ListaTarefas.Core.Messages;
using ListaTarefas.Domain.Enums;

namespace ListaTarefas.Application.Commands
{
    public class SolicitarEdicaoTarefaCommand : Command
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Vencimento { get; set; }
        public StatusEnum Status { get; set; }        

        public SolicitarEdicaoTarefaCommand(Guid id, string descricao, DateTime vencimento, int status)
        {
            Id = id;
            Descricao = descricao;
            Vencimento = vencimento;
            Status = (StatusEnum)status;
        }
        public override bool EhValido()
        {
            ValidationResult = new SolicitarEdicaoTarefaCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }

    public class SolicitarEdicaoTarefaCommandValidation : AbstractValidator<SolicitarEdicaoTarefaCommand>
    {
        public SolicitarEdicaoTarefaCommandValidation()
        {
            RuleFor(m => m.Descricao)
                .NotEmpty()
                .NotNull()                
                .WithMessage("Descrição inválida")
                .Length(2, 250).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres"); ;

            RuleFor(m => m.Vencimento)
                .NotNull()
                .WithMessage("Data de vencimento inválida");

            RuleFor(d => d.Status).IsInEnum()
               .WithMessage("Identificador do status não encontrado");
        }
    }
}

using FluentValidation;
using ListaTarefas.Core.Messages;

namespace ListaTarefas.Application.Commands
{
    public class SolicitarCadastroTarefaCommand : Command
    {
        public string Descricao { get; private set; }
        public DateTime Vencimento { get; private set; }
        public int Status { get; set; }
        public SolicitarCadastroTarefaCommand(string descricao, DateTime vencimento, int quadro)
        {
            Descricao = descricao;
            Vencimento = vencimento;
            Status = quadro;
            AggregateId = Guid.NewGuid();
        }

        public override bool EhValido()
        {
            ValidationResult = new SolicitacaoCadastroTarefaCommandValidation().Validate(this);

            return ValidationResult.IsValid;
        }
    }

    public class SolicitacaoCadastroTarefaCommandValidation : AbstractValidator<SolicitarCadastroTarefaCommand>
    {
        public SolicitacaoCadastroTarefaCommandValidation()
        {
            RuleFor(m => m.Descricao)
                .NotEmpty()
                .NotNull()                
                .WithMessage("Descrição inválida")
                .Length(2, 250).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres"); ;

            RuleFor(m => m.Vencimento)
                .NotNull()
                .WithMessage("Data de vencimento inválida");

            RuleFor(m => m.Status)
                .InclusiveBetween(0, 2)
                .WithMessage("Quadro não encontrado");
        }
    }
}

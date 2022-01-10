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

    public class CadastrarTarefaValidation : AbstractValidator<CadastrarTarefaCommand>
    {
        public CadastrarTarefaValidation()
        {
            RuleFor(m => m.Descricao)
                .NotEmpty()
                .NotNull()                
                .WithMessage("Descrição inválida")
                .Length(2, 250).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres"); ;

            RuleFor(m => m.Vencimento)
                .NotNull()
                .WithMessage("Data de vencimento inválida");
        }
    }
}

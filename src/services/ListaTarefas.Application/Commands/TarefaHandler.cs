using FluentValidation.Results;
using ListaTarefas.Application.Events;
using ListaTarefas.Core.Mediator;
using ListaTarefas.Core.Messages;
using ListaTarefas.Domain.Interfaces;
using MediatR;

namespace ListaTarefas.Application.Commands
{
    public class TarefaHandler : CommandHandler, IRequestHandler<CadastrarTarefaCommand, ValidationResult>,
        IRequestHandler<SolicitarCadastroTarefaCommand, ValidationResult>
    {
        private readonly ITarefaRepository _tarefaRepository;
        private readonly IMediatorHandler _mediator;

        public TarefaHandler(ITarefaRepository tarefaRepository,
            IMediatorHandler mediator)
        {
            _tarefaRepository = tarefaRepository;
            _mediator = mediator;
        }

        public async Task<ValidationResult> Handle(CadastrarTarefaCommand message, CancellationToken cancellationToken)
        {
            return message.ValidationResult;
        }

        public async Task<ValidationResult> Handle(SolicitarCadastroTarefaCommand message, CancellationToken cancellationToken)
        {
            if (!message.EhValido())
            {
                AdicionarErro("Solicitação é inválida");
                return message.ValidationResult;
            }

            var tarefaExiste = await _tarefaRepository.ObterPorDescricao(message.Descricao);
            if (tarefaExiste != null && tarefaExiste.Id != Guid.Empty)
            {
                AdicionarErro("Já foi cadastrado esta tarefa");
                return ValidationResult;
            }

            await _mediator.PublicarEvento<CadastroSolicitadoEvent>(new CadastroSolicitadoEvent(message.Descricao, message.Vencimento));

            return ValidationResult;
        }
    }
}

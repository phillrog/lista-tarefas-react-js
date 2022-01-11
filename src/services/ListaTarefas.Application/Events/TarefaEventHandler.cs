using ListaTarefas.Application.Contracts;
using MassTransit;
using MediatR;

namespace ListaTarefas.Application.Events
{
    public class TarefaEventHandler : INotificationHandler<CadastroSolicitadoEvent>,
        INotificationHandler<EdicaoSolicitadaEvent>,
        INotificationHandler<RemocaoSolicitadaEvent>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public TarefaEventHandler(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task Handle(CadastroSolicitadoEvent message, CancellationToken cancellationToken)
        {
            await _publishEndpoint.Publish<ICadastroSolicitado>(new
            {
                message.AggregateId,
                message.Descricao,
                message.MessageType,
                message.Timestamp,
                message.Vencimento
            });
        }

        public async Task Handle(EdicaoSolicitadaEvent message, CancellationToken cancellationToken)
        {
            await _publishEndpoint.Publish<IEdicaoSolicitada>(new
            {
                message.Id,
                message.AggregateId,
                message.Descricao,
                message.MessageType,
                message.Timestamp,
                message.Vencimento,
                message.Status
            });
        }

        public async Task Handle(RemocaoSolicitadaEvent message, CancellationToken cancellationToken)
        {
            await _publishEndpoint.Publish<IRemocaoSolicitada>(new
            {
                message.Id,
                message.AggregateId,
                message.MessageType,
                message.Timestamp
            });
        }
    }
}

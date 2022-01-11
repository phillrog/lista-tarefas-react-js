using ListaTarefas.Application.Contracts;
using MassTransit;
using MediatR;

namespace ListaTarefas.Application.Events
{
    public class TarefaEventHandler : INotificationHandler<CadastroSolicitadoEvent>
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public TarefaEventHandler(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task Handle(CadastroSolicitadoEvent message, CancellationToken cancellationToken)
        {
            await _publishEndpoint.Publish<ICadastroSolicitado>(new { message.AggregateId, message.Descricao, message.MessageType, message.Timestamp });
        }
    }
}

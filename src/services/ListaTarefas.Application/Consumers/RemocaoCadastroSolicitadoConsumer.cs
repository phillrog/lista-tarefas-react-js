using ListaTarefas.Application.Contracts;
using ListaTarefas.Application.DTOs;
using ListaTarefas.Application.Services;
using MassTransit;

namespace ListaTarefas.Application.Consumers
{
    public class RemocaoCadastroSolicitadoConsumer : IConsumer<IRemocaoSolicitada>
    {
        private readonly ICadastroTarefaService _cadastroTarefaService;
        public RemocaoCadastroSolicitadoConsumer(ICadastroTarefaService cadastroTarefaService)
        {
            _cadastroTarefaService = cadastroTarefaService;
        }
        public async Task Consume(ConsumeContext<IRemocaoSolicitada> context)
        {
            var message = context.Message;
            await _cadastroTarefaService.Remover(new TarefaDTO( message.Id));
        }
    }
}

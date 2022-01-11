using ListaTarefas.Application.Contracts;
using ListaTarefas.Application.DTOs;
using ListaTarefas.Application.Services;
using MassTransit;

namespace ListaTarefas.Application.Consumers
{
    public class EdicaoCadastroSolicitadoConsumer : IConsumer<IEdicaoSolicitada>
    {
        private readonly ICadastroTarefaService _cadastroTarefaService;
        public EdicaoCadastroSolicitadoConsumer(ICadastroTarefaService cadastroTarefaService)
        {
            _cadastroTarefaService = cadastroTarefaService;
        }
        public async Task Consume(ConsumeContext<IEdicaoSolicitada> context)
        {
            var message = context.Message;
            await _cadastroTarefaService.Editar(new TarefaDTO( message.Id, message.Descricao, message.Vencimento, message.Status));
        }
    }
}

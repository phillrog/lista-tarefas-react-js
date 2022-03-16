using ListaTarefas.Application.Contracts;
using ListaTarefas.Application.DTOs;
using ListaTarefas.Application.Services;
using MassTransit;

namespace ListaTarefas.Application.Consumers
{
    public class CadastroSolicitadoConsumer : IConsumer<ICadastroSolicitado>
    {
        private readonly ICadastroTarefaService _cadastroTarefaService;

        public CadastroSolicitadoConsumer(ICadastroTarefaService cadastroTarefaService )
        {
            _cadastroTarefaService = cadastroTarefaService;
        }
        public async Task Consume(ConsumeContext<ICadastroSolicitado> context)
        {
            var message = context.Message;
            await _cadastroTarefaService.Cadastrar(new TarefaDTO(message.Descricao, message.Vencimento, message.Status));
        }
    }
}

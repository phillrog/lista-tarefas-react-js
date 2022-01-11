using ListaTarefas.Application.Contracts;
using MassTransit;

namespace ListaTarefas.Application.Consumers
{
    public class CadastroSolicitadoConsumer : IConsumer<ICadastroSolicitado>
    {
        public async Task Consume(ConsumeContext<ICadastroSolicitado> context)
        {
           await Task.CompletedTask;
        }
    }
}

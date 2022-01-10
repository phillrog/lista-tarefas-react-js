using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTarefas.Application.Events
{
    public class TarefaEventHandler : INotificationHandler<CadastroSolicitadoEvent>
    {
        public async Task Handle(CadastroSolicitadoEvent notification, CancellationToken cancellationToken)
        {
            Task.CompletedTask;
        }
    }
}

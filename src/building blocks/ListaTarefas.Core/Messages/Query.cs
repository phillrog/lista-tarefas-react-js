using ListaTarefas.Core.Communication;
using MediatR;

namespace ListaTarefas.Core.Messages
{
    public abstract class Query : IRequest<ResponseQueryResult>
    {
        public DateTime Timestamp { get; private set; }
        public Query()
        {
            Timestamp = DateTime.Now;
        }
    }
}

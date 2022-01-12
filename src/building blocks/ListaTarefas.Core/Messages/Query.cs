using MediatR;

namespace ListaTarefas.Core.Messages
{
    public abstract class Query<T> : IRequest<T>
    {
        public DateTime Timestamp { get; private set; }
        public Query()
        {
            Timestamp = DateTime.Now;
        }
    }
}

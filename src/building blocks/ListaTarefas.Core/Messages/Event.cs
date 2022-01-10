using MediatR;

namespace ListaTarefas.Core.Messages
{
    public class Event : Message, INotification
	{
		public DateTime Timestamp { get; private set; }
		public Type Tipo { get; set; }

		protected Event()
		{
			Timestamp = DateTime.Now;
		}
	}
}

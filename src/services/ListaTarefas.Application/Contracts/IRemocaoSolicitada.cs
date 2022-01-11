namespace ListaTarefas.Application.Contracts
{
    public interface IRemocaoSolicitada
    {
        public Guid AggregateId { get; }
        public Guid Id { get; set; }        
        public DateTime Timestamp { get; }
        public string MessageType { get; set; }
    }
}

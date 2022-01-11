namespace ListaTarefas.Application.Contracts
{
    public interface ICadastroSolicitado
    {
        public Guid AggregateId { get; }
        public string Descricao { get; }
        public DateTime Vencimento { get; }
        public DateTime Timestamp { get; }
        public string MessageType { get; set; }
    }
}

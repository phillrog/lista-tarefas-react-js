namespace ListaTarefas.Application.Contracts
{
    public interface ICadastroSolicitado
    {
        public Guid AgregateId { get; }
        public string Descricao { get; }
        public DateTime Vencimento { get; }
        public DateTime Timestamp { get; }
        public string MessageType { get; set; }
    }
}

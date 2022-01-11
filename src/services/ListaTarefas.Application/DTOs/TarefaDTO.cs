namespace ListaTarefas.Application.DTOs
{
    public class TarefaDTO
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Vencimento { get; set; }
        public int Status { get; set; }

        public TarefaDTO(string descricao, DateTime vencimento)
        {
            Descricao = descricao;
            Vencimento = vencimento;
        }
    }
}

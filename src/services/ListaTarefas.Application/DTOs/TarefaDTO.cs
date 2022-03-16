using ListaTarefas.Core.Communication;

namespace ListaTarefas.Application.DTOs
{
    public class TarefaDTO 
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Vencimento { get; set; }
        public int Status { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public TarefaDTO(string descricao, DateTime vencimento, int status)
        {
            Descricao = descricao;
            Vencimento = vencimento;
            Status = status;
        }

        public TarefaDTO(Guid id, string descricao, DateTime vencimento, int status)
        {
            Id = id;
            Descricao = descricao;
            Vencimento = vencimento;
            Status = status;
        }

        public TarefaDTO(Guid id)
        {
            Id = id;
        }

        public TarefaDTO(Guid id, string descricao, DateTime vencimento, int status, DateTime dataCadastro, DateTime? dataAtualizacao)
        {
            Id = id;
            Descricao = descricao;
            Vencimento = vencimento;
            Status = status;
            DataCadastro = dataCadastro;
            DataAtualizacao = dataAtualizacao;
        }
    }
}

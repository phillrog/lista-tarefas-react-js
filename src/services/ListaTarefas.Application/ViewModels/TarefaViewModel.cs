using ListaTarefas.Core.Communication;

namespace ListaTarefas.Application.ViewModels
{
    public class RetornoViewModel : IQueryResult
    {
        public int Status { get; set; }
        public string Descricao { get; set; }
        public IEnumerable<TarefaViewModel> Tarefas { get; set; }
    }

    public class TarefaViewModel 
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public DateTime Vencimento { get; set; }
        public int Status { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }
        public TarefaViewModel()
        {

        }
        public TarefaViewModel(Guid id, string descricao, DateTime vencimento, int status, DateTime dataCadastro, DateTime? dataAtualizacao)
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
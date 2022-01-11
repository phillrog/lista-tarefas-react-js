using ListaTarefas.Core.DomainObjects;
using ListaTarefas.Domain.Enums;

namespace ListaTarefas.Domain.Entities
{
    public class Tarefa : Entity, IAggregateRoot
    {
        public string Descricao { get; private set; }
        public DateTime Vencimento { get; private set; }
        public StatusEnum Status { get; private set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAtualizacao { get; set; }

        public Tarefa(){}
        public Tarefa(string descricao, DateTime vencimento, StatusEnum status)
        {
            Descricao = descricao;
            Vencimento = vencimento;
            Status = status;
        }

        public Tarefa(Guid id, string descricao, DateTime vencimento, StatusEnum status, DateTime? dataAtualizacao)
        {
            Id = id;
            Descricao = descricao;
            Vencimento = vencimento;
            Status = status;
            DataAtualizacao = dataAtualizacao;
        }

        public void AtualizarVencimento(DateTime vencimentoNovo)
        {
            Vencimento = vencimentoNovo;
        }

        public void UltimaAtualizacaoEm(DateTime dataAtualizacao)
        {
            DataAtualizacao = dataAtualizacao;
        }

        public void AtualizarDescricao(string descricao)
        {
            Descricao = descricao;
        }

        public void AtualizarStatus(StatusEnum status)
        {
            Status = status;
        }
    }
}

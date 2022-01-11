using ListaTarefas.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ListaTarefas.Infra.Data.Mappings
{
    public class TarefaMapping : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Descricao).HasMaxLength(250);
            builder.Property(s => s.Vencimento);
            builder.Property(s => s.Status);
            builder.Property(s => s.DataCadastro);
            builder.Property(s => s.DataAtualizacao);
        }
    }
}

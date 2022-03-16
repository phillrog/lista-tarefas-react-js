using ListaTarefas.Domain.Entities;
using ListaTarefas.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ListaTarefas.Infra.Data.Mappings
{
    public class TarefaMapping : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.HasKey(s => s.Id);

            builder.Property(s => s.Descricao).HasMaxLength(250);
            builder.Property(s => s.Vencimento);
            builder.Property(s => s.Status).HasMaxLength(10).HasConversion(new StatusConversorCustomizado());
            builder.Property(s => s.DataCadastro);
            builder.Property(s => s.DataAtualizacao);
        }
    }

    public class StatusConversorCustomizado : ValueConverter<StatusEnum, string>
    {
        public StatusConversorCustomizado() : base(
            p => ConverterParaOhBancoDeDados(p),
            value => ConverterParaAplicacao(value),
            new ConverterMappingHints(1))
        {

        }

        static string ConverterParaOhBancoDeDados(StatusEnum status)
        {
            return status.ToString();
        }

        static StatusEnum ConverterParaAplicacao(string value)
        {
            var status = Enum
                .GetValues<StatusEnum>()
                .FirstOrDefault(p => p.ToString() == value);

            return status;
        }
    }
}

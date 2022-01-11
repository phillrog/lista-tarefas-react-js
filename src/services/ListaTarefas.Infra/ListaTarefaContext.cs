using FluentValidation.Results;
using ListaTarefas.Core.Data;
using ListaTarefas.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ListaTarefas.Infra
{
    public class ListaTarefaContext : DbContext, IUnitOfWork
    {
        public ListaTarefaContext(DbContextOptions<ListaTarefaContext> options)
            :base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            ChangeTracker.AutoDetectChangesEnabled = false;
        }

        public DbSet<Tarefa> Tarefas { get; set; }

        public async Task<bool> Commit()
        {
            foreach (var entry in ChangeTracker
                .Entries()
                .Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            return await base.SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ListaTarefaContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

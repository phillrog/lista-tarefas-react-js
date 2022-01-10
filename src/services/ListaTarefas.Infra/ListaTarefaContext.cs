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
            return await base.SaveChangesAsync() > 0;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ListaTarefaContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}

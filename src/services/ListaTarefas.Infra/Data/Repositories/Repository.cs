using ListaTarefas.Core.Data;
using ListaTarefas.Core.DomainObjects;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ListaTarefas.Infra.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
	{
		protected readonly ListaTarefaContext _dbContext;
		protected readonly DbSet<TEntity> _dbSet;

        public IUnitOfWork UnitOfWork => _dbContext;

        protected Repository(ListaTarefaContext db)
		{
			_dbContext = db;
			_dbSet = db.Set<TEntity>();
		}

		public virtual async Task Adicionar(TEntity entity)
		{
			_dbSet.Add(entity);
			await SaveChanges();
		}

		public virtual async Task Atualizar(TEntity entity)
		{
			_dbContext.Entry<TEntity>(entity).State = EntityState.Modified;
			_dbSet.Update(entity);
			await SaveChanges();
		}

		public virtual async Task<IEnumerable<TEntity>> Buscar(Expression<Func<TEntity, bool>> predicate)
		{
			return await _dbSet.AsNoTracking().Where(predicate).ToListAsync();
		}

		public virtual async Task<TEntity> ObterPorId(Guid id)
		{
			return await _dbSet.AsNoTracking().FirstOrDefaultAsync(e => e.Id == id);
		}

		public virtual async Task<List<TEntity>> ObterTodos()
		{
			return await _dbSet.AsNoTracking().ToListAsync();
		}

		public virtual async Task Remover(Guid id)
		{
			_dbSet.Remove(new TEntity { Id = id });
			await SaveChanges();
		}

		public virtual async Task<int> SaveChanges()
		{
			return await _dbContext.SaveChangesAsync();
		}

		public virtual void Dispose()
		{
			_dbContext?.Dispose();
		}
	}
}

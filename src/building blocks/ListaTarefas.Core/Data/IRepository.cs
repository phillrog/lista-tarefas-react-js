using ListaTarefas.Core.DomainObjects;
using System.Linq.Expressions;

namespace ListaTarefas.Core.Data
{
    public interface IRepository<T> : IDisposable where T : Entity
    {
        IUnitOfWork UnitOfWork { get; }
		Task Adicionar(T entity);
		Task<T> ObterPorId(Guid id);
		Task<List<T>> ObterTodos();
		Task Atualizar(T entity);
		Task Remover(Guid id);
		Task<IEnumerable<T>> Buscar(Expression<Func<T, bool>> predicate);
		Task<int> SaveChanges();
	}
}

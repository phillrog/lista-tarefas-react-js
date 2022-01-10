using ListaTarefas.Domain.Entities;
using ListaTarefas.Domain.Interfaces;

namespace ListaTarefas.Infra.Data.Repositories
{
    public class TarefaRepository : Repository<Tarefa>, ITarefaRepository
    {        
        public TarefaRepository(ListaTarefaContext dbContext) : base(dbContext)
        {

        }
    }
}

using ListaTarefas.Domain.Entities;
using ListaTarefas.Domain.Interfaces;
using System.Linq;

namespace ListaTarefas.Infra.Data.Repositories
{
    public class TarefaRepository : Repository<Tarefa>, ITarefaRepository
    {        
        public TarefaRepository(ListaTarefaContext dbContext) : base(dbContext)
        {

        }

        public async Task<Tarefa> ObterPorDescricao(string descricao)
        {
            return _dbContext.Tarefas.FirstOrDefault(f => f.Descricao.ToLower() == descricao.ToLower());
        }
    }
}

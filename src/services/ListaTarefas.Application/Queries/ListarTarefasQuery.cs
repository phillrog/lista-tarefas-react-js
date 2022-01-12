using ListaTarefas.Application.ViewModels;
using ListaTarefas.Core.Messages;

namespace ListaTarefas.Application.Queries
{
    public class ListarTarefasQuery : Query<IEnumerable<TarefaViewModel>>
    {
    }
}

using ListaTarefas.Application.Services;
using ListaTarefas.Application.ViewModels;
using ListaTarefas.Core.Messages;
using MediatR;

namespace ListaTarefas.Application.Queries
{
    public class TarefaQueryHandler : QueryHandler<List<TarefaViewModel>>, IRequestHandler<ListarTarefasQuery, IEnumerable<TarefaViewModel>>
    {
        private readonly ICadastroTarefaService _cadastroTarefaService;

        public TarefaQueryHandler(ICadastroTarefaService cadastroTarefaService  )
        {
            _cadastroTarefaService = cadastroTarefaService;
        }
        public async Task<IEnumerable<TarefaViewModel>> Handle(ListarTarefasQuery request, CancellationToken cancellationToken)
        {
            var tarefas = await _cadastroTarefaService.Listar();

            if (tarefas == null || tarefas.Count() == 0) return ResponseQueryResult;

            ResponseQueryResult.AddRange(tarefas.Select(t => new TarefaViewModel(t.Id, t.Descricao, t.Vencimento, t.Status, t.DataCadastro, t.DataAtualizacao))
                .ToList());

            return ResponseQueryResult;
        }
    }
}

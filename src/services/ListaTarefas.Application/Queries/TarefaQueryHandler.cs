using ListaTarefas.Application.Enums;
using ListaTarefas.Application.Services;
using ListaTarefas.Application.ViewModels;
using ListaTarefas.Core.Messages;
using MediatR;

namespace ListaTarefas.Application.Queries
{
    public class TarefaQueryHandler : QueryHandler<List<RetornoViewModel>>, IRequestHandler<ListarTarefasQuery, IEnumerable<RetornoViewModel>>
    {
        private readonly ICadastroTarefaService _cadastroTarefaService;

        public TarefaQueryHandler(ICadastroTarefaService cadastroTarefaService  )
        {
            _cadastroTarefaService = cadastroTarefaService;
        }
        public async Task<IEnumerable<RetornoViewModel>> Handle(ListarTarefasQuery request, CancellationToken cancellationToken)
        {
            var tarefas = await _cadastroTarefaService.Listar();

            if (tarefas == null || tarefas.Count() == 0) return ResponseQueryResult;

            ResponseQueryResult.AddRange(
               tarefas
                   .GroupBy(d => d.Status)
                   .Select(h =>
                       new RetornoViewModel
                       {
                           Status = h.Key,
                           Descricao = ((StatusEnum)h.Key).ToString(),
                           Tarefas = h
                               .Select(t => new TarefaViewModel(t.Id, t.Descricao, t.Vencimento, t.Status, t.DataCadastro, t.DataAtualizacao))
                               .ToList()
                       })
               .ToList());


            return ResponseQueryResult;
        }
    }
}

using ListaTarefas.Application.Services;
using ListaTarefas.Application.ViewModels;
using ListaTarefas.Core.Communication;
using ListaTarefas.Core.Messages;
using MediatR;

namespace ListaTarefas.Application.Queries
{
    public class TarefaQueryHandler : QueryHandler,IRequestHandler<ListarTarefasQuery, ResponseQueryResult>
    {
        private readonly ICadastroTarefaService _cadastroTarefaService;

        public TarefaQueryHandler(ICadastroTarefaService cadastroTarefaService  )
        {
            _cadastroTarefaService = cadastroTarefaService;
        }
        public async Task<ResponseQueryResult> Handle(ListarTarefasQuery request, CancellationToken cancellationToken)
        {
            var tarefas = await _cadastroTarefaService.Listar();

            if (tarefas == null || tarefas.Count() == 0) return ResponseQueryResult;
            Adicionar(tarefas.Select(t => new TarefaViewModel(t.Id, t.Descricao, t.Vencimento, t.Status, t.DataCadastro, t.DataAtualizacao)));
            return ResponseQueryResult;
        }
    }
}

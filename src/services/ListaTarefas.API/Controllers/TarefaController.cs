using ListaTarefas.Application.Commands;
using ListaTarefas.Application.ViewModels;
using ListaTarefas.Core.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace ListaTarefas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : MainController
    {
        private readonly IMediatorHandler _mediator;

        public TarefaController(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("nova-tarefa")]
        public async Task<IActionResult> CadastrarTarefa(CadastrarTarefaViewModel viewModel)
        {
            var comando = new CadastrarTarefaCommand(viewModel.Descricao, viewModel.Vencimento);

            var result = await _mediator.EnviarComando<CadastrarTarefaCommand>(comando);
            if (!OperacaoValida()) CustomResponse(result);

            return CustomResponse();
        }
    }
}

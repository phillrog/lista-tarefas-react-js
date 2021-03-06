using ListaTarefas.Application.Commands;
using ListaTarefas.Application.Queries;
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
            var comando = new SolicitarCadastroTarefaCommand(viewModel.Descricao, viewModel.Vencimento, viewModel.Status);
            var result = await _mediator.EnviarComando<SolicitarCadastroTarefaCommand>(comando);
            if (!OperacaoValida()) CustomResponse(result);

            return CustomResponse();
        }

        [HttpPut("editar-tarefa/{id}")]
        public async Task<IActionResult> EditarTarefa(Guid id, EditarTarefaViewModel viewModel)
        {
            if (id != viewModel.Id) return BadRequest();

            var comando = new SolicitarEdicaoTarefaCommand(viewModel.Id,viewModel.Descricao, viewModel.Vencimento, viewModel.Status);
            var result = await _mediator.EnviarComando<SolicitarEdicaoTarefaCommand>(comando);
            if (!OperacaoValida()) CustomResponse(result);

            return CustomResponse();
        }

        [HttpDelete("remover-tarefa/{id}")]
        public async Task<IActionResult> RemoverTarefa(Guid id)
        {
            if (id == Guid.Empty) return BadRequest();

            var comando = new SolicitarRemocaoTarefaCommand(id);
            var result = await _mediator.EnviarComando<SolicitarRemocaoTarefaCommand>(comando);
            if (!OperacaoValida()) CustomResponse(result);

            return CustomResponse();
        }

        [HttpGet("listar")]
        public async Task<IActionResult> Listar()
        {            
            var query = new ListarTarefasQuery();
            var result = await _mediator.EnviarQuery<ListarTarefasQuery, IEnumerable<RetornoViewModel>>(query);

            return CustomResponse(new { Data = result });
        }
    }
}

using ListaTarefas.Application.Commands;
using ListaTarefas.Core.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace ListaTarefas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly IMediatorHandler _mediator;

        public TarefaController(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("nova-tarefa")]
        public async Task<IActionResult> CadastrarTarefa(CadastrarTarefaCommand comando)
        {
            var result = await _mediator.EnviarComando<CadastrarTarefaCommand>(comando);
            
            return Ok();
        }
    }
}

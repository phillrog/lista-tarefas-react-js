using ListaTarefas.Application.DTOs;
using ListaTarefas.Domain.Entities;
using ListaTarefas.Domain.Enums;
using ListaTarefas.Domain.Interfaces;

namespace ListaTarefas.Application.Services
{

    public interface ICadastroTarefaService
    {
        Task Cadastrar(TarefaDTO tarefa);
        Task Editar(TarefaDTO tarefa);
    }

    public class CadastroTarefaService : ICadastroTarefaService
    {
        private readonly ITarefaService _tarefaServiceDomain;

        public CadastroTarefaService(ITarefaService tarefaService)
        {
            _tarefaServiceDomain = tarefaService;
        }
        public async Task Cadastrar(TarefaDTO tarefa)
        {
            await _tarefaServiceDomain.Adicionar(new Tarefa(tarefa.Descricao, tarefa.Vencimento, StatusEnum.AFazer));
        }

        public async Task Editar(TarefaDTO tarefa)
        {
            await _tarefaServiceDomain.Editar(new Tarefa(tarefa.Id, tarefa.Descricao, tarefa.Vencimento, (StatusEnum)tarefa.Status, DateTime.Now));
        }
    }
}

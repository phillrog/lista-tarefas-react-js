using ListaTarefas.Domain.Entities;
using ListaTarefas.Domain.Interfaces;

namespace ListaTarefas.Domain.Services
{
    public class TarefaService : ITarefaService
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaService(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }
        public async Task Adicionar(Tarefa tarefa)
        {
            await _tarefaRepository.Adicionar(tarefa);
            /// TODO: Notificar o front-end cadastro com sucesso
            await _tarefaRepository.UnitOfWork.Commit();
        }
    }
}

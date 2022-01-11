﻿using ListaTarefas.Domain.Entities;
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

        public async Task Editar(Tarefa tarefa)
        {
            var tarefaPataAtualizar = await _tarefaRepository.ObterPorId(tarefa.Id);

            tarefaPataAtualizar.UltimaAtualizacaoEm(tarefa.DataAtualizacao.Value);
            tarefaPataAtualizar.AtualizarDescricao(tarefa.Descricao);
            tarefaPataAtualizar.AtualizarStatus(tarefa.Status);
            tarefaPataAtualizar.AtualizarVencimento(tarefa.Vencimento);

            await _tarefaRepository.Atualizar(tarefaPataAtualizar);
            /// TODO: Notificar o front-end cadastro com sucesso
            await _tarefaRepository.UnitOfWork.Commit();
        }

        public Task Remover(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

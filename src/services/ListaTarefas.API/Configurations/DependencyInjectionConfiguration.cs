﻿using FluentValidation.Results;
using ListaTarefas.Application.Commands;
using ListaTarefas.Application.Events;
using ListaTarefas.Application.Services;
using ListaTarefas.Core.Mediator;
using ListaTarefas.Domain.Interfaces;
using ListaTarefas.Domain.Services;
using ListaTarefas.Infra;
using ListaTarefas.Infra.Data.Repositories;
using MediatR;

namespace ListaTarefas.API.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void RegisterDependency(this IServiceCollection services)
        {
            services.AddScoped<ListaTarefaContext>();
            services.AddScoped<ITarefaRepository, TarefaRepository>();

            services.AddScoped<IMediatorHandler, MediatorHandler>();

            services.AddScoped<IRequestHandler<SolicitarCadastroTarefaCommand, ValidationResult>, TarefaHandler>();
            services.AddScoped<IRequestHandler<SolicitarEdicaoTarefaCommand, ValidationResult>, TarefaHandler>();

            services.AddScoped<INotificationHandler<CadastroSolicitadoEvent>, TarefaEventHandler>();

            services.AddScoped<ICadastroTarefaService, CadastroTarefaService>();
            services.AddScoped<ITarefaService, TarefaService>();
        }
    }
}

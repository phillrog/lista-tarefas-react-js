using ListaTarefas.Application.Consumers;
using MassTransit;
using GreenPipes;
using RabbitMQ.Client;

namespace ListaTarefas.API.Configurations
{
    public static class MassTransitConfiguration
    {
        public static void AddMassTransitApi(this IServiceCollection services, ConfigurationManager configuration)
        {
            var busSettings = new AppSettingsBus();
            configuration.GetSection("AppSettingsBus").Bind(busSettings);

            services.AddMassTransit(bus =>
            {
                bus.SetKebabCaseEndpointNameFormatter();
                bus.AddConsumer<CadastroSolicitadoConsumer>();

                bus.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(configuration["RabbitMq:HostAddress"]);
                   

                    cfg.Durable = true;
                    cfg.AutoDelete = false;
                    cfg.ReceiveEndpoint(busSettings.Queue, opt =>
                    {
                        opt.PrefetchCount = busSettings.PrefetchCount;
                        opt.UseMessageRetry(x => x.Interval(busSettings.RetryCount, busSettings.RetryInterval));
                        opt.UseInMemoryOutbox();
                        opt.ConfigureConsumer<CadastroSolicitadoConsumer>(ctx);
                        opt.Bind("cadastro-solicitado-listener", s =>
                        {
                            s.ExchangeType = ExchangeType.Direct;
                        });

                    });
                });
            });
            services.AddMassTransitHostedService(true);
        }
    }
}

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
            var busSettings = new List<AppSettingsBus>();
            configuration.GetSection("AppSettingsBus").Bind(busSettings);

            services.AddMassTransit(bus =>
            {
                bus.SetKebabCaseEndpointNameFormatter();
                bus.AddConsumer<CadastroSolicitadoConsumer>();
                bus.AddConsumer<EdicaoCadastroSolicitadoConsumer>();

                bus.UsingRabbitMq((ctx, cfg) =>
                {
                    cfg.Host(configuration["RabbitMq:HostAddress"]);
                   

                    cfg.Durable = true;
                    cfg.AutoDelete = false;
                    cfg.ReceiveEndpoint(configuration.GetSection("AppSettingsBus:CadastroSolicitadoConsumer:Queue").Value, opt =>
                    {
                        opt.PrefetchCount = Convert.ToInt32(configuration.GetSection("AppSettingsBus:CadastroSolicitadoConsumer:PrefetchCount").Value);
                        opt.UseMessageRetry(x => x.Interval(Convert.ToInt32(configuration.GetSection("AppSettingsBus:CadastroSolicitadoConsumer:RetryCount").Value)
                            , Convert.ToInt32(configuration.GetSection("AppSettingsBus:CadastroSolicitadoConsumer:RetryInterval").Value)));
                        opt.UseInMemoryOutbox();
                        opt.ConfigureConsumer<CadastroSolicitadoConsumer>(ctx);
                        opt.Bind(configuration.GetSection("AppSettingsBus:CadastroSolicitadoConsumer:Consumer").Value, s =>
                        {
                            s.ExchangeType = ExchangeType.Direct;
                        });

                    });

                    cfg.ReceiveEndpoint(configuration.GetSection("AppSettingsBus:EdicaoCadastroSolicitadoConsumer:Queue").Value, opt =>
                    {
                        opt.PrefetchCount = Convert.ToInt32(configuration.GetSection("AppSettingsBus:EdicaoCadastroSolicitadoConsumer:PrefetchCount").Value);
                        opt.UseMessageRetry(x => x.Interval(Convert.ToInt32(configuration.GetSection("AppSettingsBus:EdicaoCadastroSolicitadoConsumer:RetryCount").Value)
                            , Convert.ToInt32(configuration.GetSection("AppSettingsBus:EdicaoCadastroSolicitadoConsumer:RetryInterval").Value)));
                        opt.UseInMemoryOutbox();
                        opt.ConfigureConsumer<EdicaoCadastroSolicitadoConsumer>(ctx);
                        opt.Bind(configuration.GetSection("AppSettingsBus:EdicaoCadastroSolicitadoConsumer:Consumer").Value, s =>
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

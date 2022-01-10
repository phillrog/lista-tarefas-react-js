using ListaTarefas.Infra;
using Microsoft.EntityFrameworkCore;

namespace ListaTarefas.API.Configurations
{
    public static class ApiConfiguration
    {
        public static void AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ListaTarefaContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("localhost")),
                ServiceLifetime.Scoped);                       

            services.AddCors(options =>
            {
                options.AddPolicy("Total",
                    builder =>
                        builder
                            .AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader());
            });
        }
    }
}

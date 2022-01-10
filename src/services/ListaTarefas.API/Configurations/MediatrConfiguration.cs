using MediatR;

namespace ListaTarefas.API.Configurations
{
    public static class MediatrConfiguration
    {
        public static void AddMediatRApi(this IServiceCollection services)
        {
            services.AddMediatR(typeof(Program));
        }
    }
}

using ExemploRelacionamentoEntity.Service.Interface;
using ExemploRelacionamentoEntity.Service.Service;
using Microsoft.Extensions.DependencyInjection;

namespace ExemploRelacionamentoEntity.Service
{
    public static class Boostrapper
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services
                .AddScoped<IClienteService, ClienteService>()
                .AddScoped<IMedicoService, MedicoService>();

            return services;
        }
    }
}

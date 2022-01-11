using ExemploRelacionamentoEntity.Data.Repository;
using ExemploRelacionamentoEntity.Domain.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace ExemploRelacionamentoEntity.Data
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddRepository(this IServiceCollection services)
        {
            services
                .AddScoped<IClienteRepository, ClienteRepository>();

            return services;
        }
    }
}

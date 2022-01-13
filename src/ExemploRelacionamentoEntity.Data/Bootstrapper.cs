using ExemploRelacionamentoEntity.Data.Repository;
using ExemploRelacionamentoEntity.Domain.Interface;
using Microsoft.Extensions.DependencyInjection;

namespace ExemploRelacionamentoEntity.Data
{
    public static class Bootstrapper
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services
                .AddScoped<IClienteRepository, ClienteRepository>()
                .AddScoped<IMedicoRepository, MedicoRepository>()
                .AddScoped<IEspecialidadeRepository, EspecialidadeRepository>();

            return services;
        }
    }
}

using ExemploRelacionamentoEntity.Service.Interface;
using ExemploRelacionamentoEntity.Service.Mapping;
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
                .AddScoped<IMedicoService, MedicoService>()
                .AddScoped<IEspecialidadeService, EspecialidadeService>();

            return services;
        }

        public static IServiceCollection AddMapping(this IServiceCollection services)
        {
            services.AddAutoMapper(
                    typeof(AutoMapperConfiguration)
                );

            return services;
        }

    }
}

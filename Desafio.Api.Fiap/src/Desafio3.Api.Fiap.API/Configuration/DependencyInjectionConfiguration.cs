using Desafio3.Api.Fiap.API.Repositories;
using Desafio3.Api.Fiap.API.Repositories.Interfaces;

namespace Desafio3.Api.Fiap.API.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection service)
        {
            service.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
        }
    }
}

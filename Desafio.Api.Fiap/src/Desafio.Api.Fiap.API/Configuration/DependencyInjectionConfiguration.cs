using Desafio.Api.Fiap.API.Repositories;
using Desafio.Api.Fiap.API.Repositories.Interfaces;
using Desafio.Api.Fiap.API.Services;
using Desafio.Api.Fiap.API.Services.Interfaces;

namespace Desafio.Api.Fiap.API.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection service)
        {
            // Repositories
            service.AddScoped<IUsuarioRepository, UsuarioRepository>();

            // Services
            service.AddScoped<IAutenticacaoService, AutenticacaoService>();
        }
    }
}

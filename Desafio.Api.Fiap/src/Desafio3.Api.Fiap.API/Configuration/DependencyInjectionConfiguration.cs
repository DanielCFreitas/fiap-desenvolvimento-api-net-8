using Desafio3.Api.Fiap.API.Repositories;
using Desafio3.Api.Fiap.API.Repositories.Interfaces;
using Desafio3.Api.Fiap.API.Services;
using Desafio3.Api.Fiap.API.Services.Interfaces;

namespace Desafio3.Api.Fiap.API.Configuration
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection service)
        {
            service.AddScoped<IEnderecoRepository, EnderecoRepository>();
            service.AddScoped<IFuncionarioRepository, FuncionarioRepository>();

            service.AddScoped<IEnderecoServices, EnderecoServices>();
        }
    }
}

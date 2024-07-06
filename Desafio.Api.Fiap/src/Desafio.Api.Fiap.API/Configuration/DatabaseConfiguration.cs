using Npgsql;
using System.Data;

namespace Desafio.Api.Fiap.API.Configuration
{
    public static class DatabaseConfiguration
    {
        public static void AddDatabaseConfiguration(this IServiceCollection service, IConfiguration configuration)
        {
            var stringConexao = configuration.GetValue<string>("ConnectionStringDB");
            service.AddScoped<IDbConnection>((conexao) => new NpgsqlConnection(stringConexao));
        }
    }
}

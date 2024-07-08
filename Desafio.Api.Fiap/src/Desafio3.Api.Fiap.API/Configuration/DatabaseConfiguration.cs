using Npgsql;
using System.Data;

namespace Desafio3.Api.Fiap.API.Configuration
{
    public static class DatabaseConfiguration
    {
        public static void AddDatabaseConfiguration(this IServiceCollection service, IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>("PostgeSQLConnection");
            service.AddScoped<IDbConnection>(connection => new NpgsqlConnection(connectionString));
        }
    }
}

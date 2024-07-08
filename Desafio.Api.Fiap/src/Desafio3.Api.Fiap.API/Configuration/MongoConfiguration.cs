using MongoDB.Driver;

namespace Desafio3.Api.Fiap.API.Configuration
{
    public static class MongoConfiguration
    {
        public static void AddMongoConfiguration(this IServiceCollection service, IConfiguration configuration)
        {
            var connectionString = configuration.GetValue<string>("MongoDBConnection");
            service.AddScoped<IMongoClient>(mongo => new MongoClient(connectionString));
        }
    }
}

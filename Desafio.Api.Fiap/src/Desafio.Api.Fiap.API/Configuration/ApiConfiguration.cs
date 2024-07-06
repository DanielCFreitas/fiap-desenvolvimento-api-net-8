namespace Desafio.Api.Fiap.API.Configuration
{
    public static class ApiConfiguration
    {
        public static void AddApiConfiguration(this IServiceCollection service)
        {
            service.AddControllers();
            service.AddEndpointsApiExplorer();
        }

        public static void UseApiConfiguration(this WebApplication app)
        {
            app.UseHttpsRedirection();
            app.UseIdentityConfiguration();
            app.MapControllers();
        }
    }
}

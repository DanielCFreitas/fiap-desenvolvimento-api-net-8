using Desafio.Api.Fiap.API.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApiConfiguration();
builder.Services.AddIdentityConfiguration(builder.Configuration);
builder.Services.AddDatabaseConfiguration(builder.Configuration);
builder.Services.AddDependencyInjectionConfiguration();
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();
app.UseSwaggerConfiguration(app.Environment);
app.UseApiConfiguration();
app.Run();

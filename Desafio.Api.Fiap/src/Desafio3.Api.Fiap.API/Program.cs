using Desafio3.Api.Fiap.API.Configuration;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApiConfiguration();
builder.Services.AddSwaggerConfiguration();

var app = builder.Build();
app.UseSwaggerConfiguration(builder.Environment);
app.UseApiConfiguration();
app.Run();

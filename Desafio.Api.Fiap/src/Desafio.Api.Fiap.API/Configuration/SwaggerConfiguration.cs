using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Desafio.Api.Fiap.API.Configuration
{
    public static class SwaggerConfiguration
    {
        public static void AddSwaggerConfiguration(this IServiceCollection service)
        {
            service.AddSwaggerGen(swaggerGen =>
            {
                swaggerGen.SwaggerDoc("v1", new OpenApiInfo() { Title = "Desafio FIAP", Version = "v1" });

                // Documentacao do swagger para cada endpoint
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                swaggerGen.IncludeXmlComments(xmlPath);

                // Configuracao da autenticacao para o swagger para exemplificar como usar
                swaggerGen.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "Digite Bearer[espaco]\"token\" no campo abaixo",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                });

                // Adiciona a autenticacao para o swagger
                swaggerGen.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }

        public static void UseSwaggerConfiguration(this IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
        }
    }
}

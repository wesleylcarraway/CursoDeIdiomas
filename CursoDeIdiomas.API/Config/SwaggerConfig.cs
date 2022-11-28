using Microsoft.OpenApi.Models;

namespace CursoDeIdiomas.API.Config
{
    public static class SwaggerConfig
    {
        public static IServiceCollection ConfigureSwagger(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CursoDeIdiomas.API", Version = "v1" });
            });

            return services;
        }
    }
}

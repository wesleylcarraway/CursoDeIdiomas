using CursoDeIdiomas.Application.Interfaces;
using CursoDeIdiomas.Application.Services;
using CursoDeIdiomas.Application.Validations;
using CursoDeIdiomas.Domain.Interfaces;
using CursoDeIdiomas.Infra.Context;
using CursoDeIdiomas.Infra.Repositories;
using CursoDeIdiomas.Infra.UnitOfWork;
using FluentValidation.AspNetCore;

namespace CursoDeIdiomas.API.Config
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<ApplicationContext>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<ITurmaRepository, TurmaRepository>();
            services.AddScoped<IMatriculaRepository, MatriculaRepository>();

            services.AddScoped<IAlunoService, AlunoService>();
            services.AddScoped<ITurmaService, TurmaService>();
            services.AddScoped<IMatriculaService, MatriculaService>();

            services.AddFluentValidation(fv =>
            {
                fv.AutomaticValidationEnabled = false;
                fv.RegisterValidatorsFromAssemblyContaining<AlunoAddRequestValidator>();
            });

            return services;
        }
    }
}

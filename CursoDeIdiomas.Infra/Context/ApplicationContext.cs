using CursoDeIdiomas.Domain.Core;
using CursoDeIdiomas.Domain.Models;
using CursoDeIdiomas.Domain.Models.Enums;
using CursoDeIdiomas.Infra.Mappings;
using Microsoft.EntityFrameworkCore;

namespace CursoDeIdiomas.Infra.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Turma> Turmas { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }

        public DbSet<Curso> Cursos { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationContext).Assembly);

            modelBuilder.ApplyConfiguration(new EnumerationMap<Curso>());

            modelBuilder
                .Entity<Curso>()
                .HasData(Enumeration.GetAll<Curso>());
        }
    }
}

using CursoDeIdiomas.Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;

namespace CursoDeIdiomas.Infra.Mappings
{
    public class AlunoMap : RegistroMap<Aluno>
    {
        public AlunoMap() : base("tb_aluno")
        {
        }

        public override void Configure(EntityTypeBuilder<Aluno> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Nome).HasColumnName("nome").HasColumnType("varchar(50)").IsRequired().HasMaxLength(100);
            builder.Property(x => x.Email).HasColumnName("email").IsRequired().HasMaxLength(100);
            builder.Property(x => x.Cpf).HasColumnName("cpf").HasColumnType("varchar(11)").IsRequired().HasMaxLength(11);

            builder.HasMany(x => x.Turmas)
            .WithMany(x => x.Alunos)
            .UsingEntity<Matricula>(
                x => x.HasOne(p => p.Turma).WithMany().HasForeignKey(x => x.TurmaId),
                x => x.HasOne(p => p.Aluno).WithMany().HasForeignKey(x => x.AlunoId),
                x =>
                {
                    x.ToTable("tb_matricula");
                    x.HasKey(p => new { p.TurmaId, p.AlunoId });
                    x.Property(x => x.Numero)
                     .HasColumnName("numero")
                     .IsRequired();
                    x.Ignore(p => p.Id);
                });
        }
    }
}

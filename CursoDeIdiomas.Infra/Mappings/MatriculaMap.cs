/*using CursoDeIdiomas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoDeIdiomas.Infra.Mappings
{
    public class MatriculaMap : RegistroMap<Matricula>
    {
        public MatriculaMap() : base("tb_matricula")
        {
        }

        public override void Configure(EntityTypeBuilder<Matricula> builder)
        {
            base.Configure(builder);

            builder
                .Property(x => x.Numero)
                .HasColumnName("numero")
                .IsRequired();

            builder
                .HasOne(x => x.Aluno)
                .WithMany()
                .HasForeignKey(x => x.AlunoId)
                .IsRequired()
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);

            builder
                .HasOne(x => x.Turma)
                .WithMany()
                .HasForeignKey(x => x.TurmaId)
                .IsRequired()
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Cascade);
        }
    }
}*/

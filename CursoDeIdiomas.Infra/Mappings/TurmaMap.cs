using CursoDeIdiomas.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoDeIdiomas.Infra.Mappings
{
    public class TurmaMap : RegistroMap<Turma>
    {
        public TurmaMap() : base("tb_turma")
        {
        }

        public override void Configure(EntityTypeBuilder<Turma> builder)
        {
            base.Configure(builder);

            builder
                .Property(x => x.Numero)
                .HasColumnName("numero")
                .HasMaxLength(1)
                .IsRequired();

            builder
                .Property(x => x.AnoLetivo)
                .HasDefaultValueSql("getDate()");

            builder
                .HasOne(x => x.Curso)
                .WithMany()
                .HasForeignKey(x => x.Curso)
                .IsRequired()
                .OnDelete(Microsoft.EntityFrameworkCore.DeleteBehavior.Restrict);
        }
    }
}

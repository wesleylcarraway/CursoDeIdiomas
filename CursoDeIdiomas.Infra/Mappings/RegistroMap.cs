using CursoDeIdiomas.Domain.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoDeIdiomas.Infra.Mappings
{
    public class RegistroMap<T> : IEntityTypeConfiguration<T> where T : Registro
    {
        private readonly string _tableName;
        public RegistroMap(string tableName)
        {
            _tableName = tableName;
        }
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            if (!string.IsNullOrEmpty(_tableName)) builder.ToTable(_tableName);

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();

            builder
                .Property(x => x.CriadoEm)
                .HasDefaultValueSql("getDate()");

            builder
                .Property(x => x.AtualizadoEm)
                .ValueGeneratedOnUpdate()
                .HasDefaultValueSql("getDate()")
                .Metadata.SetAfterSaveBehavior(PropertySaveBehavior.Save);
        }
    }
}

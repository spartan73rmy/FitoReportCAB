using Chikisistema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chikisistema.Persistence.Configurations
{
    public class CursoConfiguration : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.HasKey(el => el.Id);

            builder.HasIndex(el => el.IdMaestro);

            builder.HasIndex(el => el.IdMateria);

            builder.HasIndex(el => el.CodigoAcceso).IsUnique(true);

            builder.Property(el => el.CodigoAcceso).IsRequired();

            builder.Property(el => el.Descripcion).IsRequired().IsUnicode(true);

            builder.Property(el => el.FechaFin);

            builder.Property(el => el.FechaInicio);

            builder.HasOne(el => el.IdMaestroNavigation)
                .WithMany(el => el.Curso)
                .HasForeignKey(el => el.IdMaestro)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Curso_Usuario");

            builder.HasOne(el => el.IdMateriaNavigation)
                .WithMany(el => el.Curso)
                .HasForeignKey(el => el.IdMateria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Curso_Materia");
        }
    }
}

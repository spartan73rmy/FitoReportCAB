using Chikisistema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chikisistema.Persistence.Configurations
{
    public class ActividadCursoConfiguration : IEntityTypeConfiguration<ActividadCurso>
    {
        public void Configure(EntityTypeBuilder<ActividadCurso> builder)
        {
            builder.HasKey(el => el.Id);

            builder.HasIndex(el => el.IdUnidad);

            builder.Property(el => el.BloquearEnvios)
                .IsRequired();

            builder.Property(el => el.FechaLimite)
                .IsRequired();

            builder.Property(el => el.FechaActivacion);

            builder.HasIndex(el => el.IdTipoActividad);

            builder.Property(el => el.Titulo)
                .IsRequired()
                .IsUnicode(true);

            builder.HasIndex(el => el.Valor);

            builder.Property(el => el.Contenido)
                .IsRequired()
                .IsUnicode(true);

            builder.HasOne(el => el.Unidad)
                .WithMany(el => el.Actividades)
                .HasForeignKey(el => el.IdUnidad)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ActividadCurso_Unidad");

            builder.HasOne(el => el.TipoActividad)
                .WithMany(el => el.Actividades)
                .HasForeignKey(el => el.IdTipoActividad)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ActividadCurso_TipoActividad");
        }
    }
}

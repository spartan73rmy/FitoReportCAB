using Chikisistema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chikisistema.Persistence.Configurations
{
    class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.HasKey(el => el.Id);

            builder.Property(el => el.Coords)
                .IsRequired();

            builder.Property(el => el.Cultivo)
                .IsRequired();

            builder.Property(el => el.FechaAlta);

            builder.Property(el => el.Lugar)
                .IsRequired()
                .IsUnicode(true);

            builder.Property(el => el.Observaciones)
                .IsRequired()
                .IsUnicode(true);

            builder.Property(el => el.Predio)
                .IsRequired()
                .IsUnicode(true);

            builder.Property(el => el.Productor)
                .IsRequired()
                .IsUnicode(true);

            builder.Property(el => el.Ubicacion)
                .IsRequired()
                .IsUnicode(true);

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

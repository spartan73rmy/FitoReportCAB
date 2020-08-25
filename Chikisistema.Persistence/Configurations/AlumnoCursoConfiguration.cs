using Chikisistema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chikisistema.Persistence.Configurations
{
    public class AlumnoCursoConfiguration : IEntityTypeConfiguration<AlumnoCurso>
    {
        public void Configure(EntityTypeBuilder<AlumnoCurso> builder)
        {
            builder.HasKey(el => el.Id);

            builder.HasIndex(el => el.IdAlumno);

            builder.HasIndex(el => el.IdCurso);

            builder.HasIndex(el => new { el.IdAlumno, el.IdCurso }).IsUnique();

            builder.HasOne(el => el.IdAlumnoNavigation)
                .WithMany(el => el.AlumnoCurso)
                .HasForeignKey(el => el.IdAlumno)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_AlumnoCurso_Usuario");

            builder.HasOne(el => el.IdCursoNavigation)
                .WithMany(el => el.AlumnoCurso)
                .HasForeignKey(el => el.IdCurso)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_AlumnoCurso_Curso");
        }
    }
}

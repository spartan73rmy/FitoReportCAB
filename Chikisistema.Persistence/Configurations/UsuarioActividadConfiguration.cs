using Chikisistema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chikisistema.Persistence.Configurations
{
    public class UsuarioActividadConfiguration : IEntityTypeConfiguration<UsuarioActividad>
    {
        public void Configure(EntityTypeBuilder<UsuarioActividad> builder)
        {
            builder.HasKey(el => el.Id);

            builder.HasIndex(el => el.IdActividad);

            builder.HasIndex(el => el.IdUsuario);

            builder.HasIndex(el => el.IdArchivo);

            builder.HasIndex(el => new { el.IdActividad, el.IdUsuario }).IsUnique();

            builder.Property(el => el.Contenido)
                .IsUnicode(true);


            builder.Property(el => el.Calificacion);

            builder.Property(el => el.FechaEntrega)
                .IsRequired();

            builder.HasOne(el => el.Archivo)
                .WithMany(el => el.UsuarioActividades)
                .HasForeignKey(el => el.IdArchivo)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK_UsuarioActividad_ArchivoUsuario");


            builder.HasOne(el => el.ActividadCurso)
                .WithMany(el => el.UsuarioActividades)
                .HasForeignKey(el => el.IdActividad)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_UsuarioActividad_ActividadCurso");

            builder.HasOne(el => el.IdUsuarioNavigation)
                .WithMany(el => el.UsuarioActividad)
                .HasForeignKey(el => el.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UsuarioActividad_Usuario");
        }
    }
}

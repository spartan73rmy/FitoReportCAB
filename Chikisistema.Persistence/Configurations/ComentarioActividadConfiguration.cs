using Chikisistema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chikisistema.Persistence.Configurations
{
    public class ComentarioActividadConfiguration : IEntityTypeConfiguration<ComentarioActividad>
    {
        public void Configure(EntityTypeBuilder<ComentarioActividad> builder)
        {
            builder.HasKey(el => el.Id);

            builder.HasIndex(el => el.IdActividad);
            builder.HasIndex(el => el.IdComentarioPadre);

            builder.Property(el => el.Contenido).IsUnicode().IsRequired();
            builder.Property(el => el.IdUsuario).IsRequired();

            builder.HasOne(el => el.Actividad)
                .WithMany(el => el.Comentarios)
                .HasForeignKey(el => el.IdActividad)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ComentarioActividad_ActividadCurso");


            builder.HasOne(el => el.ComentarioPadre)
                .WithMany(el => el.Hijos)
                .HasForeignKey(el => el.IdComentarioPadre)
                .HasConstraintName("FK_ComentarioActividad_ComentarioActividad");

            builder.HasOne(el => el.Usuario)
                .WithMany(el => el.Comentarios)
                .HasForeignKey(el => el.IdUsuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ComentarioActividad_Usuario");
        }
    }
}

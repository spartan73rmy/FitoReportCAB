using Chikisistema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chikisistema.Persistence.Configurations
{
    public class MaterialApoyoActividadConfiguration : IEntityTypeConfiguration<MaterialApoyoActividad>
    {
        public void Configure(EntityTypeBuilder<MaterialApoyoActividad> builder)
        {
            builder.HasKey(el => el.Id);

            builder.HasIndex(el => el.IdActividad);
            builder.HasIndex(el => el.IdArchivoUsuario);

            builder.HasIndex(el => new { el.IdActividad, el.IdArchivoUsuario }).IsUnique();


            builder.HasOne(el => el.Actividad)
                .WithMany(el => el.MaterialApoyo)
                .HasForeignKey(el => el.IdActividad)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_MaterialApoyo_Actividad");

            builder.HasOne(el => el.ArchivoUsuario)
                .WithMany(el => el.MaterialApoyo)
                .HasForeignKey(el => el.IdArchivoUsuario)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_MaterialApoyo_ArchivoUsuario");
        }
    }
}

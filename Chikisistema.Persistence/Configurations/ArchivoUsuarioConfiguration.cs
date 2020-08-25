using Chikisistema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chikisistema.Persistence.Configurations
{
    public class ArchivoUsuarioConfiguration : IEntityTypeConfiguration<ArchivoUsuario>
    {
        public void Configure(EntityTypeBuilder<ArchivoUsuario> builder)
        {
            builder.HasKey(el => el.Id);

            builder.HasIndex(el => el.IdUsuario);

            builder.Property(el => el.Hash).IsRequired();
            builder.Property(el => el.ContentType).IsRequired();
            builder.Property(el => el.Nombre).IsRequired();

            builder.HasOne(el => el.IdUsuarioNavigation)
                .WithMany(el => el.ArchivoUsuario)
                .HasForeignKey(el => el.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ArchivoUsuario_Usuario");
        }
    }
}

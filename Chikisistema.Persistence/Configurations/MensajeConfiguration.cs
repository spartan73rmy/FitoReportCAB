using Chikisistema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chikisistema.Persistence.Configurations
{
    public class MensajeConfiguration : IEntityTypeConfiguration<Mensaje>
    {
        public void Configure(EntityTypeBuilder<Mensaje> builder)
        {
            builder.HasKey(el => el.Id);

            builder.HasIndex(el => el.IdUsuarioEnvia);

            builder.HasIndex(el => el.IdUsuarioRecibe);

            builder.Property(el => el.FechaMensaje);

            builder.Property(el => el.TextoMensaje)
                .IsRequired()
                .IsUnicode(true);

            builder.HasOne(el => el.IdUsuarioEnviaNavigation)
                .WithMany(el => el.MensajeIdUsuarioEnviaNavigation)
                .HasForeignKey(el => el.IdUsuarioEnvia)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mensaje_Usuario");

            builder.HasOne(el => el.IdUsuarioRecibeNavigation)
                .WithMany(el => el.MensajeIdUsuarioRecibeNavigation)
                .HasForeignKey(el => el.IdUsuarioRecibe)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Mensaje_Usuario1");
        }
    }
}

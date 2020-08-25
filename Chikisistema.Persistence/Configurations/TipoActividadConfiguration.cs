using Chikisistema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chikisistema.Persistence.Configurations
{
    public class TipoActividadConfiguration : IEntityTypeConfiguration<TipoActividad>
    {
        public void Configure(EntityTypeBuilder<TipoActividad> builder)
        {
            builder.HasKey(el => el.Id)
                    .HasName("PK_Actividad");

            builder.Property(el => el.Nombre)
                .IsRequired()
                .HasMaxLength(200)
                .IsUnicode(true);
        }
    }
}

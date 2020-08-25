using Chikisistema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chikisistema.Persistence.Configurations
{
    public class MateriaConfiguration : IEntityTypeConfiguration<Materia>
    {
        public void Configure(EntityTypeBuilder<Materia> builder)
        {
            builder.HasKey(el => el.Id);

            builder.Property(el => el.Nombre)
                .IsRequired()
                .HasMaxLength(100)
                .IsUnicode(true);
        }
    }
}

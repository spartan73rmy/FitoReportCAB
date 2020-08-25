using Chikisistema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chikisistema.Persistence.Configurations
{
    public class UnidadConfiguration : IEntityTypeConfiguration<Unidad>
    {
        public void Configure(EntityTypeBuilder<Unidad> builder)
        {
            builder.HasKey(el => el.Id);

            builder.HasIndex(el => el.IdCurso);

            builder.Property(el => el.Descripcion)
                .IsRequired()
                .IsUnicode(true);

            builder.HasOne(el => el.Curso)
                .WithMany(el => el.Unidades)
                .HasForeignKey(el => el.IdCurso)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Unidad_Curso");
        }
    }
}

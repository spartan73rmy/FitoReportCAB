using Chikisistema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chikisistema.Persistence.Configurations
{
    public class EnfermedadConfiguration : IEntityTypeConfiguration<Enfermedad>
    {
        public void Configure(EntityTypeBuilder<Enfermedad> builder)
        {
            builder.HasKey(el => el.Id);

            builder.HasIndex(el => el.IdReport);

            builder.Property(el => el.Nombre)
            .IsRequired()
            .IsUnicode(true);

            builder.HasOne(el => el.Report)
              .WithMany(el => el.Enfermedades)
              .HasForeignKey(el => el.IdReport)
              .OnDelete(DeleteBehavior.Cascade)
              .HasConstraintName("FK_Enfermedad_Report");
        }
    }
}

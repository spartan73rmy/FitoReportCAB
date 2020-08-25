using Chikisistema.Domain;
using Chikisistema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chikisistema.Persistence.Configurations
{
    public class PlagaConfiguration : IEntityTypeConfiguration<Plaga>
    {
        public PlagaConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<Plaga> builder)
        {
            builder.HasKey(el => el.Id);

            builder.HasIndex(el => el.IdReport);

            builder.Property(el => el.Nombre)
            .IsRequired()
            .IsUnicode(true);

            builder.HasOne(el => el.Report)
              .WithMany(el => el.Plagas)
              .HasForeignKey(el => el.IdReport)
              .OnDelete(DeleteBehavior.Cascade)
              .HasConstraintName("FK_Plaga_Report");
        }
    }
}

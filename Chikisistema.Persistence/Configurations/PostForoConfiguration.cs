using Chikisistema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Chikisistema.Persistence.Configurations
{
    public class PostForoConfiguration : IEntityTypeConfiguration<PostForo>
    {
        public void Configure(EntityTypeBuilder<PostForo> builder)
        {
            builder.HasKey(el => el.Id);

            builder.HasIndex(el => el.IdAutor);

            builder
                .Property(el => el.Contenido)
                .IsRequired()
                .IsUnicode(true);

            builder.HasOne(el => el.Autor)
                .WithMany(el => el.PostsForo)
                .HasForeignKey(el => el.IdAutor)
                .HasConstraintName("FK_PostForo_Usuario");
        }
    }
}

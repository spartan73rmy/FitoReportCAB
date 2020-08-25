using Chikisistema.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Chikisistema.Persistence.Configurations
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.HasKey(el => el.Id);

            builder.HasIndex(el => el.IdReport);

            builder.Property(el => el.IngredienteActivo)
            .IsRequired()
            .IsUnicode(true);

            builder.Property(el => el.IntervaloSeguridad)
            .IsRequired()
            .IsUnicode(true);

            builder.Property(el => el.NombreProducto)
            .IsRequired()
            .IsUnicode(true);

            builder.HasOne(el => el.Report)
              .WithMany(el => el.Productos)
              .HasForeignKey(el => el.IdReport)
              .OnDelete(DeleteBehavior.Cascade)
              .HasConstraintName("FK_Productos_Reporte");
        }
    }
}

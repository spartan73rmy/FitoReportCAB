using FitoReport.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitoReport.Persistence.Configurations
{
    //    public class ArchivoReporteConfiguration : IEntityTypeConfiguration<ArchivoReporte>
    //    {
    //        //public void Configure(EntityTypeBuilder<ArchivoReporte> builder)
    //        //{
    //        //    builder.HasKey(el => el.Id);

    //        //    builder.HasIndex(el => el.IdReporte);

    //        //    builder.HasIndex(el => el.IdUsuario);

    //        //    builder.HasIndex(el => el.IdArchivo);

    //        //    builder.HasIndex(el => new { el.IdReporte, el.IdUsuario }).IsUnique();

    //        //    builder.HasOne(el => el.Archivo)
    //        //        .WithMany(el => el.UsuarioActividades)
    //        //        .HasForeignKey(el => el.IdArchivo)
    //        //        .OnDelete(DeleteBehavior.SetNull)
    //        //        .HasConstraintName("FK_UsuarioActividad_ArchivoUsuario");


    //        //    builder.HasOne(el => el.ActividadCurso)
    //        //        .WithMany(el => el.UsuarioActividades)
    //        //        .HasForeignKey(el => el.IdActividad)
    //        //        .OnDelete(DeleteBehavior.Cascade)
    //        //        .HasConstraintName("FK_UsuarioActividad_ActividadCurso");

    //        //    builder.HasOne(el => el.IdUsuarioNavigation)
    //        //        .WithMany(el => el.UsuarioActividad)
    //        //        .HasForeignKey(el => el.IdUsuario)
    //        //        .OnDelete(DeleteBehavior.ClientSetNull)
    //        //        .HasConstraintName("FK_UsuarioActividad_Usuario");
    //        //}
    //    }
}

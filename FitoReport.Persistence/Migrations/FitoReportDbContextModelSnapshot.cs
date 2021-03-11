﻿// <auto-generated />
using System;
using FitoReport.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FitoReport.Persistence.Migrations
{
    [DbContext(typeof(FitoReportDbContext))]
    partial class FitoReportDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("FitoReport.Domain.Entities.Archivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ContentType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Hash")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("IdReporte")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdReporte");

                    b.HasIndex("IdUsuario");

                    b.ToTable("ArchivoUsuario");
                });

            modelBuilder.Entity("FitoReport.Domain.Entities.Enfermedad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdReport")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.HasIndex("IdReport");

                    b.ToTable("Enfermedad");
                });

            modelBuilder.Entity("FitoReport.Domain.Entities.EtapaFenologica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdReport")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.HasIndex("IdReport");

                    b.ToTable("EtapaFenologica");
                });

            modelBuilder.Entity("FitoReport.Domain.Entities.Plaga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdReport")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.HasIndex("IdReport");

                    b.ToTable("Plaga");
                });

            modelBuilder.Entity("FitoReport.Domain.Entities.Producto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Cantidad")
                        .HasColumnType("float");

                    b.Property<string>("Concentracion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .IsUnicode(true);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdReport")
                        .HasColumnType("int");

                    b.Property<string>("IngredienteActivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .IsUnicode(true);

                    b.Property<string>("IntervaloSeguridad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .IsUnicode(true);

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("NombreProducto")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .IsUnicode(true);

                    b.Property<string>("Unidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.HasIndex("IdReport");

                    b.ToTable("Producto");
                });

            modelBuilder.Entity("FitoReport.Domain.Entities.Reporte", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Cultivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Latitude")
                        .HasColumnType("float");

                    b.Property<int>("Litros")
                        .HasColumnType("int");

                    b.Property<double>("Longitud")
                        .HasColumnType("float");

                    b.Property<string>("Lugar")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .IsUnicode(true);

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Observaciones")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .IsUnicode(true);

                    b.Property<string>("Predio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .IsUnicode(true);

                    b.Property<string>("Productor")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .IsUnicode(true);

                    b.Property<string>("Ubicacion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.ToTable("Reporte");
                });

            modelBuilder.Entity("FitoReport.Domain.Entities.ReporteEnfermedad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdEnfermedad")
                        .HasColumnType("int");

                    b.Property<int>("IdReporte")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdEnfermedad");

                    b.HasIndex("IdReporte");

                    b.ToTable("ReporteEnfermedad");
                });

            modelBuilder.Entity("FitoReport.Domain.Entities.ReporteEtapaFenologica", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdEtapaFenologica")
                        .HasColumnType("int");

                    b.Property<int>("IdReporte")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdEtapaFenologica");

                    b.HasIndex("IdReporte");

                    b.ToTable("ReporteEtapaFenologica");
                });

            modelBuilder.Entity("FitoReport.Domain.Entities.ReportePlaga", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdPlaga")
                        .HasColumnType("int");

                    b.Property<int>("IdReporte")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdPlaga");

                    b.HasIndex("IdReporte");

                    b.ToTable("ReportePlaga");
                });

            modelBuilder.Entity("FitoReport.Domain.Entities.TokenDescargaArchivo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("HashArchivo")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("HashArchivo");

                    b.ToTable("TokenDescargaArchivo");
                });

            modelBuilder.Entity("FitoReport.Domain.Entities.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ApellidoMaterno")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(true);

                    b.Property<string>("ApellidoPaterno")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(true);

                    b.Property<bool>("Confirmado")
                        .HasColumnType("bit")
                        .IsUnicode(true);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("datetime2");

                    b.Property<string>("HashedPassword")
                        .IsRequired()
                        .HasColumnType("varchar(max)")
                        .IsUnicode(false);

                    b.Property<string>("ImagenPerfil")
                        .HasColumnType("varchar(max)")
                        .IsUnicode(false);

                    b.Property<DateTime>("LockoutEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(true);

                    b.Property<string>("NombreUsuario")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(true);

                    b.Property<string>("NormalizedEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(true);

                    b.Property<string>("NormalizedUserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20)
                        .IsUnicode(true);

                    b.Property<int>("TipoUsuario")
                        .HasColumnType("int");

                    b.Property<string>("TokenConfirmacion")
                        .HasColumnType("varchar(50)")
                        .HasMaxLength(50)
                        .IsUnicode(false);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("NombreUsuario")
                        .IsUnique();

                    b.ToTable("Usuario");
                });

            modelBuilder.Entity("FitoReport.Domain.Entities.UsuarioToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("RefreshToken")
                        .IsRequired()
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.HasIndex("RefreshToken")
                        .IsUnique();

                    b.ToTable("UsuarioToken");
                });

            modelBuilder.Entity("FitoReport.Domain.Entities.Archivo", b =>
                {
                    b.HasOne("FitoReport.Domain.Entities.Reporte", "IdReporteNavigation")
                        .WithMany("Archivos")
                        .HasForeignKey("IdReporte")
                        .HasConstraintName("FK_ArchivoUsuario_Reporte")
                        .IsRequired();

                    b.HasOne("FitoReport.Domain.Entities.Usuario", "IdUsuarioNavigation")
                        .WithMany("ArchivoUsuario")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK_ArchivoUsuario_Usuario")
                        .IsRequired();
                });

            modelBuilder.Entity("FitoReport.Domain.Entities.Producto", b =>
                {
                    b.HasOne("FitoReport.Domain.Entities.Reporte", "Reporte")
                        .WithMany("Productos")
                        .HasForeignKey("IdReport")
                        .HasConstraintName("FK_Productos_Reporte")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FitoReport.Domain.Entities.ReporteEnfermedad", b =>
                {
                    b.HasOne("FitoReport.Domain.Entities.Enfermedad", "Enfermedad")
                        .WithMany("ReporteEnfermedad")
                        .HasForeignKey("IdEnfermedad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitoReport.Domain.Entities.Reporte", "Reporte")
                        .WithMany("ReporteEnfermedad")
                        .HasForeignKey("IdReporte")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FitoReport.Domain.Entities.ReporteEtapaFenologica", b =>
                {
                    b.HasOne("FitoReport.Domain.Entities.EtapaFenologica", "EtapaFenologica")
                        .WithMany("ReporteEtapaFenologica")
                        .HasForeignKey("IdEtapaFenologica")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitoReport.Domain.Entities.Reporte", "Reporte")
                        .WithMany("ReporteEtapaFenologica")
                        .HasForeignKey("IdReporte")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FitoReport.Domain.Entities.ReportePlaga", b =>
                {
                    b.HasOne("FitoReport.Domain.Entities.Plaga", "Plaga")
                        .WithMany("ReportPlaga")
                        .HasForeignKey("IdPlaga")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FitoReport.Domain.Entities.Reporte", "Reporte")
                        .WithMany("ReportePlaga")
                        .HasForeignKey("IdReporte")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FitoReport.Domain.Entities.UsuarioToken", b =>
                {
                    b.HasOne("FitoReport.Domain.Entities.Usuario", "UsuarioNavigation")
                        .WithMany("UsuarioTokens")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK_UsuarioToken_Usuario")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

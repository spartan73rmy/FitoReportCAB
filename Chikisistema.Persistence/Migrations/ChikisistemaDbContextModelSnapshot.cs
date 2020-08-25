﻿// <auto-generated />
using System;
using Chikisistema.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Chikisistema.Persistence.Migrations
{
    [DbContext(typeof(ChikisistemaDbContext))]
    partial class ChikisistemaDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Chikisistema.Domain.Entities.ActividadCurso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("BloquearEnvios")
                        .HasColumnType("bit");

                    b.Property<string>("Contenido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .IsUnicode(true);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("FechaActivacion")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaLimite")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdTipoActividad")
                        .HasColumnType("int");

                    b.Property<int>("IdUnidad")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .IsUnicode(true);

                    b.Property<int>("Valor")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IdTipoActividad");

                    b.HasIndex("IdUnidad");

                    b.HasIndex("Valor");

                    b.ToTable("ActividadCurso");
                });

            modelBuilder.Entity("Chikisistema.Domain.Entities.AlumnoCurso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAlumno")
                        .HasColumnType("int");

                    b.Property<int>("IdCurso")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdAlumno");

                    b.HasIndex("IdCurso");

                    b.HasIndex("IdAlumno", "IdCurso")
                        .IsUnique();

                    b.ToTable("AlumnoCurso");
                });

            modelBuilder.Entity("Chikisistema.Domain.Entities.ArchivoUsuario", b =>
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

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("IdUsuario");

                    b.ToTable("ArchivoUsuario");
                });

            modelBuilder.Entity("Chikisistema.Domain.Entities.ComentarioActividad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contenido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .IsUnicode(true);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdActividad")
                        .HasColumnType("int");

                    b.Property<int?>("IdComentarioPadre")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdActividad");

                    b.HasIndex("IdComentarioPadre");

                    b.HasIndex("IdUsuario");

                    b.ToTable("ComentarioActividad");
                });

            modelBuilder.Entity("Chikisistema.Domain.Entities.Curso", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CodigoAcceso")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .IsUnicode(true);

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdMaestro")
                        .HasColumnType("int");

                    b.Property<int>("IdMateria")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CodigoAcceso")
                        .IsUnique();

                    b.HasIndex("IdMaestro");

                    b.HasIndex("IdMateria");

                    b.ToTable("Curso");
                });

            modelBuilder.Entity("Chikisistema.Domain.Entities.Materia", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100)
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.ToTable("Materia");
                });

            modelBuilder.Entity("Chikisistema.Domain.Entities.MaterialApoyoActividad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdActividad")
                        .HasColumnType("int");

                    b.Property<int>("IdArchivoUsuario")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdActividad");

                    b.HasIndex("IdArchivoUsuario");

                    b.HasIndex("IdActividad", "IdArchivoUsuario")
                        .IsUnique();

                    b.ToTable("MaterialApoyoActividad");
                });

            modelBuilder.Entity("Chikisistema.Domain.Entities.Mensaje", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaMensaje")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdUsuarioEnvia")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuarioRecibe")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("TextoMensaje")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .IsUnicode(true);

                    b.HasKey("Id");

                    b.HasIndex("IdUsuarioEnvia");

                    b.HasIndex("IdUsuarioRecibe");

                    b.ToTable("Mensaje");
                });

            modelBuilder.Entity("Chikisistema.Domain.Entities.PostForo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Contenido")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .IsUnicode(true);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdAutor")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdAutor");

                    b.ToTable("PostForo");
                });

            modelBuilder.Entity("Chikisistema.Domain.Entities.TipoActividad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200)
                        .IsUnicode(true);

                    b.HasKey("Id")
                        .HasName("PK_Actividad");

                    b.ToTable("TipoActividad");
                });

            modelBuilder.Entity("Chikisistema.Domain.Entities.TokenDescargaArchivo", b =>
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

            modelBuilder.Entity("Chikisistema.Domain.Entities.Unidad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .IsUnicode(true);

                    b.Property<int>("IdCurso")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdCurso");

                    b.ToTable("Unidad");
                });

            modelBuilder.Entity("Chikisistema.Domain.Entities.Usuario", b =>
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

            modelBuilder.Entity("Chikisistema.Domain.Entities.UsuarioActividad", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("Calificacion")
                        .HasColumnType("int");

                    b.Property<string>("Contenido")
                        .HasColumnType("nvarchar(max)")
                        .IsUnicode(true);

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaEntrega")
                        .HasColumnType("datetime2");

                    b.Property<int>("IdActividad")
                        .HasColumnType("int");

                    b.Property<int?>("IdArchivo")
                        .HasColumnType("int");

                    b.Property<int>("IdUsuario")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("IdActividad");

                    b.HasIndex("IdArchivo");

                    b.HasIndex("IdUsuario");

                    b.HasIndex("IdActividad", "IdUsuario")
                        .IsUnique();

                    b.ToTable("UsuarioActividad");
                });

            modelBuilder.Entity("Chikisistema.Domain.Entities.UsuarioToken", b =>
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

            modelBuilder.Entity("Chikisistema.Domain.Entities.ActividadCurso", b =>
                {
                    b.HasOne("Chikisistema.Domain.Entities.TipoActividad", "TipoActividad")
                        .WithMany("Actividades")
                        .HasForeignKey("IdTipoActividad")
                        .HasConstraintName("FK_ActividadCurso_TipoActividad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chikisistema.Domain.Entities.Unidad", "Unidad")
                        .WithMany("Actividades")
                        .HasForeignKey("IdUnidad")
                        .HasConstraintName("FK_ActividadCurso_Unidad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Chikisistema.Domain.Entities.AlumnoCurso", b =>
                {
                    b.HasOne("Chikisistema.Domain.Entities.Usuario", "IdAlumnoNavigation")
                        .WithMany("AlumnoCurso")
                        .HasForeignKey("IdAlumno")
                        .HasConstraintName("FK_AlumnoCurso_Usuario")
                        .IsRequired();

                    b.HasOne("Chikisistema.Domain.Entities.Curso", "IdCursoNavigation")
                        .WithMany("AlumnoCurso")
                        .HasForeignKey("IdCurso")
                        .HasConstraintName("FK_AlumnoCurso_Curso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Chikisistema.Domain.Entities.ArchivoUsuario", b =>
                {
                    b.HasOne("Chikisistema.Domain.Entities.Usuario", "IdUsuarioNavigation")
                        .WithMany("ArchivoUsuario")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK_ArchivoUsuario_Usuario")
                        .IsRequired();
                });

            modelBuilder.Entity("Chikisistema.Domain.Entities.ComentarioActividad", b =>
                {
                    b.HasOne("Chikisistema.Domain.Entities.ActividadCurso", "Actividad")
                        .WithMany("Comentarios")
                        .HasForeignKey("IdActividad")
                        .HasConstraintName("FK_ComentarioActividad_ActividadCurso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chikisistema.Domain.Entities.ComentarioActividad", "ComentarioPadre")
                        .WithMany("Hijos")
                        .HasForeignKey("IdComentarioPadre")
                        .HasConstraintName("FK_ComentarioActividad_ComentarioActividad");

                    b.HasOne("Chikisistema.Domain.Entities.Usuario", "Usuario")
                        .WithMany("Comentarios")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK_ComentarioActividad_Usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Chikisistema.Domain.Entities.Curso", b =>
                {
                    b.HasOne("Chikisistema.Domain.Entities.Usuario", "IdMaestroNavigation")
                        .WithMany("Curso")
                        .HasForeignKey("IdMaestro")
                        .HasConstraintName("FK_Curso_Usuario")
                        .IsRequired();

                    b.HasOne("Chikisistema.Domain.Entities.Materia", "IdMateriaNavigation")
                        .WithMany("Curso")
                        .HasForeignKey("IdMateria")
                        .HasConstraintName("FK_Curso_Materia")
                        .IsRequired();
                });

            modelBuilder.Entity("Chikisistema.Domain.Entities.MaterialApoyoActividad", b =>
                {
                    b.HasOne("Chikisistema.Domain.Entities.ActividadCurso", "Actividad")
                        .WithMany("MaterialApoyo")
                        .HasForeignKey("IdActividad")
                        .HasConstraintName("FK_MaterialApoyo_Actividad")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chikisistema.Domain.Entities.ArchivoUsuario", "ArchivoUsuario")
                        .WithMany("MaterialApoyo")
                        .HasForeignKey("IdArchivoUsuario")
                        .HasConstraintName("FK_MaterialApoyo_ArchivoUsuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Chikisistema.Domain.Entities.Mensaje", b =>
                {
                    b.HasOne("Chikisistema.Domain.Entities.Usuario", "IdUsuarioEnviaNavigation")
                        .WithMany("MensajeIdUsuarioEnviaNavigation")
                        .HasForeignKey("IdUsuarioEnvia")
                        .HasConstraintName("FK_Mensaje_Usuario")
                        .IsRequired();

                    b.HasOne("Chikisistema.Domain.Entities.Usuario", "IdUsuarioRecibeNavigation")
                        .WithMany("MensajeIdUsuarioRecibeNavigation")
                        .HasForeignKey("IdUsuarioRecibe")
                        .HasConstraintName("FK_Mensaje_Usuario1")
                        .IsRequired();
                });

            modelBuilder.Entity("Chikisistema.Domain.Entities.PostForo", b =>
                {
                    b.HasOne("Chikisistema.Domain.Entities.Usuario", "Autor")
                        .WithMany("PostsForo")
                        .HasForeignKey("IdAutor")
                        .HasConstraintName("FK_PostForo_Usuario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Chikisistema.Domain.Entities.Unidad", b =>
                {
                    b.HasOne("Chikisistema.Domain.Entities.Curso", "Curso")
                        .WithMany("Unidades")
                        .HasForeignKey("IdCurso")
                        .HasConstraintName("FK_Unidad_Curso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Chikisistema.Domain.Entities.UsuarioActividad", b =>
                {
                    b.HasOne("Chikisistema.Domain.Entities.ActividadCurso", "ActividadCurso")
                        .WithMany("UsuarioActividades")
                        .HasForeignKey("IdActividad")
                        .HasConstraintName("FK_UsuarioActividad_ActividadCurso")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Chikisistema.Domain.Entities.ArchivoUsuario", "Archivo")
                        .WithMany("UsuarioActividades")
                        .HasForeignKey("IdArchivo")
                        .HasConstraintName("FK_UsuarioActividad_ArchivoUsuario")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("Chikisistema.Domain.Entities.Usuario", "IdUsuarioNavigation")
                        .WithMany("UsuarioActividad")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK_UsuarioActividad_Usuario")
                        .IsRequired();
                });

            modelBuilder.Entity("Chikisistema.Domain.Entities.UsuarioToken", b =>
                {
                    b.HasOne("Chikisistema.Domain.Entities.Usuario", "UsuarioNavigation")
                        .WithMany("UsuarioTokens")
                        .HasForeignKey("IdUsuario")
                        .HasConstraintName("FK_UsuarioToken_Usuario")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Chikisistema.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Materia",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    Nombre = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TipoActividad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Nombre = table.Column<string>(maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TokenDescargaArchivo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Token = table.Column<string>(nullable: false),
                    HashArchivo = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TokenDescargaArchivo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    NombreUsuario = table.Column<string>(maxLength: 20, nullable: false),
                    Email = table.Column<string>(maxLength: 50, nullable: false),
                    HashedPassword = table.Column<string>(unicode: false, nullable: false),
                    TipoUsuario = table.Column<int>(nullable: false),
                    Confirmado = table.Column<bool>(nullable: false),
                    FechaRegistro = table.Column<DateTime>(nullable: false),
                    TokenConfirmacion = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    LockoutEnd = table.Column<DateTime>(nullable: false),
                    NormalizedUserName = table.Column<string>(maxLength: 20, nullable: false),
                    NormalizedEmail = table.Column<string>(maxLength: 50, nullable: false),
                    Nombre = table.Column<string>(maxLength: 20, nullable: false),
                    ApellidoPaterno = table.Column<string>(maxLength: 20, nullable: false),
                    ApellidoMaterno = table.Column<string>(maxLength: 20, nullable: false),
                    ImagenPerfil = table.Column<string>(unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArchivoUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    IdUsuario = table.Column<int>(nullable: false),
                    Hash = table.Column<string>(nullable: false),
                    ContentType = table.Column<string>(nullable: false),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArchivoUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArchivoUsuario_Usuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    IdMateria = table.Column<int>(nullable: false),
                    IdMaestro = table.Column<int>(nullable: false),
                    CodigoAcceso = table.Column<string>(nullable: false),
                    FechaInicio = table.Column<DateTime>(nullable: false),
                    FechaFin = table.Column<DateTime>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Curso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Curso_Usuario",
                        column: x => x.IdMaestro,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Curso_Materia",
                        column: x => x.IdMateria,
                        principalTable: "Materia",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Mensaje",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    IdUsuarioEnvia = table.Column<int>(nullable: false),
                    IdUsuarioRecibe = table.Column<int>(nullable: false),
                    TextoMensaje = table.Column<string>(nullable: false),
                    FechaMensaje = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mensaje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mensaje_Usuario",
                        column: x => x.IdUsuarioEnvia,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mensaje_Usuario1",
                        column: x => x.IdUsuarioRecibe,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PostForo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    IdAutor = table.Column<int>(nullable: false),
                    Contenido = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostForo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostForo_Usuario",
                        column: x => x.IdAutor,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioToken",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    IdUsuario = table.Column<int>(nullable: false),
                    RefreshToken = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioToken", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioToken_Usuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlumnoCurso",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    IdCurso = table.Column<int>(nullable: false),
                    IdAlumno = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlumnoCurso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AlumnoCurso_Usuario",
                        column: x => x.IdAlumno,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlumnoCurso_Curso",
                        column: x => x.IdCurso,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Unidad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    IdCurso = table.Column<int>(nullable: false),
                    Descripcion = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Unidad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Unidad_Curso",
                        column: x => x.IdCurso,
                        principalTable: "Curso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ActividadCurso",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    DeletedDate = table.Column<DateTime>(nullable: true),
                    IdUnidad = table.Column<int>(nullable: false),
                    IdTipoActividad = table.Column<int>(nullable: false),
                    Titulo = table.Column<string>(nullable: false),
                    Contenido = table.Column<string>(nullable: false),
                    Valor = table.Column<int>(nullable: false),
                    FechaLimite = table.Column<DateTime>(nullable: false),
                    FechaActivacion = table.Column<DateTime>(nullable: true),
                    BloquearEnvios = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActividadCurso", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ActividadCurso_TipoActividad",
                        column: x => x.IdTipoActividad,
                        principalTable: "TipoActividad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ActividadCurso_Unidad",
                        column: x => x.IdUnidad,
                        principalTable: "Unidad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ComentarioActividad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Contenido = table.Column<string>(nullable: false),
                    IdActividad = table.Column<int>(nullable: false),
                    IdComentarioPadre = table.Column<int>(nullable: true),
                    IdUsuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentarioActividad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComentarioActividad_ActividadCurso",
                        column: x => x.IdActividad,
                        principalTable: "ActividadCurso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComentarioActividad_ComentarioActividad",
                        column: x => x.IdComentarioPadre,
                        principalTable: "ComentarioActividad",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ComentarioActividad_Usuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialApoyoActividad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    IdArchivoUsuario = table.Column<int>(nullable: false),
                    IdActividad = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaterialApoyoActividad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaterialApoyo_Actividad",
                        column: x => x.IdActividad,
                        principalTable: "ActividadCurso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaterialApoyo_ArchivoUsuario",
                        column: x => x.IdArchivoUsuario,
                        principalTable: "ArchivoUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioActividad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    IdUsuario = table.Column<int>(nullable: false),
                    IdActividad = table.Column<int>(nullable: false),
                    Contenido = table.Column<string>(nullable: true),
                    IdArchivo = table.Column<int>(nullable: true),
                    Calificacion = table.Column<int>(nullable: true),
                    FechaEntrega = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioActividad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuarioActividad_ActividadCurso",
                        column: x => x.IdActividad,
                        principalTable: "ActividadCurso",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuarioActividad_ArchivoUsuario",
                        column: x => x.IdArchivo,
                        principalTable: "ArchivoUsuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_UsuarioActividad_Usuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ActividadCurso_IdTipoActividad",
                table: "ActividadCurso",
                column: "IdTipoActividad");

            migrationBuilder.CreateIndex(
                name: "IX_ActividadCurso_IdUnidad",
                table: "ActividadCurso",
                column: "IdUnidad");

            migrationBuilder.CreateIndex(
                name: "IX_ActividadCurso_Valor",
                table: "ActividadCurso",
                column: "Valor");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoCurso_IdAlumno",
                table: "AlumnoCurso",
                column: "IdAlumno");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoCurso_IdCurso",
                table: "AlumnoCurso",
                column: "IdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_AlumnoCurso_IdAlumno_IdCurso",
                table: "AlumnoCurso",
                columns: new[] { "IdAlumno", "IdCurso" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ArchivoUsuario_IdUsuario",
                table: "ArchivoUsuario",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioActividad_IdActividad",
                table: "ComentarioActividad",
                column: "IdActividad");

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioActividad_IdComentarioPadre",
                table: "ComentarioActividad",
                column: "IdComentarioPadre");

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioActividad_IdUsuario",
                table: "ComentarioActividad",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_Curso_CodigoAcceso",
                table: "Curso",
                column: "CodigoAcceso",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Curso_IdMaestro",
                table: "Curso",
                column: "IdMaestro");

            migrationBuilder.CreateIndex(
                name: "IX_Curso_IdMateria",
                table: "Curso",
                column: "IdMateria");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialApoyoActividad_IdActividad",
                table: "MaterialApoyoActividad",
                column: "IdActividad");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialApoyoActividad_IdArchivoUsuario",
                table: "MaterialApoyoActividad",
                column: "IdArchivoUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_MaterialApoyoActividad_IdActividad_IdArchivoUsuario",
                table: "MaterialApoyoActividad",
                columns: new[] { "IdActividad", "IdArchivoUsuario" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Mensaje_IdUsuarioEnvia",
                table: "Mensaje",
                column: "IdUsuarioEnvia");

            migrationBuilder.CreateIndex(
                name: "IX_Mensaje_IdUsuarioRecibe",
                table: "Mensaje",
                column: "IdUsuarioRecibe");

            migrationBuilder.CreateIndex(
                name: "IX_PostForo_IdAutor",
                table: "PostForo",
                column: "IdAutor");

            migrationBuilder.CreateIndex(
                name: "IX_TokenDescargaArchivo_HashArchivo",
                table: "TokenDescargaArchivo",
                column: "HashArchivo");

            migrationBuilder.CreateIndex(
                name: "IX_Unidad_IdCurso",
                table: "Unidad",
                column: "IdCurso");

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_Email",
                table: "Usuario",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Usuario_NombreUsuario",
                table: "Usuario",
                column: "NombreUsuario",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioActividad_IdActividad",
                table: "UsuarioActividad",
                column: "IdActividad");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioActividad_IdArchivo",
                table: "UsuarioActividad",
                column: "IdArchivo");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioActividad_IdUsuario",
                table: "UsuarioActividad",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioActividad_IdActividad_IdUsuario",
                table: "UsuarioActividad",
                columns: new[] { "IdActividad", "IdUsuario" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioToken_IdUsuario",
                table: "UsuarioToken",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioToken_RefreshToken",
                table: "UsuarioToken",
                column: "RefreshToken",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlumnoCurso");

            migrationBuilder.DropTable(
                name: "ComentarioActividad");

            migrationBuilder.DropTable(
                name: "MaterialApoyoActividad");

            migrationBuilder.DropTable(
                name: "Mensaje");

            migrationBuilder.DropTable(
                name: "PostForo");

            migrationBuilder.DropTable(
                name: "TokenDescargaArchivo");

            migrationBuilder.DropTable(
                name: "UsuarioActividad");

            migrationBuilder.DropTable(
                name: "UsuarioToken");

            migrationBuilder.DropTable(
                name: "ActividadCurso");

            migrationBuilder.DropTable(
                name: "ArchivoUsuario");

            migrationBuilder.DropTable(
                name: "TipoActividad");

            migrationBuilder.DropTable(
                name: "Unidad");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "Materia");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Chikisistema.Persistence.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "UsuarioActividad");

            migrationBuilder.DropTable(
                name: "ActividadCurso");

            migrationBuilder.DropTable(
                name: "TipoActividad");

            migrationBuilder.DropTable(
                name: "Unidad");

            migrationBuilder.DropTable(
                name: "Curso");

            migrationBuilder.DropTable(
                name: "Materia");

            migrationBuilder.CreateTable(
                name: "Reporte",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    Lugar = table.Column<string>(nullable: false),
                    FechaAlta = table.Column<DateTime>(nullable: false),
                    Productor = table.Column<string>(nullable: false),
                    CoordX = table.Column<double>(nullable: false),
                    CoordY = table.Column<double>(nullable: false),
                    Ubicacion = table.Column<string>(nullable: false),
                    Predio = table.Column<string>(nullable: false),
                    Cultivo = table.Column<string>(nullable: false),
                    EtapaFenologica = table.Column<string>(nullable: true),
                    Observaciones = table.Column<string>(nullable: false),
                    Litros = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reporte", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Enfermedad",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    IdReport = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enfermedad", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enfermedad_Reporte",
                        column: x => x.IdReport,
                        principalTable: "Reporte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Plaga",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    IdReport = table.Column<int>(nullable: false),
                    Nombre = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plaga", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Plaga_Reporte",
                        column: x => x.IdReport,
                        principalTable: "Reporte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Producto",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(nullable: false),
                    Modified = table.Column<DateTime>(nullable: true),
                    IdReport = table.Column<int>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    NombreProducto = table.Column<string>(nullable: false),
                    IngredienteActivo = table.Column<string>(nullable: false),
                    Concentracion = table.Column<int>(nullable: false),
                    IntervaloSeguridad = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Producto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_Reporte",
                        column: x => x.IdReport,
                        principalTable: "Reporte",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enfermedad_IdReport",
                table: "Enfermedad",
                column: "IdReport");

            migrationBuilder.CreateIndex(
                name: "IX_Plaga_IdReport",
                table: "Plaga",
                column: "IdReport");

            migrationBuilder.CreateIndex(
                name: "IX_Producto_IdReport",
                table: "Producto",
                column: "IdReport");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enfermedad");

            migrationBuilder.DropTable(
                name: "Plaga");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Reporte");

            migrationBuilder.CreateTable(
                name: "Materia",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materia", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mensaje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaMensaje = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdUsuarioEnvia = table.Column<int>(type: "int", nullable: false),
                    IdUsuarioRecibe = table.Column<int>(type: "int", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TextoMensaje = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contenido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdAutor = table.Column<int>(type: "int", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                name: "TipoActividad",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Nombre = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actividad", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Curso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoAcceso = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaFin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdMaestro = table.Column<int>(type: "int", nullable: false),
                    IdMateria = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                name: "AlumnoCurso",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdAlumno = table.Column<int>(type: "int", nullable: false),
                    IdCurso = table.Column<int>(type: "int", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdCurso = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloquearEnvios = table.Column<bool>(type: "bit", nullable: false),
                    Contenido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaActivacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaLimite = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdTipoActividad = table.Column<int>(type: "int", nullable: false),
                    IdUnidad = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Titulo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: false)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Contenido = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdActividad = table.Column<int>(type: "int", nullable: false),
                    IdComentarioPadre = table.Column<int>(type: "int", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdActividad = table.Column<int>(type: "int", nullable: false),
                    IdArchivoUsuario = table.Column<int>(type: "int", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Calificacion = table.Column<int>(type: "int", nullable: true),
                    Contenido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IdActividad = table.Column<int>(type: "int", nullable: false),
                    IdArchivo = table.Column<int>(type: "int", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: true)
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
                name: "IX_Unidad_IdCurso",
                table: "Unidad",
                column: "IdCurso");

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
        }
    }
}

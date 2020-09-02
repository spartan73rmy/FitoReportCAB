using Chikisistema.Domain.Entities;
using System;
using System.Linq;

namespace Chikisistema.Persistence
{
    public class FitoReportDbInitializer
    {
        public static void Initialize(FitoReportDbContext context)
        {
            var initializer = new FitoReportDbInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(FitoReportDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Usuario.Any())
            {
                return; // Db has been seeded
            }
            SeedUsuario(context);
            SeedArchivoUsuario(context);

        }

        private void SeedArchivoUsuario(FitoReportDbContext context)
        {
            var materialApoyo = new ArchivoUsuario[]
            {
                new ArchivoUsuario
                {
                    // Id = 1,
                    ContentType = "application/pdf",
                    Hash = "123",
                    IdUsuario = 1,
                    Nombre = "NombreArchivo.pdf"
                },
                new ArchivoUsuario
                {
                    // Id = 2,
                    ContentType = "image/png",
                    Hash = "133",
                    IdUsuario = 2,
                    Nombre = "NombreArchivo.png"
                },
                new ArchivoUsuario
                {
                    // Id = 3,
                    ContentType = "application/zip",
                    Hash = "323",
                    IdUsuario = 3,
                    Nombre = "NombreArchivo.zip"
                },
                new ArchivoUsuario
                {
                    // Id = 4,
                    ContentType = "application/zip",
                    Hash = "789",
                    IdUsuario = 3,
                    Nombre = "NombreArchivo.zip"
                },
            };

            foreach (var archivo in materialApoyo)
            {
                context.ArchivoUsuario.Add(archivo);
                context.SaveChanges();
            }
        }

        private void SeedUsuario(FitoReportDbContext db)
        {
            var usuarios = new Usuario[]
            {
                new Usuario
                {
                    // Id = 1,
                    Email = "asd@asd.com",
                    NombreUsuario = "Admin",
                    TipoUsuario = Domain.Enums.TiposUsuario.Admin,
                    HashedPassword = "sha1:64000:18:GDo9HgM4Ke1BNgkIkvG1wlejZAS0qlpG:BPesev8ueqRpNVojKKcJMwDD",
                    Confirmado = true,
                    TokenConfirmacion = "",
                    Nombre = "Nombre",
                    ApellidoMaterno = "Apellido materno",
                    ApellidoPaterno = "Apellido paterno",
                    NormalizedEmail = "ASD@ASD.COM",
                    NormalizedUserName = "ADMIN"
                },
                new Usuario
                {
                    // Id = 2,
                    Email = "alumno@asd.com",
                    NombreUsuario = "Alumno",
                    TipoUsuario = Domain.Enums.TiposUsuario.Admin,
                    HashedPassword = "sha1:64000:18:GDo9HgM4Ke1BNgkIkvG1wlejZAS0qlpG:BPesev8ueqRpNVojKKcJMwDD",
                    Confirmado = true,
                    TokenConfirmacion = "",
                    Nombre = "Nombre",
                    ApellidoMaterno = "Apellido materno",
                    ApellidoPaterno = "Apellido paterno",
                    NormalizedEmail = "ALUMNO@ASD.COM",
                    NormalizedUserName = "ALUMNO"
                },
                new Usuario
                {
                    // Id = 3,
                    Email = "Maestro@asd.com",
                    NombreUsuario = "Maestro",
                    TipoUsuario = Domain.Enums.TiposUsuario.Admin,
                    HashedPassword = "sha1:64000:18:GDo9HgM4Ke1BNgkIkvG1wlejZAS0qlpG:BPesev8ueqRpNVojKKcJMwDD",
                    Confirmado = true,
                    TokenConfirmacion = "",
                    Nombre = "Nombre",
                    ApellidoMaterno = "Apellido materno",
                    ApellidoPaterno = "Apellido paterno",
                    NormalizedEmail = "MAESTRO@ASD.COM",
                    NormalizedUserName = "MAESTRO"
                },
                new Usuario
                {
                    // Id = 4,
                    Email = "Maestro@asd2.com",
                    NombreUsuario = "Maestro2",
                    TipoUsuario = Domain.Enums.TiposUsuario.Admin,
                    HashedPassword = "sha1:64000:18:GDo9HgM4Ke1BNgkIkvG1wlejZAS0qlpG:BPesev8ueqRpNVojKKcJMwDD",
                    Confirmado = false,
                    TokenConfirmacion = "",
                    Nombre = "Nombre",
                    ApellidoMaterno = "Apellido materno",
                    ApellidoPaterno = "Apellido paterno",
                    NormalizedEmail = "MAESTRO@ASD2.COM",
                    NormalizedUserName = "MAESTRO2"
                },
                new Usuario
                {
                    // Id = 5,
                    Email = "usuarioasasdadad@aasdassd2.com",
                    NombreUsuario = "Alumno2",
                    TipoUsuario = Domain.Enums.TiposUsuario.Admin,
                    HashedPassword = "sha1:64000:18:GDo9HgM4Ke1BNgkIkvG1wlejZAS0qlpG:BPesev8ueqRpNVojKKcJMwDD",
                    Confirmado = false,
                    TokenConfirmacion = "123",
                    Nombre = "Nombre",
                    ApellidoMaterno = "Apellido materno",
                    ApellidoPaterno = "Apellido paterno",
                    NormalizedEmail = "USUARIOASASDADAD@AASDASSD2.COM",
                    NormalizedUserName = "ALUMNO2"
                },
                new Usuario
                {
                    // Id = 6,
                    Email = "Maestro@asdwe2.com",
                    NombreUsuario = "Maestro21231",
                    TipoUsuario = Domain.Enums.TiposUsuario.Admin,
                    HashedPassword = "sha1:64000:18:GDo9HgM4Ke1BNgkIkvG1wlejZAS0qlpG:BPesev8ueqRpNVojKKcJMwDD",
                    Confirmado = false,
                    TokenConfirmacion = "1234",
                    Nombre = "Nombre",
                    ApellidoMaterno = "Apellido materno",
                    ApellidoPaterno = "Apellido paterno",
                    NormalizedEmail = "MAESTRO@ASDWE2.COM",
                    NormalizedUserName = "MAESTRO21231"
                },
                new Usuario
                {
                    // Id = 7,
                    Email = "alumno3@alumno.com",
                    NombreUsuario = "AlumnoTres",
                    TipoUsuario = Domain.Enums.TiposUsuario.Admin,
                    HashedPassword = "sha1:64000:18:GDo9HgM4Ke1BNgkIkvG1wlejZAS0qlpG:BPesev8ueqRpNVojKKcJMwDD",
                    Confirmado = true,
                    TokenConfirmacion = "",
                    Nombre = "Jose",
                    ApellidoMaterno = "Morelos",
                    ApellidoPaterno = "Espinosa",
                    NormalizedEmail = "ALUMNO3@ALUMNO.COM",
                    NormalizedUserName = "ALUMNOTRES"
                },
            };

            foreach (var usuario in usuarios)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
            }
        }      
    }
}

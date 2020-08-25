using Chikisistema.Application.UseCases.Actividades.Commands.SubirArchivoAlumno;
using Chikisistema.WebUi.FunctionalTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Chikisistema.WebUi.FunctionalTests.Controllers.Actividades
{
    public class SubirActividadAlumno : BaseTestController
    {
        public SubirActividadAlumno(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task SubeCorrectamenteActividadSoloTexto()
        {
            var client = await GetAlumnoClientAsync();

            var req = new SubirActividadAlumnoCommand
            {
                Contenido = "Hola esta es mi respuesta",
                IdActividad = 6
            };

            var content = Utilities.GetRequestContent(req);
            var response = await client.PostAsync("/api/Actividades/SubirActividadAlumno", content);

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<SubirActividadAlumnoResponse>(response);

            Assert.True(result.Id > 0);
        }

        [Fact]
        public async Task SubeCorrectamenteActividadSoloArchivo()
        {
            var client = await GetAlumnoClientAsync();

            var req = new SubirActividadAlumnoCommand
            {
                Archivo = "133",
                IdActividad = 5
            };

            var content = Utilities.GetRequestContent(req);
            var response = await client.PostAsync("/api/Actividades/SubirActividadAlumno", content);

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<SubirActividadAlumnoResponse>(response);

            Assert.True(result.Id > 0);
        }

        [Fact]
        public async Task SubeCorrectamenteActividadArchivoYContenido()
        {
            var client = await GetAlumnoClientAsync();

            var req = new SubirActividadAlumnoCommand
            {
                Archivo = "133",
                IdActividad = 3,
                Contenido = "Contenido de la actividad"
            };

            var content = Utilities.GetRequestContent(req);
            var response = await client.PostAsync("/api/Actividades/SubirActividadAlumno", content);

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<SubirActividadAlumnoResponse>(response);

            Assert.True(result.Id > 0);
        }

        [Fact]
        public async Task SubeActividadVaciaRetornaBadRequest()
        {
            var client = await GetAlumnoClientAsync();

            var req = new SubirActividadAlumnoCommand
            {
                IdActividad = 1
            };

            var content = Utilities.GetRequestContent(req);
            var response = await client.PostAsync("/api/Actividades/SubirActividadAlumno", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task SubeActividadSoloArchivoDeDirefenteUsuarioRetornaNotAuthorized()
        {
            var client = await GetAlumnoClientAsync();

            var req = new SubirActividadAlumnoCommand
            {
                Archivo = "323",
                IdActividad = 2
            };

            var content = Utilities.GetRequestContent(req);
            var response = await client.PostAsync("/api/Actividades/SubirActividadAlumno", content);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task SubeActividadCursoNoInscritoRetornaNotAuthorized()
        {
            var client = await GetAlumnoClientAsync();

            var req = new SubirActividadAlumnoCommand
            {
                Archivo = "323",
                IdActividad = 4
            };

            var content = Utilities.GetRequestContent(req);
            var response = await client.PostAsync("/api/Actividades/SubirActividadAlumno", content);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
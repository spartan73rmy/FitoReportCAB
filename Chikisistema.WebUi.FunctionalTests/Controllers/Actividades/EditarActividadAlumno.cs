using Chikisistema.Application.UseCases.Actividades.Commands.EditarActividadAlumno;
using Chikisistema.WebUi.FunctionalTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Chikisistema.WebUi.FunctionalTests.Controllers.Actividades
{
    public class EditarActividadAlumno : BaseTestController
    {
        public EditarActividadAlumno(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task EditaCorrectamenteActividadSoloTexto()
        {
            var client = await GetAlumnoClientAsync();

            var req = new EditarActividadAlumnoCommand
            {
                IdActividad = 8,
                Contenido = "Hola esta es mi respuesta"
            };

            var content = Utilities.GetRequestContent(req);
            var response = await client.PostAsync("/api/Actividades/EditarActividadAlumno", content);

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<EditarActividadAlumnoResponse>(response);

            Assert.True(result.Id > 0);
        }

        [Fact]
        public async Task EditaCorrectamenteActividadSoloArchivo()
        {
            var client = await GetAlumnoClientAsync();

            var req = new EditarActividadAlumnoCommand
            {
                IdActividad = 8,
                Archivo = "133"
            };

            var content = Utilities.GetRequestContent(req);
            var response = await client.PostAsync("/api/Actividades/EditarActividadAlumno", content);

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<EditarActividadAlumnoResponse>(response);

            Assert.True(result.Id > 0);
        }

        [Fact]
        public async Task EditaCorrectamenteActividadArchivoYContenido()
        {
            var client = await GetAlumnoClientAsync();

            var req = new EditarActividadAlumnoCommand
            {
                IdActividad = 8,
                Archivo = "133",
                Contenido = "Contenido de la actividad"
            };

            var content = Utilities.GetRequestContent(req);
            var response = await client.PostAsync("/api/Actividades/EditarActividadAlumno", content);

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<EditarActividadAlumnoResponse>(response);

            Assert.True(result.Id > 0);
        }

        [Fact]
        public async Task EditaActividadVaciaRetornaBadRequest()
        {
            var client = await GetAlumnoClientAsync();

            var req = new EditarActividadAlumnoCommand
            {
                IdActividad = 8
            };

            var content = Utilities.GetRequestContent(req);
            var response = await client.PostAsync("/api/Actividades/EditarActividadAlumno", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task EditaByIdUsuarioActividadUsuarioVaciaRetornaNotFound()
        {
            var client = await GetAlumnoClientAsync();

            var req = new EditarActividadAlumnoCommand
            {
                IdActividad = 7777,
                Contenido = "Actividad I"
            };

            var content = Utilities.GetRequestContent(req);
            var response = await client.PostAsync("/api/Actividades/EditarActividadAlumno", content);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
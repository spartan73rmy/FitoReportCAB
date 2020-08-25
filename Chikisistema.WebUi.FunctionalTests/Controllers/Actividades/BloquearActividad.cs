using Chikisistema.Application.UseCases.Actividades.Commands.BloquearActividad;
using Chikisistema.Application.UseCases.Actividades.Commands.SubirArchivoAlumno;
using Chikisistema.WebUi.FunctionalTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Chikisistema.WebUi.FunctionalTests.Controllers.Actividades
{
    public class BloquearActividad : BaseTestController
    {
        public BloquearActividad(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task BloquearCorrectamenteActividad()
        {
            var client = await GetMaestroClientAsync();

            var req = new BloquearActividadCommand
            {
                IdActividad = 1
            };

            var content = Utilities.GetRequestContent(req);
            var response = await client.PostAsync("/api/Actividades/BloquearActividad", content);

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<BloquearActividadResponse>(response);

            Assert.True(result.Id > 0);
        }

        [Fact]
        public async Task BloquearActividadAlumnoNoAutorizado()
        {
            var client = await GetAlumnoClientAsync();

            var req = new BloquearActividadCommand
            {
                IdActividad = 1
            };

            var content = Utilities.GetRequestContent(req);
            var response = await client.PostAsync("/api/Actividades/BloquearActividad", content);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task BloquearActividadAdminNoAutorizado()
        {
            var client = await GetAdminClientAsync();

            var req = new BloquearActividadCommand
            {
                IdActividad = 1
            };

            var content = Utilities.GetRequestContent(req);
            var response = await client.PostAsync("/api/Actividades/BloquearActividad", content);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task NoAutorizado()
        {
            var client = GetClient();

            var req = new BloquearActividadCommand
            {
                IdActividad = 2
            };

            var content = Utilities.GetRequestContent(req);
            var response = await client.PostAsync("/api/Actividades/BloquearActividad", content);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task BloqueaActividad_AlumnoIntentaSubirActividad_RetornaBadRequest()
        {
            var client = await GetMaestroClientAsync();

            var req = new BloquearActividadCommand
            {
                IdActividad = 9
            };

            var content = Utilities.GetRequestContent(req);
            var response = await client.PostAsync("/api/Actividades/BloquearActividad", content);

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<BloquearActividadResponse>(response);

            Assert.True(result.Id > 0);

            var clientAlumno = await GetAlumnoClientAsync();
            var reqAlumno = new SubirActividadAlumnoCommand
            {
                Contenido = "test",
                IdActividad = 9
            };

            var contentAlumno = Utilities.GetRequestContent(reqAlumno);
            var responseAlumno = await clientAlumno.PostAsync("/api/Actividades/SubirActividadAlumno", contentAlumno);

            Assert.Equal(HttpStatusCode.BadRequest, responseAlumno.StatusCode);
        }
    }
}
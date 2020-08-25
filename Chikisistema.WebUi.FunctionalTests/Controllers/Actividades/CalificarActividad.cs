using Chikisistema.Application.UseCases.Actividades.Commands.CalificarActividad;
using Chikisistema.WebUi.FunctionalTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Chikisistema.WebUi.FunctionalTests.Controllers.Actividades
{
    public class CalificarActividad : BaseTestController
    {
        public CalificarActividad(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task CalificarCorrectamenteActividad()
        {
            var client = await GetMaestroClientAsync();
            var pet = new CalificarActividadCommand
            {
                IdAlumno = 2,
                IdActividad = 1,
                Calificacion = 30
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Actividades/CalificarActividad", content);

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<CalificarActividadResponse>(response);

            Assert.IsType<CalificarActividadResponse>(result);
            Assert.Equal(pet.Calificacion, result.Calificacion);
            Assert.Equal(pet.IdActividad, result.IdActividad);
            Assert.True(result.IdActividad > 0);
        }

        [Theory]
        [InlineData(2, 1, -1)]
        [InlineData(2, 1, 50)] //Calificacion mayor a su valor
        [InlineData(7, 2, 30)] //No se han bloqueado envios
        public async Task BadRequestCalificarAlumno(int idAlumno, int idActividad, int calificacion)
        {
            var client = await GetMaestroClientAsync();
            var pet = new CalificarActividadCommand
            {
                IdAlumno = idAlumno,
                IdActividad = idActividad,
                Calificacion = calificacion
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Actividades/CalificarActividad", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task RetornaNotFound()
        {
            var client = await GetMaestroClientAsync();
            var pet = new CalificarActividadCommand
            {
                IdActividad = 100,
                IdAlumno = 230,
                Calificacion = 30
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Actividades/CalificarActividad", content);

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task AlumnoNoAutorizado()
        {
            var client = await GetAlumnoClientAsync();
            var pet = new CalificarActividadCommand
            {
                IdAlumno = 2,
                IdActividad = 1,
                Calificacion = 30
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Actividades/CalificarActividad", content);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task NoAutorizado()
        {
            var client = GetClient();
            var pet = new CalificarActividadCommand
            {
                IdAlumno = 2,
                IdActividad = 1,
                Calificacion = 30
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Actividades/CalificarActividad", content);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
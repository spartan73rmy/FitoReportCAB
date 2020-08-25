using Chikisistema.Application.UseCases.Actividades.Queries.GetAlumnosByActividad;
using Chikisistema.WebUi.FunctionalTests.Common;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Chikisistema.WebUi.FunctionalTests.Controllers.Actividades
{
    public class GetAlumnosByActividad : BaseTestController, IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        public GetAlumnosByActividad(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task ObtieneCorrectamente()
        {
            var client = await GetMaestroClientAsync();

            var response = await client.GetAsync("/api/Actividades/GetAlumnosByActividad/1");

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<GetAlumnosByActividadResponse>(response);

            Assert.IsType<GetAlumnosByActividadResponse>(result);
            Assert.NotNull(result);
            Assert.NotNull(result.TituloActividad);
            Assert.True(result.IdActividad == 1);
            Assert.True(result.Respuestas.Count() > 0);
        }

        [Fact]
        public async Task MaestroNoCreoCursoNoAutorizado()
        {
            var client = await GetMaestroClientAsync();
            var response = await client.GetAsync("/api/Actividades/GetAlumnosByActividad/4");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task AlumnoNoAutorizado()
        {
            var client = await GetAlumnoClientAsync();

            var response = await client.GetAsync("/api/Actividades/GetAlumnosByActividad/1");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task NoAutorizado()
        {
            var client = GetClient();
            var response = await client.GetAsync("/api/Actividades/GetAlumnosByActividad/1");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task RetornaNotFound()
        {
            var client = await GetMaestroClientAsync();
            var response = await client.GetAsync("/api/actividades/GetAlumnosByActividad/777777");
            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }
    }
}
using Chikisistema.Application.UseCases.Actividades.Queries.GetActividadesPendientes;
using Chikisistema.WebUi.FunctionalTests.Common;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Chikisistema.WebUi.FunctionalTests.Controllers.Actividades
{
    public class AlumnoGetActividadesPendientes : BaseTestController
    {
        public AlumnoGetActividadesPendientes(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task ObtieneCorrectamente()
        {
            var client = await GetAlumnoClientAsync();
            var response = await client.GetAsync("/api/Actividades/AlumnoGetActividadesPendientes/1");

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<GetActividadesPendientesResponse>(response);

            Assert.IsType<GetActividadesPendientesResponse>(result);
            Assert.NotNull(result);
            Assert.True(result.Actividades.Count > 0);
            Assert.True(result.Actividades.All(el => el.IdCurso == 1));
        }

        [Fact]
        public async Task NoAutorizado()
        {
            var client = GetClient();
            var response = await client.GetAsync("/api/Actividades/AlumnoGetActividadesPendientes/1");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task AlumnoNoInscritoAlCursoRetornaNoAutorizado()
        {
            var client = await GetAlumnoClientAsync();
            var response = await client.GetAsync("/api/Actividades/AlumnoGetActividadesPendientes/3");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
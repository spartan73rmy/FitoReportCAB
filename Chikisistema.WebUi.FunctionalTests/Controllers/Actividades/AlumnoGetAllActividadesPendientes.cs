using Chikisistema.Application.UseCases.Actividades.Queries.GetAllActividadesPendientes;
using Chikisistema.WebUi.FunctionalTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Chikisistema.WebUi.FunctionalTests.Controllers.Actividades
{
    public class AlumnoGetAllActividadesPendientes : BaseTestController
    {
        public AlumnoGetAllActividadesPendientes(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task ObtieneCorrectamente()
        {
            var client = await GetAlumnoClientAsync();
            var response = await client.GetAsync("/api/Actividades/AlumnoGetAllActividadesPendientes");

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<GetAllActividadesPendientesResponse>(response);

            Assert.IsType<GetAllActividadesPendientesResponse>(result);
            Assert.NotNull(result);
            Assert.True(result.Actividades.Count > 0);
        }

        [Fact]
        public async Task NoAutorizado()
        {
            var client = GetClient();
            var response = await client.GetAsync("/api/Actividades/AlumnoGetAllActividadesPendientes");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
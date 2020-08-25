using Chikisistema.Application.UseCases.Usuarios.Queries.GetMaestrosNoConfirmados;
using Chikisistema.WebUi.FunctionalTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Chikisistema.WebUi.FunctionalTests.Controllers.Usuarios
{
    public class GetMaestrosNoConfirmados : BaseTestController
    {
        public GetMaestrosNoConfirmados(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task ReturnsCustomersListViewModel()
        {
            var client = await GetAdminClientAsync();
            var response = await client.GetAsync("/api/Usuarios/GetMaestrosNoConfirmados");

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<GetMaestrosNoConfirmadosResponse>(response);

            Assert.IsType<GetMaestrosNoConfirmadosResponse>(result);
            Assert.NotEmpty(result.Maestros);
        }

        [Fact]
        public async Task RetornaNoAutorizadoAlumno()
        {
            var client = await GetAlumnoClientAsync();
            var response = await client.GetAsync("/api/Usuarios/GetMaestrosNoConfirmados");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task RetornaNoAutorizadoMaestro()
        {
            var client = await GetMaestroClientAsync();
            var response = await client.GetAsync("/api/Usuarios/GetMaestrosNoConfirmados");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
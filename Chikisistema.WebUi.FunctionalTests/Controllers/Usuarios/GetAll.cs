using Chikisistema.Application.UseCases.Usuarios.Queries.GetAllMaestro;
using Chikisistema.Application.UseCases.Usuarios.Queries.GetUsuariosList;
using Chikisistema.WebUi.FunctionalTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Chikisistema.WebUi.FunctionalTests.Controllers.Usuarios
{
    public class GetAll : BaseTestController
    {
        public GetAll(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task ReturnsCustomersListViewModel()
        {
            var client = await GetAdminClientAsync();
            var response = await client.GetAsync("/api/Usuarios/GetAll");

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<GetUsuariosListResponse>(response);

            Assert.IsType<GetUsuariosListResponse>(result);
            Assert.NotEmpty(result.Usuarios);
        }

        [Fact]
        public async Task AllAlumnosListViewModelConAlumno_RetornaNoAutorizado()
        {
            var client = await GetAlumnoClientAsync();
            var response = await client.GetAsync("/api/Usuarios/GetAll");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task AllAlumnosListViewModelConMaestro_RetornaNoAutorizado()
        {
            var client = await GetMaestroClientAsync();
            var response = await client.GetAsync("/api/Usuarios/GetAll");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task ReturnsMastersViewModel()
        {
            var client = await GetAdminClientAsync();
            var response = await client.GetAsync("/api/Usuarios/GetAll");

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<GetAllMaestroResponse>(response);

            Assert.IsType<GetAllMaestroResponse>(result);
            Assert.NotEmpty(result.Usuarios);
        }
    }
}
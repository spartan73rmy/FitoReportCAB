using Chikisistema.Application.UseCases.Usuarios.Commands.ConfirmarMaestro;
using Chikisistema.WebUi.FunctionalTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Chikisistema.WebUi.FunctionalTests.Controllers.Usuarios
{
    public class ConfirmarMaestro : BaseTestController
    {
        public ConfirmarMaestro(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task ConfirmaMaestroCorrectamente()
        {
            var client = await GetAdminClientAsync();

            var command = new ConfirmarMaestroCommand
            {
                IdMaestro = 4
            };

            var content = Utilities.GetRequestContent(command);
            var response = await client.PostAsync($"/api/Usuarios/ConfirmarMaestro", content);

            var responseContent = await Utilities.GetResponseContent<ConfirmarMaestroResponse>(response);

            Assert.Equal(command.IdMaestro, responseContent.IdMaestro);

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task ConfirmaMaestroBadRequest()
        {
            var client = await GetAdminClientAsync();

            var command = new ConfirmarMaestroCommand
            {
                IdMaestro = -1
            };

            var content = Utilities.GetRequestContent(command);
            var response = await client.PostAsync($"/api/Usuarios/ConfirmarMaestro", content);

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }

        [Fact]
        public async Task ConfirmaMaestroNotAuthorized()
        {
            var client = await GetMaestroClientAsync();
            var command = new ConfirmarMaestroCommand
            {
                IdMaestro = 3
            };

            var content = Utilities.GetRequestContent(command);
            var response = await client.PostAsync($"/api/Usuarios/ConfirmarMaestro", content);

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
﻿using Chikisistema.Application.UseCases.Usuarios.Commands.ModificarPassword;
using Chikisistema.WebUi.FunctionalTests.Common;
using System.Threading.Tasks;
using Xunit;

namespace Chikisistema.WebUi.FunctionalTests.Controllers.Usuarios
{
    public class ModificarPassword : BaseTestController
    {
        public ModificarPassword(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Theory]
        [InlineData("Alumno")]
        [InlineData("Maestro")]
        [InlineData("Admin")]
        public async Task ReturnsSuccessStatusCode(string username)
        {
            string passactual = "123";
            string passnueva = "123";

            var client = await GetAuthenticatedClientAsync(username, passactual);
            var command = new ModificarPasswordCommand
            {
                PasswordActual = passactual,
                PasswordNuevo = passnueva
            };

            var content = Utilities.GetRequestContent(command);
            var response = await client.PostAsync($"/api/Usuarios/ModificarPassword", content);

            var responseContent = await Utilities.GetResponseContent<ModificarPasswordResponse>(response);

            Assert.IsType<ModificarPasswordResponse>(responseContent);

            response.EnsureSuccessStatusCode();
        }
    }
}
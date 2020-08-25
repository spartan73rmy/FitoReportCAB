﻿using Chikisistema.WebUi.FunctionalTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Chikisistema.WebUi.FunctionalTests.Controllers.Cuenta
{
    public class Confirmar : BaseTestController
    {
        public Confirmar(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task ConfirmarUsuarioCorrectamente()
        {
            var client = GetClient();
            var response = await client.GetAsync($"/api/Cuenta/Confirmar?Token=123");

            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task ConfirmarMaestroNoAutorizado()
        {
            var client = GetClient();
            var response = await client.GetAsync($"/api/Cuenta/Confirmar?Token=1234");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}
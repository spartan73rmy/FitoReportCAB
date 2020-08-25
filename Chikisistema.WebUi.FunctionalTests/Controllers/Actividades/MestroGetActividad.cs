using Chikisistema.Application.UseCases.Actividades.Queries.GetMaestroActividad;
using Chikisistema.Common;
using Chikisistema.WebUi.FunctionalTests.Common;
using Chikisistema.WebUi.FunctionalTests.Mocks;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Chikisistema.WebUi.FunctionalTests.Controllers.Actividades
{
    public class MestroGetActividad : BaseTestController
    {
        public MestroGetActividad(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task RetornaCorrectamenteMaestroActividad()
        {
            var client = await GetMaestroClientAsync();
            var response = await client.GetAsync("/api/Actividades/MaestroGetActividad/1");

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<GetMaestroActividadResponse>(response);

            Assert.IsType<GetMaestroActividadResponse>(result);
            Assert.NotEmpty(result.Titulo);
            Assert.NotEmpty(result.Contenido);
            Assert.NotEmpty(result.MaterialApoyo);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task RetornaNotAuthorizedMaestroNoInscrito()
        {
            var client = await GetMaestroClientAsync();
            var response = await client.GetAsync("/api/Actividades/MaestroGetActividad/4");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task RetornaNotAuthorizedMaestro()
        {
            var client = await GetMaestroClientAsync();
            var response = await client.GetAsync("/api/Actividades/MaestroGetActividad/4");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);

        }

        [Fact]
        public async Task RetornaCorrectamenteMaestroActividad_YNoBloqueaContenido()
        {
            var dateNow = new DateTimeMock(new DateTime(2090, 01, 08, 06, 00, 00, DateTimeKind.Utc));
            var client = await GetMaestroClientAsync(services =>
            {
                services.AddSingleton<IDateTime, DateTimeMock>(imp => dateNow);
            });
            var response = await client.GetAsync("/api/Actividades/MaestroGetActividad/2");

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<GetMaestroActividadResponse>(response);

            Assert.NotEmpty(result.Titulo);
            Assert.NotEmpty(result.Contenido);
            Assert.NotEmpty(result.MaterialApoyo);
            Assert.Equal(2, result.Id);
        }
    }
}
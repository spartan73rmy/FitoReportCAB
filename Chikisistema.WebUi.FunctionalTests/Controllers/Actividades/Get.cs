using Chikisistema.Application.UseCases.Actividades.Queries.GetActividad;
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
    public class Get : BaseTestController
    {
        public Get(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task RetornaCorrectamenteActividad()
        {
            var client = await GetAlumnoClientAsync(services =>
            {
                services.AddSingleton<IDateTime, DateTimeMock>(imp => new DateTimeMock(new DateTime(2090, 01, 09, 06, 00, 00, DateTimeKind.Utc)));
            });

            var response = await client.GetAsync("/api/Actividades/get/2");

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<GetReporteResponse>(response);

            Assert.IsType<GetReporteResponse>(result);
            Assert.NotEmpty(result.Contenido);
            Assert.NotEmpty(result.MaterialApoyo);
            Assert.Equal(2, result.Id);
        }

        [Fact]
        public async Task RetornaCorrectamenteActividadOcultaContenido()
        {
            var client = await GetAlumnoClientAsync(services =>
            {
                services.AddSingleton<IDateTime, DateTimeMock>(imp => new DateTimeMock(new DateTime(2090, 01, 09, 05, 59, 59, DateTimeKind.Utc)));
            });

            var response = await client.GetAsync("/api/Actividades/get/2");

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<GetReporteResponse>(response);

            Assert.IsType<GetReporteResponse>(result);
            Assert.Null(result.Contenido);
            Assert.Null(result.MaterialApoyo);
            Assert.Equal(2, result.Id);
        }

        [Fact]
        public async Task RetornaCorrectamenteActividadSinActivacion()
        {
            var client = await GetAlumnoClientAsync();
            var response = await client.GetAsync("/api/Actividades/get/1");

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<GetReporteResponse>(response);

            Assert.IsType<GetReporteResponse>(result);
            Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task RetornaNotFound()
        {
            var client = await GetAlumnoClientAsync();
            var response = await client.GetAsync("/api/Actividades/get/777777");

            Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task RetornaNotAuthorizedAlumnoNoInscrito()
        {
            var client = await GetAlumnoClientAsync();
            var response = await client.GetAsync("/api/Actividades/get/4");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task RetornaCorrectamenteMaestro()
        {
            var client = await GetMaestroClientAsync(services =>
            {
                services.AddSingleton<IDateTime, DateTimeMock>(imp => new DateTimeMock(new DateTime(2090, 01, 09, 06, 00, 00, DateTimeKind.Utc)));
            });

            var response = await client.GetAsync("/api/Actividades/get/2");

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<GetReporteResponse>(response);

            Assert.IsType<GetReporteResponse>(result);
            Assert.NotEmpty(result.Contenido);
            Assert.NotEmpty(result.MaterialApoyo);
            Assert.Equal(2, result.Id);
        }

        [Fact]
        public async Task RetornaCorrectamenteMaestro_AunqueEsteBloqueada()
        {
            var client = await GetMaestroClientAsync(services =>
            {
                services.AddSingleton<IDateTime, DateTimeMock>(imp => new DateTimeMock(new DateTime(2090, 01, 09, 05, 00, 00, DateTimeKind.Utc)));
            });

            var response = await client.GetAsync("/api/Actividades/get/2");

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<GetReporteResponse>(response);

            Assert.IsType<GetReporteResponse>(result);
            Assert.NotEmpty(result.Contenido);
            Assert.NotEmpty(result.MaterialApoyo);
            Assert.Equal(2, result.Id);
        }

        [Fact]
        public async Task RetornaNotAuthorizedMaestro()
        {
            var client = await GetMaestroClientAsync();
            var response = await client.GetAsync("/api/Actividades/get/4");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
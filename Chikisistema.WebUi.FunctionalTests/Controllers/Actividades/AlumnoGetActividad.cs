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
    public class AlumnoGetActividad : BaseTestController
    {
        public AlumnoGetActividad(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task RetornaCorrectamenteAlumnoActividad()
        {
            var client = await GetAlumnoClientAsync();
            var response = await client.GetAsync("/api/Actividades/AlumnoGetActividad/1");

            response.EnsureSuccessStatusCode();

            //var result = await Utilities.GetResponseContent<GetAlumnoActividadResponse>(response);

            //Assert.IsType<GetAlumnoActividadResponse>(result);
            //Assert.NotEmpty(result.Titulo);
            //Assert.NotEmpty(result.Contenido);
            //Assert.NotEmpty(result.MaterialApoyo);
            //Assert.Equal(1, result.Id);
        }

        [Fact]
        public async Task RetornaNotAuthorizedAlumnoNoInscrito()
        {
            var client = await GetAlumnoClientAsync();
            var response = await client.GetAsync("/api/Actividades/AlumnoGetActividad/4");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }

        [Fact]
        public async Task RetornaNotAuthorizedMaestro()
        {
            var client = await GetMaestroClientAsync();
            var response = await client.GetAsync("/api/Actividades/AlumnoGetActividad/4");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
   
    }
}
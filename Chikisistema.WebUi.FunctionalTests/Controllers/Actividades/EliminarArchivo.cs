using Chikisistema.Application.UseCases.Actividades.Commands.EliminarArchivo;
using Chikisistema.WebUi.FunctionalTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Chikisistema.WebUi.FunctionalTests.Controllers.Actividades
{
    public class EliminarArchivo : BaseTestController
    {
        public EliminarArchivo(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task EliminarCorrectamenteArchivoDelMaterialDeApoyo()
        {
            var client = await GetMaestroClientAsync();

            var pet = new EliminarArchivoCommand
            {
                IdActividad = 2,
                Archivo = "323"
            };

            var response = await client.DeleteAsync($"/api/Actividades/EliminarArchivo?idActividad={pet.IdActividad}&archivo={pet.Archivo}");
            response.EnsureSuccessStatusCode();

        }

        [Fact]
        public async Task EliminarArchivoDelMaterialDeApoyo_RetornaBadRequest()
        {
            var client = await GetMaestroClientAsync();

            var pet = new EliminarArchivoCommand
            {
                IdActividad = 1,
                Archivo = "123"
            };

            var response = await client.DeleteAsync($"/api/Actividades/EliminarArchivo?idActividad={pet.IdActividad}&archivo={pet.Archivo}");
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        }

        [Fact]
        public async Task EliminarArchivoDelMaterialDeApoyo_CursoNoCreado_RetornaNoAutorizado()
        {
            var client = await GetMaestroClientAsync();

            var pet = new EliminarArchivoCommand
            {
                IdActividad = 4,
                Archivo = "789"
            };

            var response = await client.DeleteAsync($"/api/Actividades/EliminarArchivo?idActividad={pet.IdActividad}&archivo={pet.Archivo}");
            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);

        }

    }
}
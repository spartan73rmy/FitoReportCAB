using Chikisistema.Application.UseCases.Actividades.Commands.AgregarArchivo;
using Chikisistema.WebUi.FunctionalTests.Common;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Chikisistema.WebUi.FunctionalTests.Controllers.Actividades
{
    public class AgregarArchivo : BaseTestController
    {
        public AgregarArchivo(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task AgregaArchivoRetornaBadRequest()
        {
            var client = await GetMaestroClientAsync();
            var pet = new AgregarArchivoCommand
            {
                Archivo = "Hola",
                IdActividad = 1
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PostAsync("/api/Actividades/AgregarArchivo", content);

            var result = await Utilities.GetResponseContent<AgregarArchivoResponse>(response);
            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
        }
    }
}

using Chikisistema.Application.UseCases.Actividades.Commands.EditarActividad;
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
    public class EditarActividad : BaseTestController
    {
        public EditarActividad(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task EditarCorrectamenteActividad()
        {
            var client = await GetMaestroClientAsync();

            var req = new EditarReporteCommand
            {
                //IdActividad = 2,
                //IdTipoActividad = 2,
                //Titulo = "Kgdgd",
                //Contenido = "ajkak",
                //Valor = 41,
                //FechaLimite = new System.DateTime(2080, 01, 10),
                //FechaActivacion = new System.DateTime(2079, 01, 10)
            };

            var content = Utilities.GetRequestContent(req);
            var response = await client.PutAsync("/api/Actividades/EditarActividad", content);

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<EditarReporteResponse>(response);

            //Assert.IsType<EditarReporteResponse>(result);
            //Assert.Equal(req.IdActividad, result.Id);
            //Assert.Equal(req.IdTipoActividad, result.IdTipoActividad);
            //Assert.True(result.Id == 2);
        }

        [Fact]
        public async Task EditaCorrectamenteActividadSinFechaActivacion()
        {
            var client = await GetMaestroClientAsync();
            var pet = new EditarReporteCommand
            {
            
            };

            var content = Utilities.GetRequestContent(pet);
            var response = await client.PutAsync("/api/Actividades/EditarActividad", content);

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<EditarReporteResponse>(response);

            //Assert.IsType<EditarReporteResponse>(result);
            //Assert.Equal(pet.IdActividad, result.Id);
            //Assert.Equal(pet.IdTipoActividad, result.IdTipoActividad);
            //Assert.True(result.Id > 0);
            //Assert.Null(result.FechaActivacion);
        }      
    }
}

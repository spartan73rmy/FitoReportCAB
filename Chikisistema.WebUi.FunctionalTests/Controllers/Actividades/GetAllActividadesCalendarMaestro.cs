using Chikisistema.Application.UseCases.Actividades.Queries.GetAllActividadesCalendarMaestro;
using Chikisistema.WebUi.FunctionalTests.Common;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Chikisistema.WebUi.FunctionalTests.Controllers.Actividades
{
    public class GetAllActividadesCalendarMaestro : BaseTestController
    {
        public GetAllActividadesCalendarMaestro(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task ObtieneCorrectamente()
        {
            var client = await GetMaestroClientAsync();
            var response = await client.GetAsync("/api/Actividades/GetAllActividadesCalendarMaestro?from=2015-10-05" +
                "&to=2040-10-05");
            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<IEnumerable<GetAllActividadesCalendarMaestroResponse>>(response);

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task RetornaBadRequestFechaUnoMayorFechaDos()
        {
            var client = await GetMaestroClientAsync();
            var response = await client.GetAsync("/api/Actividades/GetAllActividadesCalendarMaestro?from=2040-10-05" +
                "&to=2040-10-05");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        }

        [Fact]
        public async Task NoAutorizado()
        {
            var client = GetClient();
            var response = await client.GetAsync("/api/Actividades/GetAllActividadesCalendarMaestro");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
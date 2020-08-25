using Chikisistema.Application.UseCases.Actividades.Queries.GetAllActividadesCalendar;
using Chikisistema.WebUi.FunctionalTests.Common;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Chikisistema.WebUi.FunctionalTests.Controllers.Actividades
{
    public class GetAllActividadesCalendar : BaseTestController
    {
        public GetAllActividadesCalendar(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task ObtieneCorrectamente()
        {
            var client = await GetAlumnoClientAsync();
            var response = await client.GetAsync("/api/Actividades/GetAllActividadesCalendar?firstDate=2015-10-05" +
                "&secondDate=2040-10-05");

            var result = await Utilities.GetResponseContent<IEnumerable<GetAllActividadesCalendarResponse>>(response);
            response.EnsureSuccessStatusCode();

            Assert.NotNull(result);
            Assert.NotEmpty(result);
        }

        [Fact]
        public async Task RetornaBadRequestFechaUnoMayorFechaDos()
        {
            var client = await GetAlumnoClientAsync();
            var response = await client.GetAsync("/api/Actividades/GetAllActividadesCalendar?firstDate=2040-10-05" +
                "&secondDate=2040-10-05");

            Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);

        }

        [Fact]
        public async Task NoAutorizado()
        {
            var client = GetClient();
            var response = await client.GetAsync("/api/Actividades/GetAllActividadesCalendar");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
using Chikisistema.Application.UseCases.Actividades.Queries.ByUnidadMaestro;
using Chikisistema.WebUi.FunctionalTests.Common;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Chikisistema.WebUi.FunctionalTests.Controllers.Actividades
{
    public class GetByUnidadMaestro : BaseTestController
    {
        public GetByUnidadMaestro(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task ObtieneCorrectamenteActividades()
        {
            var client = await GetMaestroClientAsync();

            var response = await client.GetAsync("/api/Actividades/GetByUnidadMaestro/1");

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<IEnumerable<ByUnidadMaestroResponse>>(response);

            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task ObtieneActividades_NotAuthorized()
        {
            var client = await GetMaestroClientAsync();

            var response = await client.GetAsync("/api/Actividades/GetByUnidadMaestro/4");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
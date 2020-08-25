using Chikisistema.Application.UseCases.Actividades.Queries.ByUnidadAlumno;
using Chikisistema.WebUi.FunctionalTests.Common;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;

namespace Chikisistema.WebUi.FunctionalTests.Controllers.Actividades
{
    public class GetByUnidadAlumno : BaseTestController
    {
        public GetByUnidadAlumno(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {
        }

        [Fact]
        public async Task ObtieneCorrectamenteActividades()
        {
            var client = await GetAlumnoClientAsync();

            var response = await client.GetAsync("/api/Actividades/GetByUnidadAlumno/1");

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<IEnumerable<ByUnidadAlumnoResponse>>(response);

            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count());
        }

        [Fact]
        public async Task ObtieneActividades_NotAuthorized()
        {
            var client = await GetAlumnoClientAsync();

            var response = await client.GetAsync("/api/Actividades/GetByUnidadAlumno/4");

            Assert.Equal(HttpStatusCode.Unauthorized, response.StatusCode);
        }
    }
}
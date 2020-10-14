using FitoReport.Application.UseCases.Plagas.Commands.DeletePlaga;
using FitoReport.WebUi.FunctionalTests.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace FitoReport.WebUi.FunctionalTests.Controllers.Plaga
{
    public class DeletePlaga : BaseTestController
    {
        public DeletePlaga(CustomWebApplicationFactory<Startup> factory) : base(factory)
        {

        }
        [Fact]
        public async Task EliminaCorrectamentePlaga()
        {
            var client = await GetAdminClientAsync();
            var response = await client.DeleteAsync("/api/Plaga/Delete/1");

            response.EnsureSuccessStatusCode();

            var result = await Utilities.GetResponseContent<DeletePlagaResponse>(response);

            Assert.IsType<DeletePlagaResponse>(result);
        }
    }
}

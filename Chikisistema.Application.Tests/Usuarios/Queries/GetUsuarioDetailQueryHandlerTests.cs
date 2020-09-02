using Chikisistema.Application.Tests.Infraestructure;
using Chikisistema.Application.UseCases.Usuarios.Queries.GetUsuarioDetail;
using Chikisistema.Persistence;
using Shouldly;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Chikisistema.Application.Tests.Usuarios.Queries
{
    [Collection("QueryCollection")]
    public class GetUsuarioDetailQueryHandlerTests
    {
        private readonly FitoReportDbContext _context;

        public GetUsuarioDetailQueryHandlerTests(QueryTestFixture fixture)
        {
            _context = fixture.Context;
        }

        [Fact]
        public async Task GetUsuarioDetail()
        {
            var sut = new GetUsuarioDetailHandler(_context);

            var result = await sut.Handle(new GetUsuarioDetailQuery { IdUsuario = 1 }, CancellationToken.None);

            result.ShouldBeOfType<GetUsuarioDetailResponse>();
            result.IdUsuario.ShouldBe(1);
        }
    }
}

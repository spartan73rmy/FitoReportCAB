
using Chikisistema.Persistence;
using System;
using Xunit;

namespace Chikisistema.Application.Tests.Infraestructure
{
    public class QueryTestFixture : IDisposable
    {
        public FitoReportDbContext Context { get; private set; }

        public QueryTestFixture()
        {
            Context = ChikisistemaDbContextFactory.Create();
        }

        public void Dispose()
        {
            ChikisistemaDbContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}

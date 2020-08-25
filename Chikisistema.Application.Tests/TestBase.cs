using Chikisistema.Application.Tests.Infraestructure;
using System;

namespace Chikisistema.Application.Tests
{
    public class TestBase : IDisposable
    {
        protected readonly Persistence.ChikisistemaDbContext context;
        public TestBase()
        {
            context = ChikisistemaDbContextFactory.Create();
        }

        public void Dispose()
        {
            ChikisistemaDbContextFactory.Destroy(context);
        }
    }
}
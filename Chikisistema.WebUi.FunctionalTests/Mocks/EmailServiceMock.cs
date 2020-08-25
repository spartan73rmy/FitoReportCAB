using Chikisistema.Application.Interfaces;
using Chikisistema.Application.Notifications.Models;
using System.Threading.Tasks;

namespace Chikisistema.WebUi.FunctionalTests.Mocks
{
    public class EmailServiceMock : IEmailService
    {
        public Task SendAsync(Email message)
        {
            return Task.CompletedTask;
        }
    }
}
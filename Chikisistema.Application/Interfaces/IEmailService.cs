using Chikisistema.Application.Notifications.Models;
using System.Threading.Tasks;

namespace Chikisistema.Application.Interfaces
{
    public interface IEmailService
    {
        Task SendAsync(Email message);
    }
}

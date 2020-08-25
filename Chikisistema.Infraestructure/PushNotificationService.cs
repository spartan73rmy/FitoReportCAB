using Chikisistema.Application.Interfaces;
using Chikisistema.Application.Notifications.Models;
using System;
using System.Threading.Tasks;

namespace Chikisistema.Infraestructure
{
    public class PushNotificationService : IPushNotificationService
    {
        public Task SendAsync(PushNotification message)
        {
            throw new NotImplementedException();
        }
    }
}

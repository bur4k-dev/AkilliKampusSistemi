using System;
using AkilliCampusSistemi.Domain.Interfaces;

namespace AkilliCampusSistemi.Application.Factories
{
    public static class NotificationFactory
    {
        // Altyapý (Infrastructure) katmanýndaki somut servisleri tetiklemek için 
        // gevþek baðlý (loosely coupled) bir yönlendirici (resolver) kullanýr
        public static INotificationService CreateNotificationService(string channelType, Func<string, INotificationService> serviceResolver)
        {
            return serviceResolver(channelType);
        }
    }
}
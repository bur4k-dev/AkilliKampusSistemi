using System;
using AkilliCampusSistemi.Domain.Interfaces;

namespace AkilliCampusSistemi.Infrastructure.Services
{
    public class PushNotificationService : INotificationService
    {
        public void SendNotification(string recipientName, string message)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine($"   [🔔 PUSH KANALI] ---> Alıcı: {recipientName} | Mesaj: {message}");
            Console.ResetColor();
        }
    }
}
using System;
using AkilliCampusSistemi.Domain.Interfaces;

namespace AkilliCampusSistemi.Infrastructure.Services
{
    public class EmailNotificationService : INotificationService
    {
        public void SendNotification(string recipientName, string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine($"   [✉️ E-POSTA KANALI] -> Alıcı: {recipientName} | Mesaj: {message}");
            Console.ResetColor();
        }
    }
}
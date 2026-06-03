using System;
using AkilliCampusSistemi.Domain.Interfaces;

namespace AkilliCampusSistemi.Infrastructure.Services
{
    public class SmsNotificationService : INotificationService
    {
        public void SendNotification(string recipientName, string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"   [📱 SMS KANALI] ----> Alıcı: {recipientName} | Mesaj: {message}");
            Console.ResetColor();
        }
    }
}
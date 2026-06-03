using System.Collections.Generic;
using AkilliCampusSistemi.Domain.Models;

namespace AkilliCampusSistemi.Domain.Interfaces
{
    public interface IObserver
    {
        string Name { get; }
        string UserType { get; }
        List<string> PreferredNotificationChannels { get; } // Örn: "Email", "SMS", "Push" [cite: 14, 15, 16]
        void Update(Announcement announcement);
    }
}
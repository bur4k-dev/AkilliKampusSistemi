using System.Collections.Generic;
using AkilliCampusSistemi.Domain.Interfaces;

namespace AkilliCampusSistemi.Domain.Models
{
    public abstract class User : IObserver
    {
        public string Name { get; protected set; }
        public abstract string UserType { get; }
        public List<string> PreferredNotificationChannels { get; set; } = new List<string>();

        protected User(string name, List<string> preferredChannels)
        {
            Name = name;
            PreferredNotificationChannels = preferredChannels;
        }


        public abstract void Update(Announcement announcement);
    }
}
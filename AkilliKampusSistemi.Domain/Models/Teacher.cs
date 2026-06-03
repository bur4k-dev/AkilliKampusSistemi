using System;
using System.Collections.Generic;

namespace AkilliCampusSistemi.Domain.Models
{
    public class Teacher : User
    {
        public override string UserType => "Öðretmen";

        public Teacher(string name, List<string> preferredChannels) : base(name, preferredChannels) { }

        public override void Update(Announcement announcement)
        {
             Console.WriteLine($"[Observer Aktif] {Name} ({UserType}), yeni duyuruyu yakaladý: {announcement.Title}");
        }
    }
}
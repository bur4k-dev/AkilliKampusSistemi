using System;
using System.Collections.Generic;

namespace AkilliCampusSistemi.Domain.Models
{
    public class Student : User
    {
        public override string UserType => "Öðrenci";

        public Student(string name, List<string> preferredChannels) : base(name, preferredChannels) { }

        public override void Update(Announcement announcement)
        {
            // Bu metot tetiklendiðinde tetiklenme logunu basýyoruz. 
            // Bildirim kanalýnýn simülasyonunu Application katmaný koordine edecek.
             Console.WriteLine($"[Observer Aktif] {Name} ({UserType}), yeni duyuruyu yakaladý: {announcement.Title}");
        }
    }
}
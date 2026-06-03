using System;
using AkilliCampusSistemi.Domain.Models;

namespace AkilliCampusSistemi.Application.Factories
{
    public static class AnnouncementFactory
    {
        // Gelen tipe göre uygun somut duyuru nesnesini üretip geriye soyut taban sýnýfý döner
        public static Announcement CreateAnnouncement(string type, string content)
        {
            return type.ToLower() switch
            {
                "exam" or "sýnav" => new ExamAnnouncement(content),
                "food" or "yemekhane" => new FoodMenuAnnouncement(content),
                _ => throw new ArgumentException($"Geçersiz duyuru tipi: {type}")
            };
        }
    }
}
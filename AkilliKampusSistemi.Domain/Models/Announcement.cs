using System;

namespace AkilliCampusSistemi.Domain.Models
{
    public abstract class Announcement
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        protected Announcement(string title, string content)
        {
            Title = title;
            Content = content;
        }
    }


    public class ExamAnnouncement : Announcement
    {
        public ExamAnnouncement(string content) : base("Sýnav Tarihi Deðiþikliði", content) { } // [cite: 10, 29]
    }

    public class FoodMenuAnnouncement : Announcement
    {
       public FoodMenuAnnouncement(string content) : base("Yemekhane Menüsü Güncellemesi", content) { } // [cite: 10, 31]
    }
}
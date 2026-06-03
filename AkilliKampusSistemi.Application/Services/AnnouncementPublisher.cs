using System.Collections.Generic;
using AkilliCampusSistemi.Domain.Interfaces;
using AkilliCampusSistemi.Domain.Models;
using AkilliCampusSistemi.Application.Singletons;

namespace AkilliCampusSistemi.Application.Services
{
    public class AnnouncementPublisher : ISubject
    {
        // Sisteme kayıt olan gözlemcilerin (Observer) listesi
        private readonly List<IObserver> _observers = new List<IObserver>();

        // Yeni bir kullanıcıyı duyuru sistemine abone eder
        public void Attach(IObserver observer)
        {
            _observers.Add(observer);
            NotificationCenter.Instance.Log($"{observer.Name} ({observer.UserType}) duyuru sistemine abone oldu.");
        }

        // Kullanıcıyı abonelikten çıkarır
        public void Detach(IObserver observer)
        {
            _observers.Remove(observer);
            NotificationCenter.Instance.Log($"{observer.Name} ({observer.UserType}) duyuru sisteminden ayrıldı.");
        }

        // Yeni duyuru yayınlandığında listedeki tüm aboneleri döngüyle tetikler
        public void Notify(Announcement announcement)
        {
            NotificationCenter.Instance.Log($"⚠️ YENİ DUYURU YAYINLANDI: {announcement.Title} ⚠️");

            foreach (var observer in _observers)
            {
                observer.Update(announcement);
            }
        }
    }
}
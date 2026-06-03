using System;

namespace AkilliCampusSistemi.Application.Singletons
{
    public class NotificationCenter
    {
        private static NotificationCenter _instance;
        private static readonly object _lock = new object();

        // Constructor private yapýlarak dýþarýdan "new" anahtar kelimesiyle üretilmesi engellenir
        private NotificationCenter() { }

        // Thread-safe (Multi-thread uyumlu) Singleton Instance eriþimi
        public static NotificationCenter Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new NotificationCenter();
                    }
                    return _instance;
                }
            }
        }

        // Sistem genelindeki olaylarý konsola sarý renkle basacak log metodu
        public void Log(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"[NotificationCenter LOG - {DateTime.Now.ToLongTimeString()}]: {message}");
            Console.ResetColor();
        }
    }
}
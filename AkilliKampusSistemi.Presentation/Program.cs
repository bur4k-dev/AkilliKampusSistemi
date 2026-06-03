using System;
using System.Collections.Generic;
using AkilliCampusSistemi.Domain.Interfaces;
using AkilliCampusSistemi.Domain.Models;
using AkilliCampusSistemi.Application.Services;
using AkilliCampusSistemi.Application.Factories;
using AkilliCampusSistemi.Application.Singletons;
using AkilliCampusSistemi.Infrastructure.Services;

namespace AkilliCampusSistemi.Presentation
{
    class Program
    {
        static void Main(string[] args)
        {
            // Konsol başlığını ve standart çıktı kodlamasını ayarlıyoruz
            Console.Title = "Akıllı Kampüs Duyuru ve Bildirim Yönetim Sistemi";
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // 0. ADIM: Singleton Kullanımı ile Sistemi Başlatma (Singleton Örnek Kullanımı)
            NotificationCenter.Instance.Log("Akıllı Kampüs Sistemi Başlatılıyor...");

            // Infrastructure katmanındaki somut servisleri dinamik çözmek için eşleştirici (Resolver) fonskiyonu
            Func<string, INotificationService> serviceResolver = (channelType) =>
            {
                return channelType.ToLower() switch
                {
                    "email" or "e-posta" => new EmailNotificationService(),
                    "sms" => new SmsNotificationService(),
                    "push" or "mobil" => new PushNotificationService(),
                    _ => throw new ArgumentException($"Bilinmeyen bildirim kanalı: {channelType}")
                };
            };

            // 1. & 2. ADIM: Sisteme örnek kullanıcılar eklenir ve bildirim tercihleri belirlenir (Senaryo Adım 1 & 2)
            NotificationCenter.Instance.Log("Senaryo Adım 1 & 2: Kullanıcılar oluşturuluyor ve bildirim tercihleri tanımlanıyor...");

            var ogrenciAhmet = new Student("Ahmet Yılmaz", new List<string> { "Email", "SMS" });
            var ogrenciAyse = new Student("Ayşe Demir", new List<string> { "Push" });
            var ogretmenMehmet = new Teacher("Prof. Dr. Mehmet Öztürk", new List<string> { "Email", "Push" });

            // Observer Pattern Yapısı: Publisher (Subject) ayağa kaldırılır ve gözlemciler (Observers) sisteme abone edilir
            var publisher = new AnnouncementPublisher();
            publisher.Attach(ogrenciAhmet);
            publisher.Attach(ogrenciAyse);
            publisher.Attach(ogretmenMehmet);

            Console.WriteLine("\n------------------------------------------------------------\n");

            // 3. & 4. ADIM: Yönetici yeni bir sınav duyurusu oluşturur ve Factory uygun nesneyi üretir (Senaryo Adım 3 & 4)
            NotificationCenter.Instance.Log("Senaryo Adım 3 & 4: Yönetici yeni sınav duyurusu talebi gönderiyor. Factory nesne üretiyor...");

            Announcement sinavDuyurusu = AnnouncementFactory.CreateAnnouncement("exam", "Yazılım Mimarisi Final Sınavı 12 Haziran saat 10:00'da yapılacaktır.");

            // 5. & 6. ADIM: Duyuru yayınlanır ve Observer yapısı ile ilgili kullanıcılar otomatik bilgilendirilir (Senaryo Adım 5 & 6)
            NotificationCenter.Instance.Log("Senaryo Adım 5 & 6: Duyuru yayınlanıyor ve Observer yapısıyla aboneler bilgilendiriliyor...");
            publisher.Notify(sinavDuyurusu);

            // 7. & 8. ADIM: Factory uygun bildirim kanalını üretir ve bildirim konsolda gösterilir (Senaryo Adım 7 & 8)
            Console.WriteLine("\n--- Senaryo Adım 7 & 8: Detaylı Bildirim Dağıtım Kanalları Tetikleniyor ---");

            List<User> sistemdekiKullanicilar = new List<User> { ogrenciAhmet, ogrenciAyse, ogretmenMehmet };

            foreach (var user in sistemdekiKullanicilar)
            {
                foreach (var kanal in user.PreferredNotificationChannels)
                {
                    // Factory uygun bildirim kanalını dinamik olarak üretir (NotificationFactory mantığı)
                    INotificationService bildirimServisi = NotificationFactory.CreateNotificationService(kanal, serviceResolver);

                    // Bildirim ilgili kanala göre konsolda simüle edilerek gösterilir
                    bildirimServisi.SendNotification(user.Name, $"{sinavDuyurusu.Title}: {sinavDuyurusu.Content}");
                }
            }

            Console.WriteLine("\n------------------------------------------------------------\n");

            // ÇOKLU DUYURU TİPİ DOĞRULAMASI: Yemekhane Menüsü Güncellemesi Testi
            NotificationCenter.Instance.Log("Ekstra Test Senaryosu: Sistemden yeni bir yemekhane menüsü duyurusu tetikleniyor...");
            Announcement yemekDuyurusu = AnnouncementFactory.CreateAnnouncement("food", "Bugünkü menüde Mercimek Çorbası, Tas Kebabı ve Pirinç Pilavı bulunmaktadır.");

            publisher.Notify(yemekDuyurusu);

            NotificationCenter.Instance.Log("Örnek senaryo başarıyla tamamlandı. Çıkmak için ENTER tuşuna basın...");
            Console.ReadLine();
        }
    }
}
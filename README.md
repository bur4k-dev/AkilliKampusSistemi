## 🎥 Ödev Sunum Videosu
👉 [Proje Sunum ve Detay Anlatım Videosunu İzlemek İçin Tıklayın](https://drive.google.com/file/d/1eL22rTj6W7Xtpzfc4L9rkOU6ihRUyYDb/view?usp=sharing)



# 🏛️ Akıllı Kampüs Duyuru ve Bildirim Yönetim Sistemi

Bu proje, **BİL 3204 Yazılım Mimari ve Tasarımı** dersi final ödevi kapsamında geliştirilmiştir. Sistem, bir üniversite kampüsündeki farklı duyuru türlerini (Sınav, Yemekhane vb.) merkezi bir fabrikadan üreterek, sisteme abone olan kullanıcılara (Öğrenci, Öğretmen) kendi tercih ettikleri bildirim kanalları (E-posta, SMS, Mobil Bildirim) üzerinden dinamik olarak ulaştıran **Katmanlı Mimari (4-Layer Architecture)** tabanlı bir .NET Core uygulamasıdır.

## 🛠️ Kullanılan Teknolojiler & Standartlar
* **Dil & Platform:** C# / .NET Core
* **Mimari Yapı:** 4 Katmanlı Mimari (Domain, Application, Infrastructure, Presentation)
* **Tasarım Prensipleri:** SOLID (Özellikle Open/Closed ve Single Responsibility), Loosely Coupled (Gevşek Bağlılık)

---

## 📐 Mimari Katman Yapısı (4-Layer)

Proje, bağımlılık zincirini minimumda tutmak ve sürdürülebilirliği artırmak adına 4 ana katmana ayrılmıştır:

1.  **Domain Layer (`AkilliCampusSistemi.Domain`):** Projenin kalbidir. Hiçbir katmana bağımlılığı yoktur. Ortak interface sözleşmelerini (`IObserver`, `ISubject`, `INotificationService`) ve temel iş modellerini (`User`, `Student`, `Teacher`, `Announcement`) barındırır.
2.  **Application Layer (`AkilliCampusSistemi.Application`):** İş mantığının ve tasarım desenlerinin (Pattern) yönetildiği katmandır. Duyuruların dağıtımını koordine eder ve fabrikasyon süreçlerini yönetir.
3.  **Infrastructure Layer (`AkilliCampusSistemi.Infrastructure`):** Domain katmanındaki soyut servislerin somutlaştırıldığı dış dünya katmanıdır. E-posta, SMS ve Push servislerinin simülasyonlarını barındırır.
4.  **Presentation Layer (`AkilliCampusSistemi.Presentation`):** Uygulamanın giriş noktası olan Konsol projesidir. Diğer tüm katmanları referans alarak ödev dökümanındaki örnek senaryoyu koordine eder.

---

## 🧩 Uygulanan Tasarım Desenleri (Design Patterns)

Ödev isterleri doğrultusunda projede 3 farklı tasarım deseni yapısal ve davranışsal olarak entegre edilmiştir:

### 1. Singleton Pattern (`NotificationCenter.cs`)
* **Neden Kullanıldı?:** Sistem genelinde merkezi, güvenli ve tek bir noktadan loglama/koordinasyon mekanizması sağlamak amacıyla kullanılmıştır.
* **Avantajı:** Bellekte gereksiz nesne üretimini (overhead) engeller ve `lock` mekanizması sayesinde thread-safe (çoklu iş parçacığı uyumlu) bir çalışma sunar.

### 2. Factory Pattern (`AnnouncementFactory.cs` & `NotificationFactory.cs`)
* **Neden Kullanıldı?:** İstemci katmanını (`Presentation`), somut nesnelerin (`ExamAnnouncement`, `EmailNotificationService` vb.) nasıl `new`leneceği bilgisinden bağımsız kılmak için kullanılmıştır.
* **Avantajı:** Nesne üretim süreçlerini tek merkezde toplar. Sisteme yeni bir duyuru veya bildirim kanalı eklendiğinde mevcut iş kodlarına dokunmadan sistemin genişletilmesini sağlar (**Open/Closed Principle**).

### 3. Observer Pattern (`AnnouncementPublisher.cs` & `User.cs`)
* **Neden Kullanıldı?:** Yeni bir duyuru yayınlandığında, o duyuruya abone olan öğrencilerin ve öğretmenlerin anında ve otomatik olarak bilgilendirilmesi problemini çözmek için kullanılmıştır.
* **Avantajı:** Sürekli sistemi sorgulama (polling) maliyetini ortadan kaldırır. Olay güdümlü (event-driven) ve gevşek bağlı bir abonelik altyapısı sunar.

---

## 🏃‍♂️ Sistemi Çalıştırma ve Örnek Senaryo Akışı

Uygulama başlatıldığında `Presentation` katmanındaki `Program.cs` üzerinde şu 8 adımlı senaryo simüle edilir:

1.  **Kullanıcı Kaydı:** Ahmet (Öğrenci), Ayşe (Öğrenci) ve Mehmet (Öğretmen) nesneleri oluşturulur.
2.  **Kanal Tercihleri:** Kullanıcıların bildirim tercihleri set edilir (Örn: Ahmet -> E-posta ve SMS, Ayşe -> Mobil Bildirim).
3.  **Abonelik:** Kullanıcılar `AnnouncementPublisher` (Subject) sistemine abone edilir.
4.  **Duyuru Talebi:** Yönetici bir sınav tarihi değişikliği duyurusu girmek ister.
5.  **Duyuru Üretimi:** `AnnouncementFactory` talebe uygun `ExamAnnouncement` nesnesini üretir.
6.  **Yayınlama (Notify):** Yayıncı duyuruyu tetikler; Observer yapısı sayesinde tüm aboneler duyuruyu algılar.
7.  **Servis Çözümleme:** `NotificationFactory` her kullanıcının kendi profiline giderek tercih ettiği kanala uygun servisleri (Email, SMS vb.) dinamik ayağa kaldırır.
8.  **Bildirim Gönderimi:** Kullanıcılara özel hazırlanmış mesajlar, tercih ettikleri kanalların renk kodlarıyla konsol ekranına basılır.

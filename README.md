# 🚗 CarBook — Araç Kiralama Platformu

CarBook, **ASP.NET Core 8** ile geliştirilmiş, modern bir araç kiralama web uygulamasıdır. Onion Architecture, CQRS, MediatR ve SignalR gibi güncel teknolojileri kullanan full-stack bir projedir.

---

## 📸 Ekran Görüntüleri

### Ana Sayfa
![Ana Sayfa](CarBook/Presentation/CarBook.WebUI/wwwroot/images/Ana%20Sayfa%201.png)
![Ana Sayfa](CarBook/Presentation/CarBook.WebUI/wwwroot/images/Ana%20Sayfa%202.png)
![Ana Sayfa](CarBook/Presentation/CarBook.WebUI/wwwroot/images/Ana%20Sayfa%203.png)
![Ana Sayfa](CarBook/Presentation/CarBook.WebUI/wwwroot/images/Ana%20Sayfa%204.png)

### Araç Listesi
![Araç Listesi](CarBook/Presentation/CarBook.WebUI/wwwroot/images/Ara%C3%A7%20Listesi.png)
![Araç Listesi](CarBook/Presentation/CarBook.WebUI/wwwroot/images/Ara%C3%A7%20Listesi%202.png)

### Araç Detay
![Araç Detay](CarBook/Presentation/CarBook.WebUI/wwwroot/images/Ara%C3%A7%20Detay.png)
![Araç Detay](CarBook/Presentation/CarBook.WebUI/wwwroot/images/Ara%C3%A7%20Detay%202.png)

### Fiyat Listesi
![Fiyat Listesi](CarBook/Presentation/CarBook.WebUI/wwwroot/images/Fiyat%20Listesi.png)
![Fiyat Listesi](CarBook/Presentation/CarBook.WebUI/wwwroot/images/Fiyat%20Listesi%202.png)

### Blog
![Blog Listesi](CarBook/Presentation/CarBook.WebUI/wwwroot/images/Blog%20Listesi.png)
![Blog Detay](CarBook/Presentation/CarBook.WebUI/wwwroot/images/Blog%20Listesi%20Detay.png)
![Blog Detay](CarBook/Presentation/CarBook.WebUI/wwwroot/images/Blog%20Listesi%20Detay%202.png)

### Rezervasyon
![Rezervasyon Onay](CarBook/Presentation/CarBook.WebUI/wwwroot/images/Rezervasyon%20Onay.png)
![Rezervasyon Mail](CarBook/Presentation/CarBook.WebUI/wwwroot/images/Rezervasyon%20Mail%20Onay%C4%B1.png)

### Giriş & Kayıt
![Giriş Sayfası](CarBook/Presentation/CarBook.WebUI/wwwroot/images/Giri%C5%9F%20Sayfas%C4%B1.png)
![Kayıt Sayfası](CarBook/Presentation/CarBook.WebUI/wwwroot/images/Kay%C4%B1t%20Sayfas%C4%B1.png)

### Admin Panel
![Admin Dashboard](CarBook/Presentation/CarBook.WebUI/wwwroot/images/Admin%20Dashboard.png)
![Admin Araç Listesi](CarBook/Presentation/CarBook.WebUI/wwwroot/images/Admin%20Ara%C3%A7%20Listesi.png)
![Rezervasyon Listesi](CarBook/Presentation/CarBook.WebUI/wwwroot/images/Rezervasyon%20Listesi.png)

### SignalR — Anlık Veriler
![SignalR](CarBook/Presentation/CarBook.WebUI/wwwroot/images/Signal%20R%20%C4%B0le%20Anl%C4%B1k%20Veriler.png)
![İstatistikler](CarBook/Presentation/CarBook.WebUI/wwwroot/images/%C4%B0statistikler.png)

---

## 🏗️ Mimari

Proje **Onion Architecture** prensibine göre katmanlı olarak geliştirilmiştir:

```
CarBook/
├── Core/
│   ├── CarBook.Domain          → Entity sınıfları
│   └── CarBook.Application     → CQRS, MediatR, Interface'ler, DTO'lar
├── Infrastructure/
│   └── CarBook.Persistance     → DbContext, Repository implementasyonları
└── Presentation/
    ├── CarBook.WebApi          → RESTful API
    └── CarBook.WebUI           → MVC Web Arayüzü
```

---

## 🚀 Kullanılan Teknolojiler

| Teknoloji | Açıklama |
|---|---|
| ASP.NET Core 8 | Web framework |
| Entity Framework Core | ORM |
| CQRS + MediatR | Command/Query pattern |
| SignalR | Gerçek zamanlı iletişim |
| JWT Authentication | API güvenliği |
| Cookie Authentication | UI oturum yönetimi |
| FluentValidation | Model doğrulama |
| AutoMapper | Nesne dönüşümleri |
| MailKit / MimeKit | Mail gönderimi |
| SQL Server | Veritabanı |
| Bootstrap 4 | UI framework |

---

## ⚙️ Kurulum

### Gereksinimler
- .NET 8 SDK
- SQL Server
- Visual Studio 2022 veya üzeri

### 1. Repoyu Klonla
```bash
git clone https://github.com/kullanici-adi/CarBook.git
cd CarBook
```

### 2. appsettings.json Dosyalarını Oluştur

**API** (`CarBook/Presentation/CarBook.WebApi/appsettings.json`):
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=.;Database=CarBookDb;Trusted_Connection=True;TrustServerCertificate=True;"
  },
  "Jwt": {
    "Key": "en-az-32-karakterlik-gizli-anahtar",
    "Issuer": "https://localhost:7211",
    "Audience": "https://localhost:7211",
    "Expire": "10"
  }
}
```

**UI** (`CarBook/Presentation/CarBook.WebUI/appsettings.json`):
```json
{
  "MailSettings": {
    "From": "mail@gmail.com",
    "FromName": "CarBook",
    "Host": "smtp.gmail.com",
    "Port": 587,
    "Password": "gmail-uygulama-sifresi"
  }
}
```

### 3. Veritabanını Oluştur
```bash
cd CarBook/Infrastructure/CarBook.Persistance
dotnet ef database update
```

### 4. Projeyi Çalıştır

Önce API'yi, ardından UI'ı başlat:
```bash
# API
cd CarBook/Presentation/CarBook.WebApi
dotnet run

# UI (ayrı terminal)
cd CarBook/Presentation/CarBook.WebUI
dotnet run
```

---

## 🔑 Özellikler

- 🚗 Araç listeleme, detay ve kiralama
- 📅 Rezervasyon oluşturma ve mail bildirimi
- 🔐 JWT + Cookie tabanlı kimlik doğrulama
- 👤 Kullanıcı kayıt ve giriş sistemi
- ⭐ Araç değerlendirme ve yorum sistemi
- 📝 Blog sistemi ve yorumlar
- 📊 Admin paneli (araç, rezervasyon, blog yönetimi)
- 📡 SignalR ile anlık istatistikler
- 🗺️ Lokasyon bazlı araç kiralama

---

## 📁 Proje Yapısı

```
CarBook.Application/
├── Features/
│   ├── CQRS/
│   │   ├── Commands/
│   │   ├── Queries/
│   │   ├── Handlers/
│   │   └── Results/
│   └── Mediator/
├── Interfaces/
├── Dto/
└── Tools/              → JWT Token Generator

CarBook.Persistance/
├── Context/            → DbContext
└── Repositories/       → Generic + özel repository'ler

CarBook.WebApi/
├── Controllers/        → API endpoint'leri
├── Hubs/               → SignalR Hub
└── Extensions/         → Servis kayıtları

CarBook.WebUI/
├── Areas/Admin/        → Admin panel
├── Controllers/        → MVC controller'lar
├── ViewComponents/     → Yeniden kullanılabilir bileşenler
└── Dtos/               → UI katmanı DTO'ları
```


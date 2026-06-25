# ZenBlog — Server (API)

ZenBlog blog uygulamasının .NET 9 tabanlı backend servisidir. Onion (Clean) Architecture ve CQRS prensipleriyle, katmanlı ve test edilebilir bir yapıda geliştirilmiştir.

## 🚀 Teknolojiler

- **.NET 9** / ASP.NET Core Minimal API
- **Entity Framework Core 9** (SQL Server) + Lazy Loading Proxies
- **MediatR** (CQRS — Command / Query ayrımı)
- **AutoMapper** (entity ↔ DTO eşlemeleri)
- **FluentValidation** (ValidationBehavior pipeline)
- **ASP.NET Core Identity** + **JWT Bearer** kimlik doğrulama
- **Result Pattern** (`BaseResult<T>`) ile standart API yanıtları
- Generic Repository + Unit of Work

## 🏛️ Mimari (Onion Architecture)
ZenBlogServer.sln

│

├── Core

│   ├── ZenBlog.Domain          # Entity'ler, temel iş kuralları

│   └── ZenBlog.Application      # CQRS (Commands/Queries/Handlers),

│                                #   DTO'lar, Validator'lar, Mapping,

│                                #   Endpoint tanımları, soyutlamalar

│

├── Infrastructure

│   └── ZenBlog.Persistence      # DbContext, Migrations, Repository,

│                                #   Identity, Interceptor'lar

│

└── Presentation

└── ZenBlog.Api              # Program.cs, DI, middleware, host

## ✨ Özellikler

- **Blog** yönetimi (CRUD, kategoriye göre listeleme, son 5 blog)
- **Category** yönetimi (CRUD, kategoriye ait bloglar)
- **Comment / SubComment** — anonim yorum & yanıt (Ad, Soyad, E-posta)
- **Message** — iletişim formu mesajları (okundu / okunmadı filtresi)
- **ContactInfo** — site iletişim bilgileri (adres, telefon, e-posta, harita)
- **Social** — dinamik sosyal medya bağlantıları
- **AppUser** — yazar kullanıcıları (Identity tabanlı)
- JWT ile korumalı uçlar + seçili public uçlar (`AllowAnonymous`)

## 🔐 Kimlik Doğrulama

- `/api/users/login` ile JWT token alınır.
- Korumalı uçlar için `Authorization: Bearer <token>` header'ı gönderilir.
- Public uçlar (blog/kategori listeleme, yorum gönderme, iletişim formu, sosyal/iletişim bilgileri) `AllowAnonymous` ile işaretlidir.

---

> Bu proje **ZenBlog** uygulamasının **backend (API)** kısmıdır.
> Frontend (Angular 21) için: **ZenBlogClient**

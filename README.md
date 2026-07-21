# 🚗 CarBook - Araç Kiralama Yönetim Sistemi

CarBook, **ASP.NET Core 8** teknolojileri kullanılarak geliştirilmiş, modern yazılım mimarileri ve tasarım desenleri esas alınarak hazırlanmış kapsamlı bir **Araç Kiralama Yönetim Sistemi** projesidir.

Proje; kullanıcıların araçları inceleyebildiği, rezervasyon oluşturabildiği ve blog içeriklerini takip edebildiği kullanıcı arayüzünün yanı sıra, tüm içeriklerin yönetilebildiği gelişmiş bir **Admin Paneli** de içermektedir.

# 📖 Proje Hakkında

CarBook, kullanıcıların araç kiralama süreçlerini kolayca gerçekleştirebildiği ve yöneticilerin sistemdeki tüm içerikleri tek bir panel üzerinden yönetebildiği kapsamlı bir araç kiralama otomasyonudur. Proje; araç yönetimi, rezervasyon işlemleri, blog yönetimi, lokasyon ve fiyatlandırma gibi birçok modülü tek bir platformda bir araya getirmektedir.

🌐 **Canlı Demo:** https://carbookui.runasp.net/

---

# 🚀 Kullanılan Teknolojiler

| Kategori | Teknolojiler |
|----------|--------------|
| **Backend** | ASP.NET Core 8, ASP.NET Core MVC, ASP.NET Core Web API, Entity Framework Core, SQL Server |
| **Kimlik Doğrulama** | ASP.NET Identity, JWT Authentication |
| **Mimari** | Onion Architecture, CQRS, Repository Pattern, MediatR, Dependency Injection, DTO Pattern |
| **Kütüphaneler** | AutoMapper, FluentValidation, Swagger (OpenAPI), Newtonsoft.Json |
| **Frontend** | HTML5, CSS3, Bootstrap 5, JavaScript, Razor View Engine |

---

# 🏛️ Yazılım Mimarisi

Projede **Onion Architecture** benimsenerek katmanlar birbirinden bağımsız ve sürdürülebilir bir yapı oluşturulmuştur. İş mantığı ile veri erişimi ayrıştırılmış, **CQRS** ve **MediatR** kullanılarak okunabilir ve ölçeklenebilir bir mimari tasarlanmıştır.

```text
Presentation
     │
Application
     │
Persistence
     │
Domain
```

Bu yapı sayesinde uygulamanın **bakımı kolaylaşmış**, **test edilebilirliği artırılmış** ve **katmanlar arası bağımlılık minimum seviyeye indirilmiştir.

# 🖼️ Proje Görselleri

## 🏠 Ana Sayfa

 <img width="1920" height="8287" alt="image" src="https://github.com/user-attachments/assets/5bccbfbd-7e14-4369-b483-264de0951a0a" />


---

## 🚗 Araç Listeleme

 <img width="1920" height="2893" alt="image" src="https://github.com/user-attachments/assets/65f4626f-9f10-40cb-abfe-bd9ccd35bb21" />


---

## 🚘 Araç Detay Sayfası

 <img width="1920" height="2953" alt="image" src="https://github.com/user-attachments/assets/74f2e87f-57a6-48f5-91f5-e7eda7beb860" />


---

## 📅 Fiyatlarımız Sayfası

 <img width="1920" height="2821" alt="image" src="https://github.com/user-attachments/assets/ed024254-e862-4ae7-a875-bac6537bc490" />


---

## 📄 Blog Detay Sayfası

<img width="1920" height="4148" alt="image" src="https://github.com/user-attachments/assets/b7883d92-5d34-46e6-808f-23c30fa6a165" />


---



---

# 🛠️ Admin Paneli

## 📊 Dashboard

 <img width="1920" height="1483" alt="image" src="https://github.com/user-attachments/assets/506b667a-ebf4-4d64-ac43-8fd6d92a23d0" />


---

## 🚗 Araç Yönetimi

 <img width="1920" height="1048" alt="image" src="https://github.com/user-attachments/assets/e93ddfc4-9dfa-4723-abb7-02f431688b81" />


---

## 🏷️ İstatistikler

 <img width="1917" height="730" alt="image" src="https://github.com/user-attachments/assets/c5e6fd09-9c06-48ed-b992-59424ebf4488" />


---



# 🚀 Kurulum

Projeyi bilgisayarınıza klonlayın.

```bash
git clone https://github.com/narinuluisik/CarBook.git
```

Proje klasörüne geçin.

```bash
cd CarBook
```

SQL Server bağlantı bilgilerini **appsettings.json** dosyasından güncelleyin.

Migration işlemlerini çalıştırın.

```powershell
Update-Database
```

Projeyi çalıştırın.

```bash
dotnet run
```

---

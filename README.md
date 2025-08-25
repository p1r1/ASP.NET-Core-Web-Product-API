# ASP.NET Core Web Product API

.NET 9 ile geliştirilmiş basit Product API uygulaması. PostgreSQL veritabanı kullanır.

## 📋 Gereksinimler

- [.NET 9.0 SDK](https://dotnet.microsoft.com/download)
- [PostgreSQL](https://www.postgresql.org/download/)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) veya [VS Code](https://code.visualstudio.com/)

## 🔧 Kurulum

### 1. Projeyi Klonlayın

```bash
git clone <repository-url>
cd ProductAPI
```

### 2. PostgreSQL Ayarları
```sql
CREATE DATABASE ProductDB;
```

### 3. Bağlantı Ayarlayın

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Host=localhost;Port=5432;Database=ProductDB;Username=postgres;Password=your_password;"
  }
}
```

### 4. Bağlantı Ayarlayın
```bash
# Package Manager Console
Update-Database

# Veya .NET CLI
dotnet ef database update
```
(opsiyonel. migration dosyaları yoksa oluşturup update yapın)
```bash
# Package Manager Console
Add-Migration InitialCreate

# Veya .NET CLI
dotnet ef migrations add InitialCreate
```

### 5. Uygulamayı Çalıştırın
```bash
dotnet run
```
## API Endpoints
Ürünleri Listele
```GET /api/products```

Tek Ürün Getir
```GET /api/products/{id}```

Yeni Ürün Ekle
```
POST /api/products
Content-Type: application/json

{
  "name": "Ürün Adı",
  "price": 99.99
}
```
Ürün Sil
```DELETE /api/products/{id}```

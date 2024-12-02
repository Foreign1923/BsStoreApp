# BStoreApp

BStoreApp, modern e-ticaret uygulamalarının backend ihtiyaçlarını karşılamak için geliştirilmiş bir Web API projesidir. Bu proje, ürün ve kullanıcı yönetimi, alışveriş sepeti ve sipariş işlevselliklerini RESTful API ilkelerine uygun bir şekilde sunmaktadır. ASP.NET Core altyapısıyla geliştirilmiş olup, güçlü bir güvenlik ve veri yönetimi sağlamak amacıyla tasarlanmıştır.

## Özellikler

### Kullanıcı Yönetimi
- **Kayıt ve Giriş İşlemleri:**  
  - Kullanıcılar hesap oluşturabilir ve güvenli bir şekilde giriş yapabilir.  
- **JWT Authentication:**  
  - Kullanıcı doğrulaması için JSON Web Tokens (JWT) kullanılarak, yetkilendirilmiş erişim sağlanmıştır.  
- **Rol Yönetimi:**  
  - Admin ve kullanıcı rollerine özel yetkilendirme mekanizmaları uygulanmıştır.  

### Ürün Yönetimi
- **CRUD İşlemleri:**  
  - Ürünlerin eklenmesi, düzenlenmesi, silinmesi ve listelenmesi için API uç noktaları geliştirilmiştir.  
- **Kategori ve Filtreleme:**  
  - Ürünler kategori bazlı filtrelenebilir ve belirli kriterlere göre sıralanabilir.  
- **Sayfalama (Pagination):**  
  - Çok sayıda ürünü yönetmek için sayfalama desteği eklenmiştir.  

### Alışveriş ve Sipariş Yönetimi
- **Sepet İşlemleri:**  
  - Kullanıcılar ürünleri sepetlerine ekleyebilir, sepet içeriğini düzenleyebilir ve kaldırabilir.  
- **Sipariş Tamamlama:**  
  - Sepetteki ürünlerin siparişe dönüştürülmesi sağlanmıştır.  
- **Sipariş Geçmişi:**  
  - Kullanıcılar, geçmiş siparişlerini görüntüleyebilir.  

### Güvenlik ve Yetkilendirme
- **JWT Tabanlı Kimlik Doğrulama:**  
  - Tüm API uç noktaları, yalnızca doğrulanmış kullanıcılar tarafından erişilebilir.  
- **Veri Güvenliği:**  
  - Kullanıcı ve ürün verileri MSSQL veritabanında güvenli bir şekilde saklanmaktadır.  

### Geliştirme ve Test
- **Postman:**  
  - API uç noktalarının doğruluğu ve performansı, Postman ile kapsamlı bir şekilde test edilmiştir.  
- **Hata Yönetimi:**  
  - API, detaylı hata mesajları ve özel hata işleme mekanizmaları sunar.  

## Teknolojiler
- **Backend:** ASP.NET Core (Web API)  
- **Database:** MSSQL  
- **Authentication:** JWT Authentication  
- **Version Control:** Git  
- **Testing:** Postman  

## Kurulum
1. Bu projeyi klonlayın:
   ```bash
   git clone https://github.com/Foreign1923/BStoreApp.git

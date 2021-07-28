# ASP.NET Core Web API & MSSQL & Swagger & Jwt Token

# Notepad

Bu Projede EntityFramework 6 kullandım. Tek gereken Notepad.EntityFramework
Katmanında dotnet ef database update yazmanız yeterli. 
Ancak Connection Stringi alışılmışın dışında yaptım. Notepad.Utilities katmanında
Config Klasörü içerisinde DatabaseConfig.cs dosyasında bulunan static DatabaseConfig Sınıfından Çekiyorum. 
Auth ve Jwt Sisteminde Identity ya da her hangi bir eklenti kullanmadım. Yapıyı kendim yazdım.

##TODO

Şimdiki hedef kalan servisleri tamamlayıp. Kendi yazdığım auth sisteminde check işlemlerini anotation'la yapıcam.
proje komple bitince daha ayrıntılı dokuman hazırlayacağım.
# ASP.NET Core Web API & MSSQL & Swagger & Jwt Token

# Notepad

Bu Projede EntityFramework 6 ile Dapper kullandım. Tek gereken Notepad.EntityFramework
Katmanında dotnet ef database update yazmanız yeterli. 
Ancak Connection Stringi alışılmışın dışında yaptım. Notepad.Utilities katmanında
Config Klasörü içerisinde DatabaseConfig.cs dosyasında bulunan static DatabaseConfig Sınıfından Çekiyorum. 
Auth ve Jwt Sisteminde Identity ya da her hangi bir eklenti kullanmadım. Yapıyı kendim yazdım. Yapıya Notepad.Auth katmanından ulaşabilirsiniz.
role permission sistemide var bitmedi tam ama kullanmıyorum şimdilik. Bir de Injection demişsiniz ödevde hocam :D full tonle inject var :D

##EntityFramework

Sadece Create işlemlerinde ve AnyAsync Olarak kullanıyorum. Join işlemleri varsa dapper repository kullanıyorum.
UnitOfWork Ef'de var dapper repository'e ekleme gereği duymadım Fatih Bey.

##Dapper

Dapper Repository'ye extra servis katmnımda uzun sqllerim varsa sqllerimi ayrı bir static sınıfın içinden çağırıyorum bu yönteme tam emin olamadım. Static ileride performans sorunu yaratır mı falan. 
Ama en azından servis katmanımda dapper repo kullanırken sql cümlelerim çok uzun olduğu zaman kalabalık ve yoğun kod olduğu için ayrı yerlerde tutuyorum okunabilirlik artıyor.
Örneğin:


    public static class UserSql
    {
        public const string GetById = @"SELECT 
                                              Users.*,
                                              Cities.Id as CityId,
                                              Cities.CityName
                                        FROM Users
                                        INNER JOIN Cities ON 
                                        Users.CityId = Cities.Id
                                        WHERE Users.Id=@Id";

        public const string GetAllAuthorNotesSql = @"SELECT 
                                                            Notes.Id,
                                                            Notes.CategoryId,
                                                            Notes.NoteTitle,
                                                            Notes.NoteContent,
                                                            NoteCategories.NoteCategoryTitle as NoteCategoryName
                                                    FROM Notes 
                                                    INNER JOIN NoteCategories
                                                    ON Notes.CategoryId = NoteCategories.Id
                                                    WHERE Notes.UserId = @UserId";
    }
,,,
Dapper yazarken parametre kullanmaya özen gösteriyorum hatta her şeyde parametre kullanıyorum allah korusun sql injection yeriz falan DByi elimize almayalım :D

##TODO

Şimdiki hedef kalan servisleri tamamlayıp. Kendi yazdığım auth sisteminde check işlemlerini anotation'la yapıcam.
proje komple bitince daha ayrıntılı dokuman hazırlayacağım.

#Fatih Hoca En Büyük. Nassıl amma 1 aydıır c# .net core çalışıyorum kavramış mıyım :)
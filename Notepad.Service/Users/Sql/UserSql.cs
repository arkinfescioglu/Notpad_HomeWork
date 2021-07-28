namespace Notepad.Service.Users.Sql
{
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
}
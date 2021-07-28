namespace Notepad.Service.Notes.Sql
{
    public static class NotesSql
    {
        public const string getByIdSql = @"SELECT 
                                                Notes.*,
                                                NoteCategories.Id as CategoryId,
                                                NoteCategories.NoteCategoryTitle as NoteCategoryName
                                           FROM Notes
                                           INNER JOIN NoteCategories
                                           ON Notes.CategoryId = NoteCategories.Id
                                           WHERE Notes.Id = @Id";

        public const string updateById = @"UPDATE Notes SET
                                           Notes.CategoryId=@CategoryId,
                                           Notes.NoteTitle=@NoteTitle,
                                           Notes.NoteContent=@NoteContent,
                                           Notes.ModifiedDate=@ModifiedDate
                                           WHERE Notes.Id=@Id";
    }
}
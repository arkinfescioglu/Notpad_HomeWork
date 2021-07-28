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
                                           ON Notes.Id = NoteCategories.Id
                                           WHERE Notes.Id = @Id";
    }
}
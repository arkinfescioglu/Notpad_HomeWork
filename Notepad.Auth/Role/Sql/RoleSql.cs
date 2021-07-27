namespace Notepad.Auth.Role.Sql
{
    public static class RoleSql
    {
        public const string getUserInfoSql = @"select 
                                                     Users.Id,
                                                     Users.UserTitleId,
                                                     UserTitles.ShortTitle
                                               from Users
                                               inner join UserTitles
                                               on UserTitles.Id = Users.UserTitleId
                                               where Users.Id=@Id";
    }
}
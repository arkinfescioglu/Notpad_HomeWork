namespace Notepad.Auth.Api.Sql
{
    public static class AutSql
    {
        public const string getUserByUsernameOrEmailQuery = @"select Users.* from Users 
                                                               where Username=@username OR Email=@username";
    }
}
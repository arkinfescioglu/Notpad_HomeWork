namespace Notepad.Auth.Api.Sql
{
    public static class AutSql
    {
        public const string getUserByUsernameOrEmailQuery = @"select 
                                                               Id,Username,Password,Email,FirstName,
                                                               LastName,AccountType 
                                                               from Users 
                                                               where Username=@username OR Email=@username";
    }
}
using Dapper;
using Microsoft.Data.SqlClient;
using Notepad.Utilities.Config;

namespace Notepad.Dapper.Connection
{
    public class DapperContext
    {
        public static SqlConnection GetConnection()
        {
            var connection = new SqlConnection {ConnectionString = DatabaseConfig.ConnectionString};
            return connection;
        }
    }
}
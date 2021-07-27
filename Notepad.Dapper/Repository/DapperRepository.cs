using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using Dapper.Contrib.Extensions;
using Notepad.Dapper.Connection;

namespace Notepad.Dapper.Repository
{
    public class DapperRepository<T> : IDapperRepository<T>
            where T : class, new()
    {
        public bool Execute(string sql, object param = null)
        {
            try
            {
                var connection = DapperContext.GetConnection();
                connection.Open();
                connection.Execute(sql, param);
                connection.Close();
                return true;
            }
            catch ( Exception )
            {
                return false;
            }
        }

        public async Task<bool> ExecuteAsync(string sql, object param = null)
        {
            try
            {
                var connection = DapperContext.GetConnection();
                await connection.OpenAsync();
                await connection.ExecuteAsync(sql, param);
                await connection.CloseAsync();
                return true;
            }
            catch ( Exception e )
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public IEnumerable<T> Query(string sql, object param = null)
        {
            try
            {
                var connection = DapperContext.GetConnection();
                connection.Open();
                var query = connection.Query<T>(sql, param);
                connection.Close();
                return query;
            }
            catch ( Exception )
            {
                return null;
            }
        }

        public async Task<IEnumerable<T>> QueryAsync(string sql, object param = null)
        {
            try
            {
                var connection = DapperContext.GetConnection();
                await connection.OpenAsync();
                var query = await connection.QueryAsync<T>(sql, param);
                await connection.CloseAsync();
                return query;
            }
            catch ( Exception )
            {
                return null;
            }
        }

        public T QueryFirst(string sql, object param = null)
        {
            try
            {
                var connection = DapperContext.GetConnection();
                connection.Open();
                var query = connection.QueryFirst<T>(sql, param);
                connection.Close();
                return query;
            }
            catch ( Exception )
            {
                return null;
            }
        }

        public async Task<T> QueryFirstAsync(string sql, object param = null)
        {
            try
            {
                var connection = DapperContext.GetConnection();
                await connection.OpenAsync();
                var query = await connection.QueryFirstAsync<T>(sql, param);
                await connection.CloseAsync();
                return query;
            }
            catch ( Exception )
            {
                return null;
            }
        }

        public T QueryFirstOrDefault(string sql, object param = null)
        {
            try
            {
                var connection = DapperContext.GetConnection();
                connection.Open();
                var query = connection.QueryFirstOrDefault<T>(sql, param);
                connection.Close();
                return query;
            }
            catch ( Exception )
            {
                return null;
            }
        }

        public async Task<T> QueryFirstOrDefaultAsync(string sql, object param = null)
        {
            try
            {
                var connection = DapperContext.GetConnection();
                await connection.OpenAsync();
                var query = await connection.QueryFirstOrDefaultAsync<T>(sql, param);
                await connection.CloseAsync();
                return query;
            }
            catch ( Exception )
            {
                return null;
            }
        }

        public T QuerySingle(string sql, object param = null)
        {
            try
            {
                var connection = DapperContext.GetConnection();
                connection.Open();
                var query = connection.QuerySingle<T>(sql, param);
                connection.Close();
                return query;
            }
            catch ( Exception )
            {
                return null;
            }
        }

        public async Task<T> QuerySingleAsync(string sql, object param = null)
        {
            try
            {
                var connection = DapperContext.GetConnection();
                await connection.OpenAsync();
                var query = await connection.QuerySingleAsync<T>(sql, param);
                await connection.CloseAsync();
                return query;
            }
            catch ( Exception )
            {
                return null;
            }
        }

        public T QuerySingleOrDefault(string sql, object param = null)
        {
            try
            {
                var connection = DapperContext.GetConnection();
                connection.Open();
                var query = connection.QuerySingleOrDefault<T>(sql, param);
                connection.Close();
                return query;
            }
            catch ( Exception )
            {
                return null;
            }
        }

        public async Task<T> QuerySingleOrDefaultAsync(string sql, object param = null)
        {
            try
            {
                var connection = DapperContext.GetConnection();
                await connection.OpenAsync();
                var query = await connection.QuerySingleOrDefaultAsync<T>(sql, param);
                await connection.CloseAsync();
                return query;
            }
            catch ( Exception )
            {
                return null;
            }
        }

        public async Task<bool> ExistAsync(string table, string column, dynamic param)
        {
            try
            {
                var connection = DapperContext.GetConnection();
                await connection.OpenAsync();
                var result = await connection.QuerySingleAsync(
                                     @"select Count(Id) from " + table + " where " + column + "=@param", new
                                     {
                                             param = param
                                     });
                await connection.CloseAsync();
                return result > 0;
            }
            catch ( Exception e )
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public List<T> GetAll()
        {
            return DapperContext.GetConnection().GetAll<T>()
                                .ToList();
        }

        public void Add(T entity)
        {
            DapperContext.GetConnection().Insert(entity);
        }

        public void Update(T entity)
        {
            DapperContext.GetConnection().Update(entity);
        }

        public void Delete(T entity)
        {
            DapperContext.GetConnection().Delete(entity);
        }

        public T GetById(int id)
        {
            return DapperContext.GetConnection().Get<T>(id);
        }
    }
}
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Notepad.Dapper.Repository
{
    public interface IDapperRepository<T>
            where T : class, new()
    {
        List<T>              GetAll();
        void                 Add(T                            entity);
        void                 Update(T                         entity);
        void                 Delete(T                         entity);
        T                    GetById(int                      id);
        bool                 Execute(string                   sql, object param = null);
        Task<bool>           ExecuteAsync(string              sql, object param = null);
        IEnumerable<T>       Query(string                     sql, object param = null);
        Task<IEnumerable<T>> QueryAsync(string                sql, object param = null);
        T                    QueryFirst(string                sql, object param = null);
        Task<T>              QueryFirstAsync(string           sql, object param = null);
        T                    QueryFirstOrDefault(string       sql, object param = null);
        Task<T>              QueryFirstOrDefaultAsync(string  sql, object param = null);
        T                    QuerySingle(string               sql, object param = null);
        Task<T>              QuerySingleAsync(string          sql, object param = null);
        T                    QuerySingleOrDefault(string      sql, object param = null);
        Task<T>              QuerySingleOrDefaultAsync(string sql, object param = null);

        Task<bool> ExistAsync(string table, string column, dynamic param);
    }
}
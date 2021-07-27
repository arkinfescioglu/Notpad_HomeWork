using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Notepad.Domain.Base;

namespace Notepad.EntityFramework.Repository
{
    public interface IEfRepository<T> where T:class,IEntity,new()
    {
        Task<T> GetAsync(Expression<Func<T,bool>> predicate,params Expression<Func<T,object>>[] includeProperties); // var kullanici = repository.GetAsync(k=>k.Id==15);

        Task<IList<T>> GetAllAsync(Expression<Func<T, bool>> predicate = null,
                params Expression<Func<T, object>>[]         includeProperties);

        Task       AddAsync(T                           entity);
        Task       UpdateAsync(T                        entity);
        Task       DeleteAsync(T                        entity);
        Task<bool> AnyAsync(Expression<Func<T, bool>>   predicate);
        Task<int>  CountAsync(Expression<Func<T, bool>> predicate);
    }
}
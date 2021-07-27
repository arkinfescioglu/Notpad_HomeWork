using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notepad.Domain.Base;

namespace Notepad.EntityFramework.Repository
{
    public class EfRepositoryBase<TEntity> : IEfRepository<TEntity>
            where TEntity : class, IEntity, new()
    {
        private readonly DbContext _context;

        public EfRepositoryBase(DbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().AnyAsync(predicate);
        }
        
        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _context.Set<TEntity>().CountAsync(predicate);
        }

        public async Task DeleteAsync(TEntity entity)
        {
            await Task.Run(() => { _context.Set<TEntity>().Remove(entity); });
        }

        public async Task<IList<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> predicate = null,
                params Expression<Func<TEntity, object>>[]                            includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if ( predicate != null )
            {
                query = query.Where(predicate);
            }

            if ( !includeProperties.Any() ) return await query.ToListAsync();

            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate,
                params Expression<Func<TEntity, object>>[]                  includeProperties)
        {
            IQueryable<TEntity> query = _context.Set<TEntity>();
            if ( predicate != null )
            {
                query = query.Where(predicate);
            }
            
            if ( !includeProperties.Any() ) return await query.SingleOrDefaultAsync();

            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));

            return await query.SingleOrDefaultAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            await Task.Run(() => { _context.Set<TEntity>().Update(entity); });
        }
    }
}
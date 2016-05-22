using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mastermind.Domain.Interfaces.Repositories;
using Mastermind.Infra.Data.Context;

namespace Mastermind.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly ApplicationDbContext _dbContext;

        protected readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = this._dbSet;

            if (filter != null)
                query = query.Where(filter);

            foreach (var includeProperty in includeProperties)
                query = query.Include(includeProperty);

            if (orderBy != null)
                return await orderBy(query).ToListAsync() as IEnumerable<TEntity>;
            else
                return await query.ToListAsync() as IEnumerable<TEntity>;
        }

        public virtual async Task<TEntity> GetAsync(object id)
        {
            return await this._dbSet.FindAsync(id);
        }

        public virtual void Add(TEntity entity)
        {
            this._dbSet.Add(entity);
        }

        public virtual void Remove(object id)
        {
            TEntity entityToDelete = this._dbSet.Find(id);
            Remove(entityToDelete);
        }

        public virtual void Remove(TEntity entity)
        {
            if (this._dbContext.Entry(entity).State == EntityState.Detached)
                this._dbSet.Attach(entity);

            this._dbSet.Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            this._dbSet.Attach(entity);
            this._dbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Dispose()
        {            
        }
    }
}

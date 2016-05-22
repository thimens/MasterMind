using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mastermind.Domain.Interfaces.Repositories;
using Mastermind.Infra.Data.Context;
using Mehdime.Entity;

namespace Mastermind.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        protected readonly IAmbientDbContextLocator _contextLocator;

        protected ApplicationDbContext DbContext
        {
            get
            {
                var dbContext = _contextLocator.Get<ApplicationDbContext>();

                if (dbContext == null)
                    throw new InvalidOperationException("No ambient DbContext of type ApplicationDbContext found. This means that this repository method has been called outside of the scope of a DbContextScope. A repository must only be accessed within the scope of a DbContextScope, which takes care of creating the DbContext instances that the repositories need and making them available as ambient contexts. This is what ensures that, for any given DbContext-derived type, the same instance is used throughout the duration of a business transaction. To fix this issue, use IDbContextScopeFactory in your top-level business logic service method to create a DbContextScope that wraps the entire business transaction that your service method implements. Then access this repository within that scope. Refer to the comments in the IDbContextScope.cs file for more details.");

                return dbContext;
            }
        }

        protected DbSet<TEntity> DbSet
        {
            get { return this.DbContext.Set<TEntity>(); }
        }

        public RepositoryBase(IAmbientDbContextLocator contextLocator)
        {
            _contextLocator = contextLocator;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, params Expression<Func<TEntity, object>>[] includeProperties)
        {
            IQueryable<TEntity> query = this.DbSet;

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
            return await this.DbSet.FindAsync(id);
        }

        public virtual void Add(TEntity entity)
        {
            this.DbSet.Add(entity);
        }

        public virtual void Remove(object id)
        {
            TEntity entityToDelete = this.DbSet.Find(id);
            Remove(entityToDelete);
        }

        public virtual void Remove(TEntity entity)
        {
            if (this.DbContext.Entry(entity).State == EntityState.Detached)
                this.DbSet.Attach(entity);

            this.DbSet.Remove(entity);
        }

        public virtual void Update(TEntity entity)
        {
            this.DbSet.Attach(entity);
            this.DbContext.Entry(entity).State = EntityState.Modified;
        }

        public void Dispose()
        {            
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mastermind.Application.Interfaces;
using Mastermind.Domain.Interfaces.Repositories;
using Mastermind.Infra.Data.Context;
using Mastermind.Domain.Interfaces.Services;
using Mehdime.Entity;

namespace Mastermind.Application
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        protected readonly IServiceBase<TEntity> _service;
        protected readonly IDbContextScopeFactory _dbContextFactory;

        public AppServiceBase(IDbContextScopeFactory dbContextFactory, IServiceBase<TEntity> service)
        {
            _service = service;
            _dbContextFactory = dbContextFactory;
        }

        public async Task<TEntity> GetAsync(object id)
        {
            using (var dbContextScope = _dbContextFactory.CreateReadOnly())
            {
                return await _service.GetAsync(id);
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            using (var dbContextScope = _dbContextFactory.CreateReadOnly())
            {
                return await _service.GetAllAsync();
            }
        }

        public void Add(TEntity entity)
        {
            using (var dbContextScope = _dbContextFactory.Create())
            {
                _service.Add(entity);
                dbContextScope.SaveChanges();
            }
        }

        public void Remove(object id)
        {
            using (var dbContextScope = _dbContextFactory.Create())
            {
                _service.Remove(id);
                dbContextScope.SaveChanges();
            }
        }

        public void Remove(TEntity entity)
        {
            using (var dbContextScope = _dbContextFactory.Create())
            {
                _service.Remove(entity);
                dbContextScope.SaveChanges();
            }
        }

        public void Update(TEntity entity)
        {
            using (var dbContextScope = _dbContextFactory.Create())
            {
                _service.Update(entity);
                dbContextScope.SaveChanges();
            }
        }

        public void Dispose()
        {
            _service.Dispose();
        }
    }
}

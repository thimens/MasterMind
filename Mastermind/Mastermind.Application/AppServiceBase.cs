
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mastermind.Application.Interfaces;
using Mastermind.Domain.Interfaces.Repositories;
using Mastermind.Infra.Data.Context;

namespace Mastermind.Application
{
    public class AppServiceBase<TEntity> : IDisposable, IAppServiceBase<TEntity> where TEntity : class
    {
        protected readonly IRepositoryBase<TEntity> _repository;
        protected readonly ApplicationDbContext _dbContext;

        public AppServiceBase(ApplicationDbContext dbContext, IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
            _dbContext = dbContext;
        }

        public async Task<TEntity> GetAsync(object id)
        {
            return await _repository.GetAsync(id);
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAsync();
        }

        public void Add(TEntity entity)
        {
            _repository.Add(entity);
            _dbContext.SaveChanges();
        }

        public void Remove(object id)
        {
            _repository.Remove(id);
            _dbContext.SaveChanges();
        }

        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
            _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}

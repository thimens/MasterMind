using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Mastermind.Domain.Interfaces.Repositories;
using Mastermind.Domain.Interfaces.Services;


namespace Mastermind.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        protected readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
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
        }

        public void Remove(object id)
        {
            _repository.Remove(id);
        }

        public void Remove(TEntity entity)
        {
            _repository.Remove(entity);
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }

        public void Dispose()
        {
            _repository.Dispose();
        }
    }

}

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mastermind.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity> where TEntity : class
    {
        Task<TEntity> GetAsync(object id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        void Add(TEntity entity);
        void Remove(object id);
        void Remove(TEntity entity);
        void Update(TEntity entity);
        void Dispose();
    }
}

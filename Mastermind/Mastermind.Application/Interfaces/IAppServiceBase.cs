using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mastermind.Application.Interfaces
{
    public interface IAppServiceBase<TEntity> where TEntity : class
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

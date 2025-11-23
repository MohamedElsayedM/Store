using Store.G05.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G05.Domain.Contracts
{
    public interface IGenericRepository<Tkey,TEntity> where TEntity: BaseEntity<Tkey>
    {
        Task<IEnumerable<TEntity>> GetAllAsync(bool changeTracker = false);
        Task<IEnumerable<TEntity>> GetAllAsync(ISpecifications<Tkey,TEntity> spec,bool changeTracker = false);
        Task<TEntity?> GetAsync(Tkey key);
        Task<TEntity?> GetAsync(ISpecifications<Tkey, TEntity> spec);
        Task<int> GetTotalCountAsync(ISpecifications<Tkey, TEntity> spec);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}

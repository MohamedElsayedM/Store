using Store.G05.Domain.Contracts;
using Store.G05.Domain.Entities;
using Store.G05.Presistence.Data.Contexts;
using Store.G05.Presistence.Repositories;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.G05.Presistence
{
    public class UnitOfWork(StoreDbContext _context) : IUnitOfWork
    {
        private ConcurrentDictionary<string, object> _repository = new ConcurrentDictionary<string, object>();

        public IGenericRepository<Tkey,TEntity> GetRepository<Tkey, TEntity>() where TEntity : BaseEntity<Tkey>
        {
            return (IGenericRepository<Tkey, TEntity>)_repository.GetOrAdd(typeof(TEntity).Name, new GenericRepository<Tkey, TEntity>(_context));
        }

        public async Task<int> SaveChngesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}

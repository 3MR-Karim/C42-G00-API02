using LinkDev.Talabat.Core.Domain.Common;
using LinkDev.Talabat.Core.Domain.Contracts;
using LinkDev.Talabat.Infrastructure.Persistence._Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Infrastructure.Persistence.Repositories
{
    internal class GenericRepository<TEntity, TKey>(StoreContext _dbcontext) : IGenericRepository<TEntity, TKey>
    where TEntity : BaseEntity<TKey>
        where TKey : IEquatable<TKey>

    {
        public async Task<IEnumerable<TEntity>> GetAllAsync(bool withTrackin = false)
       
        => withTrackin? await _dbcontext.Set<TEntity>().ToListAsync(): await _dbcontext.Set<TEntity>().AsNoTracking().ToListAsync();  
        //{

        //    if (withTrackin)
        //        return await _dbcontext.Set<TEntity>().ToListAsync();

        //return await _dbcontext.Set<TEntity>().AsNoTracking().ToListAsync();
                
                //}

        public async Task<TEntity> GetAsync(TKey id)
        =>  await _dbcontext.Set<TEntity>().FindAsync(id);
        

        public async Task AddAsync(TEntity entity) =>await _dbcontext.Set<TEntity>().AddAsync(entity);

        public void Delete(TEntity entity) => _dbcontext.Set<TEntity>().Remove(entity);

    
        public void update(TEntity entity)=>_dbcontext.Set<TEntity>().Remove(entity);
    }
}

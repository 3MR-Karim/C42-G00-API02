﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace LinkDev.Talabat.Core.Domain.Contracts
{
    public interface IGenericRepository<TEntity, TKey> 
        where TEntity : BaseEntity<TKey> where TKey:IEquatable<TKey>
    {

        Task<IEnumerable<TEntity>> GetAllAsync(bool withTrackin = false);
        Task<TEntity?> GetAsync(TKey id);
        Task AddAsync(TEntity entity);
        void update(TEntity entity);
        void Delete(TEntity entity);










    }
}

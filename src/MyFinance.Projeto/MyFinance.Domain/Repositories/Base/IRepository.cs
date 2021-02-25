﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MyFinance.Domain.Repositories.Base
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task Insert(TEntity Entity);
        Task Update(TEntity Entity);
        Task Remove(TEntity Entity);
        Task<TEntity> GetById(int Id);
        Task<List<TEntity>> Get();
        Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        Task<IList<TEntity>> GetList(Expression<Func<TEntity, bool>> predicate);

        IList<TEntity> GetAll();
    }
}

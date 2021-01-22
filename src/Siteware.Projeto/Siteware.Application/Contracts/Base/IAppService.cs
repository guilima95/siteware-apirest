using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Siteware.Application.Contracts.Base
{
    public interface IAppService<TEntity> where TEntity : class
    {
        Task Insert(TEntity Object);
        Task Update(TEntity Object);
        Task Remove(TEntity Object);
        Task<TEntity> GetById(int id);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> predicate);
        Task<IEnumerable<TEntity>> GetEnumerable(Expression<Func<TEntity, bool>> predicate);
    }
}

using Siteware.Application.Contracts;
using Siteware.Domain.Entities;
using Siteware.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Siteware.Application
{
    public class PromotionAppService : IPromotionAppService
    {
        public Task<Promotion> Get(Expression<Func<Promotion, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task<Promotion> GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Promotion>> GetEnumerable(Expression<Func<Promotion, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public Task Insert(Promotion Object)
        {
            throw new NotImplementedException();
        }

        public Task NewPromotion(RequestPromotionModel request)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Promotion Object)
        {
            throw new NotImplementedException();
        }

        public Task Update(Promotion Object)
        {
            throw new NotImplementedException();
        }
    }
}

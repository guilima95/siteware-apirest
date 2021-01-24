using Siteware.Application.Contracts;
using Siteware.Domain.Entities;
using Siteware.Domain.Models;
using Siteware.Domain.Repositories;
using Siteware.Domain.Repositories.Transaction;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Siteware.Application
{
    public class PromotionAppService : IPromotionAppService
    {
        private readonly IPromotionRepository promotion;
        private readonly IUnitOfWork unitOfWork;


        public PromotionAppService(IPromotionRepository promotion, IUnitOfWork unitOfWork)
        {
            this.promotion = promotion;
            this.unitOfWork = unitOfWork;
        }
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

        public async Task Insert(Promotion Object)
        {
            await promotion.Insert(Object);
            await unitOfWork.Commit();

        }

        public async Task NewPromotion(PromotionModel request)
        {
            var promotion = new Promotion(request.DescriptionPromotion, request.Type, request.Status);

            await Insert(promotion);
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

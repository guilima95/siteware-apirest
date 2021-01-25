using Siteware.Application.Contracts;
using Siteware.Domain.Entities;
using Siteware.Domain.Models;
using Siteware.Domain.Repositories;
using Siteware.Domain.Repositories.Transaction;
using Siteware.Infra.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Siteware.Application
{
    public class PromotionAppService : IPromotionAppService
    {
        private readonly IPromotionRepository promotionRepository;
        private readonly IProductRepository productRepository;

        private readonly IUnitOfWork unitOfWork;


        public PromotionAppService(IPromotionRepository promotionRepository, IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            this.promotionRepository = promotionRepository;
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
        }
        public Task<Promotion> Get(Expression<Func<Promotion, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Promotion>> GetAll()
        {
            return await Task.Run(() => promotionRepository.GetAll());
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
            await promotionRepository.Insert(Object);
            await unitOfWork.Commit();

        }

        public async Task NewPromotion(PromotionModel request)
        {
            var duplicate = await promotionRepository.Get(x => x.TypePromotion == request.Type);
            if (duplicate != null)
                throw new ValidationException($"already exists type promotion.");

            var promotionObj = new Promotion(request.DescriptionPromotion, request.Type, request.Status);
            await Insert(promotionObj);
        }

        public async Task Remove(Promotion Object)
        {
            await promotionRepository.Remove(Object);
            await unitOfWork.Commit();
        }

        public async Task Update(Promotion Object)
        {
            await promotionRepository.Update(Object);
            await unitOfWork.Commit();
        }
    }
}

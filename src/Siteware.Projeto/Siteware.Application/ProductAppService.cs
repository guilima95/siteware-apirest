using Siteware.Application.Contracts;
using Siteware.Domain.Entities;
using Siteware.Domain.Models;
using Siteware.Domain.Repositories;
using Siteware.Domain.Repositories.Transaction;
using Siteware.Domain.Services.Contracts;
using Siteware.Infra.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Siteware.Application
{
    public class ProductAppService : IProductAppService
    {
        private readonly IProductRepository product;
        private readonly IPromotionService servicePromotion;
        private readonly IUnitOfWork unitOfWork;
        public ProductAppService(IProductRepository product, IUnitOfWork unitOfWork, IPromotionService promotionService)
        {
            this.product = product;
            this.unitOfWork = unitOfWork;
            this.servicePromotion = promotionService;
        }
        public async Task<Product> Get(Expression<Func<Product, bool>> predicate)
        {
            return await product.Get(predicate);
        }

        public async Task<Product> GetById(int id)
        {
            return await product.GetById(id);
        }

        public async Task<IEnumerable<Product>> GetEnumerable(Expression<Func<Product, bool>> predicate)
        {
            return await product.GetList(predicate);
        }

        public async Task Insert(Product Object)
        {
            await product.Insert(Object);
            await unitOfWork.Commit();
        }

        public async Task Remove(Product Object)
        {
            await product.Remove(Object);
            await unitOfWork.Commit();

        }

        public async Task Update(Product Object)
        {
            await product.Update(Object);
            await unitOfWork.Commit();
        }

        public async Task NewProduct(ProductModel request)
        {
            // Validar entrada

            Product objProduct = null;
            PromotionProductModel objPromotion = null;

            if (request.Promotions.Count > 0)
            {
                foreach (var item in request.Promotions)
                {
                    objPromotion = await servicePromotion.GetPromotion(item);
                    objProduct = new Product(request.NameProduct, request.PriceProduct, objPromotion.PromotionId);

                }
            }
            else
            {
                objProduct = new Product(request.NameProduct, request.PriceProduct);
            }

            if (!objProduct.Invalid)
                await Insert(objProduct);
        }

        public async Task<Product> GetByName(string name)
        {
            var productObj = await product.Get(x => x.Name == name);
            if (productObj == null)
                throw new NotFoundException($"Product not found: {name}");

            var listPromotions = await servicePromotion.GetPromotions(productObj.PromotionId);

            // Laço para incrementar name da promoção
            foreach (var item in listPromotions)
            {
                item.Name = Enum.GetName(typeof(TypePromotion), item.TypePromotion);
                item.Status = Enum.GetName(typeof(StatusPromotion), item.StatusPromotion);
            }

            productObj.Promotions = listPromotions;

            return productObj;
        }
    }
}

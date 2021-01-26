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
        private readonly IPromotionRepository promotion;

        private readonly IUnitOfWork unitOfWork;
        public ProductAppService(IProductRepository product, IUnitOfWork unitOfWork, IPromotionRepository promotion)
        {
            this.product = product;
            this.unitOfWork = unitOfWork;
            this.promotion = promotion;
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

            Product objProduct = null;
            // Valida entrada

            if (string.IsNullOrEmpty(request.NameProduct))
                throw new ValidationException("Name the product is required.");

            if (!request.TypePromotion.HasValue)
                objProduct = new Product(request.NameProduct, request.PriceProduct);

            // Valida promotion
            else
            {
                if (request.TypePromotion.HasValue && !Enum.IsDefined(typeof(TypePromotion), request.TypePromotion))
                    throw new ValidationException("Product invalid. Promotion not found.");

                var objPromotion = await promotion.Get(x => x.TypePromotion == request.TypePromotion.Value);
                if (objPromotion == null)
                    throw new NotFoundException("");

                objProduct = new Product(request.NameProduct, request.PriceProduct, objPromotion.Id);

            }
           

            await product.Insert(objProduct);
            await unitOfWork.Commit();

        }




        public async Task<Product> GetByName(string name)
        {
            var productObj = await product.Get(x => x.Name == name);
            if (productObj == null)
                throw new NotFoundException($"Product not found: {name}");

            var listPromotions = await promotion.GetList(promotion => promotion.Id == productObj.PromotionId);

            // Laço para incrementar name da promoção
            foreach (var item in listPromotions)
            {
                item.Name = Enum.GetName(typeof(TypePromotion), item.TypePromotion);
                item.Status = Enum.GetName(typeof(StatusPromotion), item.StatusPromotion);
            }

            productObj.Promotions = listPromotions;

            return productObj;
        }

        public async Task UpdateProduct(ProductModel request)
        {
            Product objProduct = null;
            // Validar entrada

            if (string.IsNullOrEmpty(request.NameProduct))
                throw new ValidationException("Name the product is required.");



            if (request.TypePromotion.HasValue && Enum.IsDefined(typeof(TypePromotion), request.TypePromotion))
                throw new ValidationException("Product invalid. Promotion not .");
            else
                objProduct = new Product(request.NameProduct, request.PriceProduct);


            await product.Update(objProduct);
            await unitOfWork.Commit();
        }

        public async Task RemoveByName(string name)
        {
            var objProduct = await GetByName(name);
            await Remove(objProduct);
            await unitOfWork.Commit();
        }
    }
}

using Siteware.Application.Contracts;
using Siteware.Application.Contracts.Base;
using Siteware.Application.TotalPriceCart;
using Siteware.Application.TotalPriceCart.Concrete;
using Siteware.Domain.Entities;
using Siteware.Domain.Models;
using Siteware.Domain.Repositories;
using Siteware.Domain.Repositories.Transaction;
using Siteware.Domain.Services.Contracts;
using Siteware.Infra.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Siteware.Application
{
    public class CartAppService : ICartAppService
    {

        private readonly IPromotionRepository promotionRepository;
        private readonly IProductRepository produtRepository;
        private readonly ICartRepository cartRepository;


        private readonly IUnitOfWork unitOfWork;

        public CartAppService(IProductRepository produtRepository, IPromotionRepository promotionRepository,
                              ICartRepository cartRepository, IUnitOfWork unitOfWork)
        {
            this.promotionRepository = promotionRepository;
            this.produtRepository = produtRepository;
            this.cartRepository = cartRepository;
            this.unitOfWork = unitOfWork;


        }
        public async Task AddProduct(ProductCartModel productCart)
        {

            decimal totalPrice = 0;

            var product = await produtRepository.Get(p => p.Name == productCart.NameProduct && p.Price == productCart.PriceProduct);
            if (product == null)
                throw new NotFoundException($"Produt not found: {productCart.NameProduct}");


            var item = await promotionRepository.Get(x => x.TypePromotion == productCart.TypePromotion);

            if ((item == null) || (item.TypePromotion != productCart.TypePromotion || item.StatusPromotion != StatusPromotion.Active))
                throw new ValidationException($"Promotion not is valid for product current");


            // swith para ações devido aos tipos de promoções, usando decoretor pattern para calcular o valor total (mesmo objeto tendo ações diferentes).
            totalPrice = CalculateProductsWithPromotions(productCart);

            // persiste o produto no carrinho
            var cart = new Cart(productCart.Quantity, productCart.PriceProduct, totalPrice, product.Id, product.Name);


            await cartRepository.Insert(cart);
            await unitOfWork.Commit();

        }

        private static decimal CalculateProductsWithPromotions(ProductCartModel productCart)
        {
            decimal totalPrice;
            switch (productCart.TypePromotion)
            {
                case TypePromotion.Undefined:
                    throw new ValidationException("Promotion undefined.");
                case TypePromotion.ThreeForTen:
                    totalPrice = new CalculateThereForTen().CalculatePriceTotal(productCart);
                    break;
                case TypePromotion.BuyOneTakeTwo:
                    totalPrice = new CalculateOneTakeTwo().CalculatePriceTotal(productCart);
                    break;
                case TypePromotion.DiscountPercent:
                    totalPrice = new CalculateFivePercent().CalculatePriceTotal(productCart);
                    break;
                default:
                    totalPrice = new CalculatePriceTotalBase().CalculatePriceTotal(productCart);
                    break;

            }

            return totalPrice;
        }

        public async Task<CartProductModel> GetByProduct(string name)
        {
            var product = await produtRepository.Get(x => x.Name == name);

            if (product == null)
                throw new NotFoundException($"Product not found: {name}");

            var promotion = await promotionRepository.Get(x => x.Id == product.PromotionId);
            if (promotion == null)
                throw new ValidationException($"Promotion not found for is product.");

            var cart = await cartRepository.Get(x => x.ProductId == product.Id);

            var producCart = new CartProductModel
            {
                PriceTotal = cart.TotalPrice,
                Product =
                {
                    NameProduct = product.Name,
                    PriceProduct = product.Price,
                    Quantity = cart.Quantity,
                    TypePromotion = promotion.TypePromotion
                },
                PromotionDescription = promotion.Description
            };

            return producCart;
        }

        public async Task<CartTotalModel> GetCartAll()
        {
            decimal priceTotal = 0;
            var productCart = await cartRepository.GetCartProducts();

            foreach (var item in productCart)
            {
                priceTotal = +item.PriceTotal;
            }

            return new CartTotalModel
            {
                Cart = productCart,
                TotalBuy = priceTotal
            };

        }

        public async Task RemoveProduct(string name)
        {
            var product = produtRepository.Get(p => p.Name == name);
            if (product == null)
                throw new NotFoundException($"Not possible remove. Product not found: {name}");

            await cartRepository.RemoveByProductId(product.Id);
        }

        public async Task UpdateCart(int quantity, string name)
        {
            decimal totalPrice = 0;

            var product = await produtRepository.Get(p => p.Name == name);
            if (product == null)
                throw new NotFoundException($"Produt not found: {name}");


            var promotion = await promotionRepository.Get(x => x.Id == product.PromotionId);

            var productCart = new ProductCartModel
            {
                NameProduct = product.Name,
                PriceProduct = product.Price,
                Quantity = quantity,
                TypePromotion = promotion.TypePromotion
            };


            // swith para ações devido aos tipos de promoções, usando decoretor pattern para calcular o valor total (mesmo objeto tendo ações diferentes).
            totalPrice = CalculateProductsWithPromotions(productCart);

            // persiste o produto no carrinho
            var cart = new Cart(productCart.Quantity, productCart.PriceProduct, totalPrice, product.Id, product.Name);


            await cartRepository.Update(cart);
            await unitOfWork.Commit();
        }
    }
}

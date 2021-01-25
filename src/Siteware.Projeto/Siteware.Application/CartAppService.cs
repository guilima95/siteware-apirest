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
        private readonly IProductRepository produtRepository;
        private readonly ICartRepository cartRepository;
        private readonly IUnitOfWork unitOfWork;



        private readonly IProductService productService;
        private readonly IPromotionService promotionService;



        public CartAppService(IProductRepository produtRepository, ICartRepository cartRepository, IUnitOfWork unitOfWork,
                              IProductService productService, IPromotionService promotionService)
        {
            this.produtRepository = produtRepository;
            this.cartRepository = cartRepository;
            this.unitOfWork = unitOfWork;
            this.promotionService = promotionService;
            this.productService = productService;
        }
        public async Task AddProduct(ProductCartModel productCart)
        {

            decimal totalPrice = 0;

            var product = await produtRepository.Get(p => p.Name == productCart.NameProduct);
            if (product == null)
                throw new NotFoundException($"Produt not found: {productCart.NameProduct}");


            var promotions = await promotionService.GetPromotions(product.PromotionId);


            foreach (var promotion in promotions)
            {
                // Valida se a promoção cadastrada para o produto é a mesma ao inserir no carrinho
                if (promotionService.GetPromotion(promotion.TypePromotion).Result.TypePromotion != productCart.TypePromotion)
                    throw new ValidationException($"Promotion not is valid for product current");

                // swith para ações devido aos tipos de promoções, usando decoretor pattern para calcular o valor total (mesmo objeto tendo ações diferentes).
                switch (productCart.TypePromotion)
                {
                    case TypePromotion.Undefined:
                        throw new ValidationException("Promotion undefined.");
                    case TypePromotion.ThreeForTen:
                        totalPrice = await new CalculateThereForTen(productService, promotionService).CalculatePriceTotal(productCart);
                        break;
                    case TypePromotion.BuyOneTakeTwo:
                        totalPrice = await new CalculateOneTakeTwo(productService, promotionService).CalculatePriceTotal(productCart);
                        break;
                    case TypePromotion.DiscountPercent:
                        totalPrice = await new CalculateFivePercent(productService, promotionService).CalculatePriceTotal(productCart);
                        break;
                    default:
                        totalPrice = await new CalculatePriceTotalBase().CalculatePriceTotal(productCart);
                        break;
                }
            }

            // persiste o produto no carrinho
            var cart = new Cart(productCart.Quantity, productCart.PriceProduct, totalPrice, product.Id, product.Name);


            await cartRepository.Insert(cart);
            await unitOfWork.Commit();

        }
    }
}

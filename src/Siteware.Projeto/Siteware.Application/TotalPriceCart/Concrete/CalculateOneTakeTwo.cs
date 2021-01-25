using Siteware.Domain.Models;
using Siteware.Domain.Notification.Contracts;
using Siteware.Domain.Services.Contracts;
using Siteware.Infra.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Siteware.Application.TotalPriceCart.Concrete
{
    public class CalculateOneTakeTwo : CalculatePriceTotalBase
    {

        private readonly IProductService productService;
        private readonly IPromotionService promotionService;

        public CalculateOneTakeTwo(IProductService productService, IPromotionService promotionService)
            : base()
        {
            this.productService = productService;
            this.promotionService = promotionService;
        }

        public override async Task<decimal> CalculatePriceTotal(ProductCartModel productCart)
        {
            decimal totalPrice = 0;

            bool validProdut = await productService.ValidProductByCart(productCart.NameProduct, productCart.PriceProduct);

            if (!validProdut)
            {
                var promotion = await promotionService.GetPromotion(productCart.TypePromotion);

                if (productCart.Quantity % 2 != 0)
                    throw new ValidationException($"Promotion invalid. Buy at least one more item or remove 1 to get the promotion ");

                if (promotion.TypePromotion == Domain.Entities.TypePromotion.BuyOneTakeTwo && promotion.StatusPromotion == Domain.Entities.StatusPromotion.Active && productCart.Quantity % 2 == 0)
                    totalPrice = (productCart.PriceProduct * productCart.Quantity) * 50 / 100;

            }

            return totalPrice;
        }
    }
}

using Siteware.Domain.Models;
using Siteware.Domain.Notification.Contracts;
using Siteware.Domain.Services.Contracts;
using Siteware.Infra.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Siteware.Application.TotalPriceCart
{
    public class CalculateThereForTen : CalculatePriceTotalBase
    {
        private readonly IProductService productService;
        private readonly IPromotionService promotionService;

        public CalculateThereForTen(IProductService productService, IPromotionService promotionService)
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

                if (productCart.Quantity < 3 || (productCart.Quantity > 3 && productCart.Quantity % 2 != 0))
                    throw new ValidationException($"Promotion not is valid for quantity product. ");

                if (promotion.TypePromotion == Domain.Entities.TypePromotion.ThreeForTen && promotion.StatusPromotion == Domain.Entities.StatusPromotion.Active)
                    totalPrice = (productCart.Quantity / 3) * productCart.PriceProduct;

            }

            return totalPrice;
        }
    }
}

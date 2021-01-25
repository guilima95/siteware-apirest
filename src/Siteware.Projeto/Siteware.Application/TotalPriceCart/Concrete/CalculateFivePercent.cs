using Siteware.Domain.Models;
using Siteware.Domain.Notification.Contracts;
using Siteware.Domain.Services.Contracts;
using System.Threading.Tasks;

namespace Siteware.Application.TotalPriceCart.Concrete
{
    public class CalculateFivePercent : CalculatePriceTotalBase
    {

        private readonly IProductService productService;
        private readonly IPromotionService promotionService;

        public CalculateFivePercent(IProductService productService, IPromotionService promotionService)
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
                totalPrice = productCart.Quantity * productCart.PriceProduct;

                var promotion = await promotionService.GetPromotion(productCart.TypePromotion);

                if (productCart.Quantity > 0 && promotion.TypePromotion == Domain.Entities.TypePromotion.DiscountPercent && promotion.StatusPromotion == Domain.Entities.StatusPromotion.Active)
                    totalPrice = productCart.PriceProduct - productCart.PriceProduct * 5 / 100;


            }

            return totalPrice;
        }

    }
}

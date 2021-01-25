using Siteware.Domain.Models;

namespace Siteware.Application.TotalPriceCart.Concrete
{
    public class CalculateFivePercent : CalculatePriceTotalBase
    {

        public CalculateFivePercent()
                                  : base()
        {

        }

        public override decimal CalculatePriceTotal(ProductCartModel productCart)
        {

            decimal totalPrice = productCart.Quantity * productCart.PriceProduct;


            if (productCart.Quantity > 0 && productCart.TypePromotion == Domain.Entities.TypePromotion.DiscountPercent)
                totalPrice = productCart.PriceProduct - productCart.PriceProduct * 5 / 100;


            return totalPrice;
        }

    }
}

using Siteware.Domain.Models;

namespace Siteware.Application.TotalPriceCart
{
    public class CalculateThereForTen : CalculatePriceTotalBase
    {

        public CalculateThereForTen()
            : base()
        {

        }

        public override decimal CalculatePriceTotal(ProductCartModel productCart)
        {
            decimal totalPrice = 0;


            if (productCart.Quantity < 3 || (productCart.Quantity > 3 && productCart.Quantity % 2 == 0))
                totalPrice = productCart.Quantity * productCart.PriceProduct;

            else if (productCart.TypePromotion == Domain.Entities.TypePromotion.ThreeForTen && productCart.Quantity % 2 != 0)
                totalPrice = (productCart.Quantity / 3) * productCart.PriceProduct;



            return totalPrice;
        }
    }
}

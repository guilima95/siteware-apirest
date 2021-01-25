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

        public CalculateOneTakeTwo()
            : base()
        {


        }

        public override decimal CalculatePriceTotal(ProductCartModel productCart)
        {
            decimal totalPrice = 0;



            if (productCart.Quantity % 2 != 0)
                totalPrice = (productCart.PriceProduct * productCart.Quantity);

            if (productCart.TypePromotion == Domain.Entities.TypePromotion.BuyOneTakeTwo && productCart.Quantity % 2 == 0)
                totalPrice = (productCart.PriceProduct * productCart.Quantity) * 50 / 100;



            return totalPrice;
        }
    }
}

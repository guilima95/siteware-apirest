using Siteware.Application.Contracts.Base;
using Siteware.Domain.Models;
using Siteware.Domain.Notification;
using Siteware.Domain.Notification.Contracts;
using Siteware.Domain.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Siteware.Application
{
    public class CalculatePriceTotalBase : ICalculatePriceTotalBase
    {
        public CalculatePriceTotalBase() : base()
        {

        }

        public virtual decimal CalculatePriceTotal(ProductCartModel productCart)
        {
            return productCart.PriceProduct * productCart.Quantity;
        }
    }
}

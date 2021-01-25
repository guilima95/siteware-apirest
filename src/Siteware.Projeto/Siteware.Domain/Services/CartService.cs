using Siteware.Domain.Models;
using Siteware.Domain.Notification;
using Siteware.Domain.Notification.Contracts;
using Siteware.Domain.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Siteware.Domain.Services
{
    public class CartService : NotifierService, ICartService
    {


        public CartService(INotifier notifier) : base(notifier)
        {

        }

        public decimal CalculatePriceTotal(ProductCartModel productCart)
        {
            return productCart.Quantity * productCart.PriceProduct;
        }
    }
}

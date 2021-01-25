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
        private readonly IProductService productService;

        public CartService(INotifier notifier, IProductService productService) : base(notifier)
        {

            this.productService = productService;
        }

        public async Task<decimal> CalculatePriceTotal(ProductCartModel productCart)
        {
            decimal priceTotal = 0;
            bool validProdut = await productService.ValidProductByCart(productCart.NameProduct, productCart.PriceProduct);

            if (validProdut)
                priceTotal = productCart.Quantity * productCart.PriceProduct;
            else
                Notifier($"Product not valid.");


            return priceTotal;
        }
    }
}

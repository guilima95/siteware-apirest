using Siteware.Domain.Models;
using Siteware.Domain.Notification;
using Siteware.Domain.Notification.Contracts;
using Siteware.Domain.Repositories;
using Siteware.Domain.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Siteware.Domain.Services
{
    public class ProductService : NotifierService, IProductService
    {
        private readonly IProductRepository productRepository;

        public ProductService(INotifier notifier, IProductRepository productRepository) : base(notifier)
        {
            this.productRepository = productRepository;
        }

        public async Task<bool> ValidProductByCart(string name, decimal price)
        {
            var product = await productRepository.Get(p => p.Name == name && p.Price == price);
            if (product == null)
                Notifier($"Product with name {name} and price: {price} not found.");

            if (!HasNotification())
                return product.Valid;
            else
                return true;
        }
    }
}

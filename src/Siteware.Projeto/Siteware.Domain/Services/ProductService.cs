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

        public async Task<decimal> CalculatePriceTotal(List<CalculateProductModel> productModels)
        {
            decimal priceTotal = 0.0M;
            var produtcs = new List<CalculateProductModel>();

            foreach (var item in productModels)
            {
                // Verifica se o produto existe:
                var product = await productRepository.Get(x => x.Name == item.NameProduct);
                if (product == null)
                    Notifier($"Product Not found: [{item.NameProduct}]");

                priceTotal = item.PriceProduct++;
            }

            return priceTotal;
        }

        
    }
}

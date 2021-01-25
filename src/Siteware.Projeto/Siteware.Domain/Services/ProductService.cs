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

        
    }
}

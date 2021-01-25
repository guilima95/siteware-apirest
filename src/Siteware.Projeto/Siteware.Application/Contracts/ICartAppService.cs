using Siteware.Domain.Entities;
using Siteware.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Siteware.Application.Contracts
{
    public interface ICartAppService
    {
        Task AddProduct(ProductCartModel request);

        Task<CartTotalModel> GetCartAll();

        Task<CartProductModel> GetByProduct(string name);
        Task UpdateCart(int quantity, string name);

        Task RemoveProduct(string name);

    }
}

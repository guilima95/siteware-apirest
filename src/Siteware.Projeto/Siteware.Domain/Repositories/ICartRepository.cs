using Siteware.Domain.Entities;
using Siteware.Domain.Models;
using Siteware.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Siteware.Domain.Repositories
{
    public interface ICartRepository : IRepository<Cart>
    {
        Task<List<CartModel>> GetCartProducts();

        Task RemoveByProductId(int id);
    }
}

using Microsoft.EntityFrameworkCore;
using Siteware.Domain.Entities;
using Siteware.Domain.Models;
using Siteware.Domain.Repositories;
using Siteware.Infra.Repositories.Base;
using Siteware.Infra.SqlServer.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Siteware.Infra.Repositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        private readonly SitewareDbContext sitewareDbContext;
        public CartRepository(SitewareDbContext sitewareDbContext) : base(sitewareDbContext)
        {
            this.sitewareDbContext = sitewareDbContext;
        }



        public async Task<List<CartModel>> GetCartProducts()
        {


            var listProduct = await (from c in sitewareDbContext.Cart
                                     join p in sitewareDbContext.Product on c.ProductId equals p.Id
                                     join pm in sitewareDbContext.Promotion on p.PromotionId equals pm.Id into juncao 
                                     from j in juncao.DefaultIfEmpty() 
                                     select new CartModel
                                     {
                                         NameProduct = p.Name,
                                         PriceTotal = c.TotalPrice, 
                                         Promotion = j.Description,
                                         QuantityProduct = c.Quantity

                                     }).ToListAsync();


            return listProduct;

        }

        public async Task RemoveByProductId(int id)
        {
            var cartProduct = await sitewareDbContext.Cart.FirstOrDefaultAsync(x => x.ProductId == id);

            sitewareDbContext.Remove(cartProduct);
        }

    }
}

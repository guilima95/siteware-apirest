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
            var listProduct = await sitewareDbContext.Product.Join(
                sitewareDbContext.Cart,
                product => product.Id,
                cart => cart.ProductId,
                (product, cart) => new { product, cart }).Join(sitewareDbContext.Promotion,
                p => p.product.PromotionId,
                m => m.Id,
                (m, p) => new CartModel
                {
                    DescriptionPromotion = p.Description,
                    NameProduct = m.product.Name,
                    PriceTotal = m.cart.TotalPrice,
                    QuantityProduct = m.cart.Quantity
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

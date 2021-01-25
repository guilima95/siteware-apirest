using Siteware.Domain.Entities;
using Siteware.Domain.Repositories;
using Siteware.Infra.Repositories.Base;
using Siteware.Infra.SqlServer.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Infra.Repositories
{
    public class CartRepository : Repository<Cart>, ICartRepository
    {
        public CartRepository(SitewareDbContext context) : base(context)
        {
        }
    }
}

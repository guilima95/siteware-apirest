using Siteware.Domain.Entities;
using Siteware.Domain.Repositories;
using Siteware.Infra.Repositories.Base;
using Siteware.Infra.SqlServer.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace Siteware.Infra.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(SitewareDbContext context) : base(context)
        {
        }
    }
}

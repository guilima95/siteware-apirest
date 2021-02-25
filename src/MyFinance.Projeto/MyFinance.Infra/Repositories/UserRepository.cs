using MyFinance.Domain.Entities;
using MyFinance.Domain.Repositories;
using MyFinance.Infra.Repositories.Base;
using MyFinance.Infra.SqlServer.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFinance.Infra.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(MyFinanceDbContext context) : base(context)
        {
        }
    }
}

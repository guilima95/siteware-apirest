using MyFinance.Domain.Entities;
using MyFinance.Infra.Repositories.Base;
using MyFinance.Infra.SqlServer.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFinance.Infra.Repositories
{
    public class FinanceRepository : Repository<Finance>
    {
        public FinanceRepository(MyFinanceDbContext context) : base(context)
        {
        }
    }
}

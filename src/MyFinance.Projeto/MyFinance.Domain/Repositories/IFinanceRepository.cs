using MyFinance.Domain.Entities;
using MyFinance.Domain.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFinance.Domain.Repositories
{
    public interface IFinanceRepository : IRepository<Finance>
    {
    }
}

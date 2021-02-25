using System;
using System.Threading.Tasks;

namespace MyFinance.Domain.Repositories.Transaction
{
    public interface IUnitOfWork : IDisposable
    {
     
        Task<bool> Commit();

        void RollbackTransaction();
    }
}

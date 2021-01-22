using System;
using System.Threading.Tasks;

namespace Siteware.Domain.Repositories.Transaction
{
    public interface IUnitOfWork : IDisposable
    {
     
        Task<bool> Commit();
    }
}

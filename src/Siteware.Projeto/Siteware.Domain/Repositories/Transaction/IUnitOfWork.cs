namespace Siteware.Domain.Repositories.Transaction
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}

using Microsoft.EntityFrameworkCore.Storage;
using MyFinance.Domain.Repositories.Transaction;
using MyFinance.Infra.Exceptions;
using MyFinance.Infra.SqlServer.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Infra.Repositories.Transaction
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyFinanceDbContext _context;

        public UnitOfWork(MyFinanceDbContext context)
        {
            _context = context;
        }
        public void BeginTransaction()
        {
            var transaction = _context.Database.CurrentTransaction ?? _context.Database.BeginTransaction();
        }

        public async Task<bool> Commit()
        {
            try
            {
                int count = await _context.SaveChangesAsync();
                return count > 0;
            }
            catch (Exception ex)
            {
                _context.Database.RollbackTransaction();
                throw new ValidationException($"Error: {ex.InnerException.Message}");
            }

        }

        public void Dispose()
        {
            _context.Dispose();
        }


        public void RollbackTransaction()
        {
            _context.Database.RollbackTransaction();
        }
    }
}

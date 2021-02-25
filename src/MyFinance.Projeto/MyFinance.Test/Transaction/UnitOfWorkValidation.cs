using NSubstitute;
using MyFinance.Domain.Repositories.Transaction;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyFinance.Test.Transaction
{
    public static class UnitOfWorkValidation
    {
        public static void ValidarUnitOfWorkSucesso(IUnitOfWork mockUnitOfWork)
        {
            //mockUnitOfWork.Received(1).BeginTransaction();
            mockUnitOfWork.Received(1).Commit();
            //mockUnitOfWork.DidNotReceive().Rollback();
        }

        public static void ValidarUnitOfWorkErro(IUnitOfWork mockUnitOfWork)
        {
            //mockUnitOfWork.Received(1).BeginTransaction();
           // mockUnitOfWork.Received(1).Rollback();
            mockUnitOfWork.DidNotReceive().Commit();
        }
    }
}


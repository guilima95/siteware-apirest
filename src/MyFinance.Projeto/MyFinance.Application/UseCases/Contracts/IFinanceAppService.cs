using MyFinance.Application.Contracts.Base;
using MyFinance.Application.Models;
using MyFinance.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Application.UseCases.Contracts
{
    public interface IFinanceAppService
    {
        Task Add(FinanceRequest finance);
    }
}

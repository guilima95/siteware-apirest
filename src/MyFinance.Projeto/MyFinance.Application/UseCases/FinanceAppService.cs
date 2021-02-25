using MyFinance.Application.Models;
using MyFinance.Application.UseCases.Contracts;
using MyFinance.Domain.Entities;
using MyFinance.Domain.Notification;
using MyFinance.Domain.Notification.Contracts;
using MyFinance.Domain.Repositories;
using MyFinance.Domain.Repositories.Transaction;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyFinance.Application.UseCases
{
    public class FinanceAppService : NotifierService, IFinanceAppService
    {
        private readonly IUserRepository userRepository;
        private readonly IFinanceRepository financeRepository;

        private readonly IUnitOfWork unitOfWork;
        public FinanceAppService(INotifier notifier, IUnitOfWork unitOfWork, IUserRepository userRepository, IFinanceRepository financeRepository) : base(notifier)
        {
            this.userRepository = userRepository;
            this.financeRepository = financeRepository;

            this.unitOfWork = unitOfWork;
        }

        public async Task Add(FinanceRequest finance)
        {
            var user = await userRepository.Get(x => x.Name == finance.Profile);

            if (user == null)
                Notifier($"User not found.");

            var objFinance = new Finance
            {
                Amount = finance.Amount,
                Date = finance.Date,
                Description = finance.Description,
                Frequency = finance.Frequency,
                UserId = user.Id
            };

            await financeRepository.Insert(objFinance);
            await unitOfWork.Commit();

        }
    }
}

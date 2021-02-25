using MyFinance.API.Controllers.Base;
using MyFinance.Application.Models;
using MyFinance.Application.UseCases.Contracts;
using MyFinance.Domain.Notification.Contracts;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFinance.API.Controllers
{
    [Route("api/finance")]
    [ApiController]
    public class FinanceController : MainController
    {
        private readonly IFinanceAppService appService;
        public FinanceController(INotifier notifier, IFinanceAppService appService) : base(notifier)
        {
            this.appService = appService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(FinanceRequest request)
        {
            await appService.Add(request);
            return CustomResponse();
        }
    }
}

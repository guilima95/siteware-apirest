using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Siteware.API.Controllers.Base;
using Siteware.Application.Contracts;
using Siteware.Domain.Models;
using Siteware.Domain.Notification.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siteware.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : MainController
    {
        private readonly ICartAppService appService;
        public CartController(INotifier notifier, ICartAppService appService) : base(notifier)
        {
            this.appService = appService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductCartModel request)
        {
            await appService.AddProduct(request);
            return CustomResponse();
        }
    }
}

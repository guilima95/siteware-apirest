using Microsoft.AspNetCore.Mvc;
using Siteware.API.Controllers.Base;
using Siteware.API.Filters;
using Siteware.Application.Contracts;
using Siteware.Domain.Models;
using Siteware.Domain.Notification.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siteware.API.Controllers
{
    [Route("api/promotion")]
    [ApiController]
    public class PromotionController : MainController
    {
        private readonly IPromotionAppService appService;
        public PromotionController(INotifier notifier, IPromotionAppService appService) : base(notifier)
        {
            this.appService = appService;
        }


        [ProducesResponseType(200)]
        [ProducesResponseType(400, Type = typeof(BadRequestResult))]
        [ProducesResponseType(400, Type = typeof(ReturnError))]
        [HttpPost("new")]

        public async Task<IActionResult> Post([FromBody] PromotionModel request)
        {
            await appService.NewPromotion(request);
            return CustomResponse();
        }
    }
}

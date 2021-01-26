using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siteware.API.Controllers.Base;
using Siteware.API.Filters;
using Siteware.Application.Contracts;
using Siteware.Domain.Entities;
using Siteware.Domain.Models;
using Siteware.Domain.Notification.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Siteware.API.Controllers
{
    [Authorize]
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
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] PromotionModel request)
        {
            await appService.NewPromotion(request);
            return CustomResponse();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(TypePromotion type)
        {
            var promotion = await appService.Get(a => a.TypePromotion == type);

            await appService.Remove(promotion);
            return CustomResponse();
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] PromotionModel request)
        {
            await appService.NewPromotion(request);
            return CustomResponse();
        }

        [HttpGet("type-promotion")]
        public async Task<IActionResult> Get(TypePromotion type)
        {
            var promotion = await appService.Get(a => a.TypePromotion == type);
            return CustomResponse(promotion);
        }

        [HttpGet("all")]
        public async Task<IActionResult> GetAll()
        {
            var promotion = await appService.GetAll();
            return CustomResponse(promotion);
        }
    }
}

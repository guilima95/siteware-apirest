using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Siteware.API.Controllers.Base;
using Siteware.API.Filters;
using Siteware.Application.Contracts;
using Siteware.Domain.Models;
using Siteware.Domain.Notification.Contracts;
using System.Threading.Tasks;

namespace Siteware.API.Controllers
{
    [Authorize]
    [Route("api/cart")]
    [ApiController]
    public class CartController : MainController
    {
        private readonly ICartAppService appService;
        public CartController(INotifier notifier, ICartAppService appService) : base(notifier)
        {
            this.appService = appService;
        }

        [HttpPost("product/cart")]
        public async Task<IActionResult> Post([FromBody] ProductCartModel request)
        {
            await appService.AddProduct(request);
            return CustomResponse();
        }

        [ProducesResponseType(200, Type = typeof(CartTotalModel))]
        [ProducesResponseType(400, Type = typeof(BadRequestResult))]
        [ProducesResponseType(400, Type = typeof(ReturnError))]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var response = await appService.GetCartAll();
            return CustomResponse(response);
        }

        [HttpDelete("product/cart")]
        public async Task<IActionResult> Delete(string nameProduct)
        {
            await appService.RemoveProduct(nameProduct);
            return CustomResponse();
        }


        [HttpPut("product/cart")]
        public async Task<IActionResult> Put(string nameProduct, int quantity)
        {
            await appService.UpdateCart(quantity, nameProduct);
            return CustomResponse();
        }



    }
}

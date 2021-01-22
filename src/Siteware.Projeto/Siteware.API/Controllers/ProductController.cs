using Microsoft.AspNetCore.Mvc;
using Siteware.API.Controllers.Base;
using Siteware.Application.Contracts;
using Siteware.Domain.Models;
using Siteware.Domain.Notification.Contracts;
using System.Threading.Tasks;

namespace Siteware.API.Controllers
{
    [Route("api/product")]
    [ApiController]
    public class ProductController : MainController
    {
        private readonly IProductAppService appService;
        public ProductController(INotifier notifier, IProductAppService appService) : base(notifier)
        {
            this.appService = appService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return null;
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await appService.GetById(id);
            return CustomResponse(response);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RequestProductModel request)
        {
            await appService.NewProduct(request);
            return CustomResponse();
        }


        [HttpPut]
        public async Task<IActionResult> Put([FromBody] string name, decimal price)
        {
            return null;
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return null;
        }
    }
}

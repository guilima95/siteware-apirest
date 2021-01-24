using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Siteware.API.Controllers.Base;
using Siteware.API.ViewModels;
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
        private readonly IMapper mapper;
        public ProductController(INotifier notifier, IProductAppService appService, IMapper mapper) : base(notifier)
        {
            this.appService = appService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get(string name)
        {
            var response = mapper.Map<ProductViewModel>(await appService.GetByName(name));
            return CustomResponse(response);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await appService.GetById(id);
            return CustomResponse(response);
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ProductModel request)
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

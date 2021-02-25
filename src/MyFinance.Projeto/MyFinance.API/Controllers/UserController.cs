using Microsoft.AspNetCore.Mvc;
using MyFinance.API.Auth;
using MyFinance.API.Controllers.Base;
using MyFinance.API.Models;
using MyFinance.Application.Contracts;
using MyFinance.Domain.Notification.Contracts;
using System.Threading.Tasks;
using MyFinance.Application.UseCases.Contracts;
using Microsoft.Extensions.Configuration;

namespace MyFinance.API.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : MainController
    {
        private readonly IUserAppService appService;
        private readonly IConfiguration configuration;
        public UserController(INotifier notifier, IUserAppService appService, IConfiguration configuration) : base(notifier)
        {
            this.appService = appService;
            this.configuration = configuration;
        }

        [HttpPost]
        [Route("auth")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UserResolver model)
        {
            // Recupera o usuário
            var user = await appService.Get(x => x.Name == model.Username && x.Password == model.Password);

            // Verifica se o usuário existe
            if (user == null)
                return NotFound("User not found.");

            model.Username = user.Name;

            // Gera o Token
            var token = new GenerateToken(configuration: configuration).GetToken(model);

            // Oculta a senha
            model.Password = "";

            // Retorna os dados
            return new
            {
                user = user,
                token = token
            };
        }
    }
}

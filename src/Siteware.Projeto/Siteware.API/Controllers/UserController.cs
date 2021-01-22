using Microsoft.AspNetCore.Mvc;
using Siteware.API.Auth;
using Siteware.API.Controllers.Base;
using Siteware.API.Models;
using Siteware.Application.Contracts;
using Siteware.Domain.Notification.Contracts;
using System.Threading.Tasks;

namespace Siteware.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : MainController
    {
        private readonly IUserAppService appService;
        public UserController(INotifier notifier, IUserAppService appService) : base(notifier)
        {
            this.appService = appService;
        }

        [HttpPost]
        [Route("auth")]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] UserResolver model)
        {
            // Recupera o usuário
            var user = await appService.Get(x => x.Name == model.Username);

            // Verifica se o usuário existe
            if (user == null)
                NotFound("User not found.");

            model.Id = user.Id;
            model.Username = user.Name;

            // Gera o Token
            var token = GenerateToken.GetToken(model);

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

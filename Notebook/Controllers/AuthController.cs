using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Notebook.Application.Auth.Commands;
using Notebook.Application.Dto.Auth;
using System.Threading.Tasks;

namespace Notebook.Controllers
{
    public class AuthController : BaseApiController
    {
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userDto)
        {
            return HandleResult(await Mediator.Send(new LoginCommand()
            {
                UserLoginDto = userDto,
                HttpContext = base.HttpContext,
                Response = base.Response
            }));
        }
    }
}
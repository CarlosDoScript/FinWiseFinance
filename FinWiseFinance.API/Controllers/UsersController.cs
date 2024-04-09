using FinWiseFinance.Application.Commands.CreateUser;
using FinWiseFinance.Application.Commands.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinWiseFinance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> PostAsync([FromBody] CreateUserCommand command)
        {
            return Ok();
        }

        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var loginUserViewModel = await mediator.Send(command);

            if (loginUserViewModel == null)
                return BadRequest("CPF/CNPJ ou Senha Incorretos.");

            return Ok(loginUserViewModel);
        }
    }
}

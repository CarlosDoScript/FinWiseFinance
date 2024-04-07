using FinWiseFinance.Application.Commands.LoginUser;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FinWiseFinance.API.Controllers
{
    public class UsersController : Controller
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var loginUserViewModel = await _mediator.Send(command);

            return Ok(loginUserViewModel);
        }
    }
}

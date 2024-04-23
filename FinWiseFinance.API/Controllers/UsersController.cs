using FinWiseFinance.Application.Commands.CreateUser;
using FinWiseFinance.Application.Commands.DesactiveUser;
using FinWiseFinance.Application.Commands.LoginUser;
using FinWiseFinance.Application.Queries.GetUserById;
using FinWiseFinance.Application.Queries.GetUserExistentByCpfCnpj;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FinWiseFinance.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsersController(IMediator _mediator) : ControllerBase
    {
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetUserByIdQuery(id);

            var user = await _mediator.Send(query);

            if(user == null)
                return NotFound();

            return Ok(user);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Post([FromBody] CreateUserCommand command)
        {
            var query = new GetUserExistentByCpfCnpjQuery(command.CpfCnpj);

            var userExistent = await _mediator.Send(query);

            if (userExistent != null)
                return BadRequest("Usuário já existe");

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id }, command);
        }

        [HttpPut("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login([FromBody] LoginUserCommand command)
        {
            var loginUserViewModel = await _mediator.Send(command);

            if (loginUserViewModel == null)
                return BadRequest("CPF/CNPJ ou Senha Incorretos");

            return Ok(loginUserViewModel);
        }

        [HttpPut("desactive")]
        public async Task<IActionResult> Desactive([FromBody] DesactiveUserCommand command)
        {
            await _mediator.Send(command);

            return Ok();
        }
    }
}

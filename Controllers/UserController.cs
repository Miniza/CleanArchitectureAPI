using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineVets.Application.Commands;
using OnlineVets.Application.Queries;
using OnlineVets.Core.Entities;

namespace OnlineVets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<List<User>> GetUsers()
        {
            return await mediator.Send(new GetAllUsersQuery());
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<ActionResult<User>> RegisterUser([FromForm] CreateUserCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}

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
    public class OwnerController : ControllerBase
    {
        private readonly IMediator mediator;

        public OwnerController(IMediator mediator)
        {
            this.mediator = mediator;
        }
 
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<Owner>> GetAllOwners()
        {
            return await mediator.Send(new GetAllOwnerQuery());
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Owner> GetOwnerById(int id)
        {
            return await mediator.Send(new GetOwnerByIdQuery(id));
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateOwner([FromForm] CreateOwnerCommand command)
        {
            return Ok(await mediator.Send(command));
        }

        [HttpGet("Owner/{search}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<List<Owner>> Search(string search)
        {
            return await mediator.Send(new GetOwnerByLastOrFirstNameQuery(search));
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<Owner> DeleteOwner(int id)
        {
            return await mediator.Send(new DeleteOwnerQuery(id));
        }

    }
}

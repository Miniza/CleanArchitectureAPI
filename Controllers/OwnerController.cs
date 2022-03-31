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
  
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateOwner([FromForm] CreateOwnerCommand command)
        {
            return Ok(await mediator.Send(command));
        }


    }
}

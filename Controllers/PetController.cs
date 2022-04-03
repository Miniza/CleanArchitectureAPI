using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineVets.Application.Commands;
using OnlineVets.Application.Queries;
using OnlineVets.Application.Responses;

namespace OnlineVets.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IMediator mediator;

        public PetController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAllPets()
        {
            return Ok(await mediator.Send(new GetAllpetQuery()));
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetPetById(int id)
        {
            return Ok(await mediator.Send(new GetpetByIdQuery(id)));
        }

        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<ActionResult<PetResponse>> CreatePet([FromForm] CreatePetCommand command)
        {
            return Ok(await mediator.Send(command));
        }
    }
}

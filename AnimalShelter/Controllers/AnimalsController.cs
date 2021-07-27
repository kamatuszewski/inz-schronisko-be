using AnimalShelter.Application.Animals.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AnimalShelter.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnimalsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AnimalsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{shelterNumber}")]
        public IActionResult GetAnimal(int shelterNumber)
        {
            _mediator.Send(new GetAnimalRequest { ShelterNumber = shelterNumber });
            return Ok();
        }

    }
}

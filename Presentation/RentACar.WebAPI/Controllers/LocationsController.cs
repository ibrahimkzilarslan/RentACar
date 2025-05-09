using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Mediator.Commands.LocationCommands;
using RentACar.Application.Features.Mediator.Queries.LocationQueries;

namespace RentACar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LocationsController : ControllerBase
    {
        private readonly IMediator _mediator;  // Tek tek handler fieldlamak yerine böyle yapıyoruz.

        public LocationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> LocationList()
        {
            // Send metodu ilgili handlera istek yapar.
            var values = await _mediator.Send(new GetLocationQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetLocation(int id)
        {
            var value = await _mediator.Send(new GetLocationByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]

        public async Task<IActionResult> CreateLocation(CreateLocationCommands command)
        {
            await _mediator.Send(command);
            return Ok("Lokasyon eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveLocation(int id)
        {
            await _mediator.Send(new RemoveLocationCommands(id));
            return Ok("Lokasyon başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateLocation(UpdateLocationCommands command)
        {
            await _mediator.Send(command);
            return Ok("Lokasyon başarıyla güncellendi");
        }
    }
}

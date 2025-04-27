using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Mediator.Commands.ServiceCommands;
using RentACar.Application.Features.Mediator.Queries.ServiceQueries;

namespace RentACar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly IMediator _mediator;  // Tek tek handler fieldlamak yerine böyle yapıyoruz.

        public ServicesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> ServiceList()
        {
            // Send metodu ilgili handlera istek yapar.
            var values = await _mediator.Send(new GetServiceQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetService(int id)
        {
            var value = await _mediator.Send(new GetServiceByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]

        public async Task<IActionResult> CreateService(CreateServiceCommands command)
        {
            await _mediator.Send(command);
            return Ok("Servis eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemoveService(int id)
        {
            await _mediator.Send(new RemoveServiceCommands(id));
            return Ok("Servis başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateService(UpdateServiceCommands command)
        {
            await _mediator.Send(command);
            return Ok("Servis başarıyla güncellendi");
        }
    }
}

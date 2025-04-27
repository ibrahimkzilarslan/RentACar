using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Mediator.Commands.PricingCommands;
using RentACar.Application.Features.Mediator.Queries.PricingQueries;

namespace RentACar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PricingsController : ControllerBase
    {
        private readonly IMediator _mediator;  // Tek tek handler fieldlamak yerine böyle yapıyoruz.

        public PricingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> PricingList()
        {
            // Send metodu ilgili handlera istek yapar.
            var values = await _mediator.Send(new GetPricingQuery());
            return Ok(values);
        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetPricing(int id)
        {
            var value = await _mediator.Send(new GetPricingByIdQuery(id));
            return Ok(value);
        }

        [HttpPost]

        public async Task<IActionResult> CreatePricing(CreatePricingCommands command)
        {
            await _mediator.Send(command);
            return Ok("Fiyat eklendi");
        }

        [HttpDelete]
        public async Task<IActionResult> RemovePricing(int id)
        {
            await _mediator.Send(new RemovePricingCommands(id));
            return Ok("Fiyat başarıyla silindi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePricing(UpdatePricingCommands command)
        {
            await _mediator.Send(command);
            return Ok("Fiyat başarıyla güncellendi");
        }
    }
}

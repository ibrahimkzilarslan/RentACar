using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Mediator.Queries.RentCarQueries;

namespace RentACar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RentACarsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public RentACarsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetRentCarListByLocation(int locationID,bool available )
        {
            GetRentCarQuery getRentCarQuery = new GetRentCarQuery
            {
                LocationID = locationID,
                Available = available
            };
            var values = await _mediator.Send(getRentCarQuery);
            return Ok(values);
        }
    }
}

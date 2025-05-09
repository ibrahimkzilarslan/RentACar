using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Mediator.Commands.ReviewCommands;
using RentACar.Application.Features.Mediator.Queries.LocationQueries;
using RentACar.Application.Features.Mediator.Queries.ReviewQueries;
using RentACar.Application.Validators.ReviewValidators;

namespace RentACar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReviewsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> ReviewListByCarId(int id)
        {
            var values = await _mediator.Send(new ReviewQueries(id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateReview(CreateReviewCommand createReviewCommand)
        {
            CreateReviewValidator validator = new CreateReviewValidator();
            var validatonResults = validator.Validate(createReviewCommand);
            if(!validatonResults.IsValid)
            {
                return BadRequest(validatonResults.Errors);
            }

            await _mediator.Send(createReviewCommand);
            return Ok("Ekleme işlemi gerçekleşti");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateReview(UpdateReviewCommand updateReviewCommand)
        {
            await _mediator.Send(updateReviewCommand);
            return Ok("Güncelleme işlemi gerçekleşti");
        }
    }
}

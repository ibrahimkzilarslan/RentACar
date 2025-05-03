﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Mediator.Commands.ReservationCommands;
using RentACar.Application.Features.Mediator.Commands.TestimonialCommands;

namespace RentACar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly IMediator _mediator; 

        public ReservationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]

        public async Task<IActionResult> CreateReservation(CreateReservationCommands command)
        {
            await _mediator.Send(command);
            return Ok("Rezervasyon eklendi");
        }

    }
}

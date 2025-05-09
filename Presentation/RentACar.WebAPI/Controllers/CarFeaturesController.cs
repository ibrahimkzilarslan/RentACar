﻿using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RentACar.Application.Features.Mediator.Commands.CarFeatureCommands;
using RentACar.Application.Features.Mediator.Queries.BlogQueries;
using RentACar.Application.Features.Mediator.Queries.CarFeatureQueries;

namespace RentACar.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarFeaturesController : ControllerBase
    {
        private readonly IMediator _mediator;  

        public CarFeaturesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CarFeatureListByCarId(int id)
        {
            
            var values = await _mediator.Send(new GetCarFeatureByCarIdQuery(id));
            return Ok(values);
        }

        [HttpGet("CarFeatureChangeAvailableToFalse")]
        public async Task<IActionResult> CarFeatureChangeAvailableToFalse(int id)
        {
           _mediator.Send(new UpdateCarFeatureAvailableChangeToFalseCommand(id));
            return Ok("Güncelleme yapıldı");
        }

        [HttpGet("CarFeatureChangeAvailableToTrue")]
        public async Task<IActionResult> CarFeatureChangeAvailableToTrue(int id)
        {
            _mediator.Send(new UpdateCarFeatureAvailableChangeToTrueCommand(id));
            return Ok("Güncelleme yapıldı");
        }
        [HttpPost]
        public async Task<IActionResult> CreateCarFeatureByCarID(CreateCarFeatureByCarCommand command)
        {
            _mediator.Send(command);
            return Ok("Özellik eklendi");
        }
    }
}

﻿using MediatR;
using RentACar.Application.Features.CQRS.Commands.AboutCommands;
using RentACar.Application.Features.Mediator.Commands.ReservationCommands;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.ReservationHandler
{
    public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommands>
    {
        private readonly IRepository<Reservation> _repository;

        public CreateReservationCommandHandler(IRepository<Reservation> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateReservationCommands request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Reservation
            {
                Age = request.Age,
                Name = request.Name,
                CarID = request.CarID,
                DriverLicenseYear = request.DriverLicenseYear,
                DropOffLocationID = request.DropOffLocationID,
                Email = request.Email,
                Phone = request.Phone,
                PickUpLocationID = request.PickUpLocationID,
                Surname = request.Surname,
                Description = request.Description,
                Status = "Rezervasyon Alındı"
            });

        }
    }
}

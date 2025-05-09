﻿using MediatR;
using RentACar.Application.Features.Mediator.Commands.TestimonialCommands;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.TestimonialHandler
{
    public class UpdateTestimonialCommandHandler : IRequestHandler<UpdateTestimonialCommands>
    {
        private readonly IRepository<Testimonial> _repository;

        public UpdateTestimonialCommandHandler(IRepository<Testimonial> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTestimonialCommands request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.TestimonialID);
            values.TestimonialID = request.TestimonialID;
            values.Name = request.Name;
            values.Title = request.Title;
            values.ImageUrl = request.ImageUrl;
            values.Comment = request.Comment;
            await _repository.UpdateAsync(values);

        }
    }
}

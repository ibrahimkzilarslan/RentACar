﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Commands.TestimonialCommands
{
    public class RemoveTestimonialCommands : IRequest
    {
        public int Id { get; set; }

        public RemoveTestimonialCommands(int id)
        {
            Id = id;
        }
    }
}

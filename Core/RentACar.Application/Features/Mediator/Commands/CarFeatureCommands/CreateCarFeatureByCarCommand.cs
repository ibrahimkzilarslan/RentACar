﻿using MediatR;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Commands.CarFeatureCommands
{
    public class CreateCarFeatureByCarCommand : IRequest
    {
        public int CarID { get; set; }
        public int FeaturesID { get; set; }
        public bool Available { get; set; }
    }
}

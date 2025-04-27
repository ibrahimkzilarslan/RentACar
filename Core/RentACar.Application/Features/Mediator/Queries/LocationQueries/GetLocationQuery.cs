﻿using MediatR;
using RentACar.Application.Features.Mediator.Results.LocationResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Queries.LocationQueries
{
    public class GetLocationQuery : IRequest<List<GetLocationQueryResults>>
    {
        public int LocationID { get; set; }
        public string Name { get; set; }
    }
}

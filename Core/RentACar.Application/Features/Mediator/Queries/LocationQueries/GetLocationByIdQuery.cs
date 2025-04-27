using MediatR;
using RentACar.Application.Features.Mediator.Results.LocationResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Queries.LocationQueries
{
    public class GetLocationByIdQuery : IRequest<GetLocationByIdQueryResults>
    {
        public int Id { get; set; }

        public GetLocationByIdQuery(int ıd)
        {
            Id = ıd;
        }
    }
}

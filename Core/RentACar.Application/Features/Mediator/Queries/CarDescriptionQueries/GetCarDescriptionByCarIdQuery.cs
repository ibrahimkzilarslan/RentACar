using MediatR;
using RentACar.Application.Features.Mediator.Results.CarDescriptionResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Queries.CarDescriptionQueries
{
    public class GetCarDescriptionByCarIdQuery : IRequest<GetCarDescriptionQueryResults>
    {
        public int Id { get; set; }

        public GetCarDescriptionByCarIdQuery(int id)
        {
            Id = id;
        }
    }
}

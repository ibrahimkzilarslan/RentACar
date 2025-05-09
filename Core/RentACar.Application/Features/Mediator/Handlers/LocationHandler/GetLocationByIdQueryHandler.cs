using MediatR;
using RentACar.Application.Features.Mediator.Queries.LocationQueries;
using RentACar.Application.Features.Mediator.Results.FeatureResults;
using RentACar.Application.Features.Mediator.Results.LocationResults;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.LocationHandler
{
    public class GetLocationByIdQueryHandler : IRequestHandler<GetLocationByIdQuery, GetLocationByIdQueryResults>
    {

        private readonly IRepository<Location> _repository;

        public GetLocationByIdQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<GetLocationByIdQueryResults> Handle(GetLocationByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetLocationByIdQueryResults
            {
                LocationID = values.LocationID,
                Name = values.Name,
            };
        }
    }
}

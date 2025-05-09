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
    public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, List<GetLocationQueryResults>>
    {

        private readonly IRepository<Location> _repository;

        public GetLocationQueryHandler(IRepository<Location> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetLocationQueryResults>> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetLocationQueryResults
            {
               LocationID = x.LocationID,
               Name = x.Name,
            }).ToList();

        }
    }
}

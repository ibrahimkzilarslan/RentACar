using MediatR;
using RentACar.Application.Features.Mediator.Queries.PricingQueries;
using RentACar.Application.Features.Mediator.Results.LocationResults;
using RentACar.Application.Features.Mediator.Results.PricingResults;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.PricingHandler
{
    public class GetPricingQueryHandler : IRequestHandler<GetPricingQuery, List<GetPricingQueryResults>>
    {

        private readonly IRepository<Pricing> _repository;
        public GetPricingQueryHandler(IRepository<Pricing> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetPricingQueryResults>> Handle(GetPricingQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetPricingQueryResults
            {
                PricingID = x.PricingID,
                Name = x.Name,
            }).ToList();

        }
    }
}

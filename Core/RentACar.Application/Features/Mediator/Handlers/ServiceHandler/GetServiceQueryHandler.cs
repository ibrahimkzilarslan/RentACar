using MediatR;
using RentACar.Application.Features.Mediator.Queries.ServiceQueries;
using RentACar.Application.Features.Mediator.Results.PricingResults;
using RentACar.Application.Features.Mediator.Results.ServiceResults;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.ServiceHandler
{
    public class GetServiceQueryHandler : IRequestHandler<GetServiceQuery, List<GetServiceQueryResults>>
    {

        private readonly IRepository<Service> _repository;

        public GetServiceQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetServiceQueryResults>> Handle(GetServiceQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetServiceQueryResults
            {
                ServiceID = x.ServiceID,
                Description = x.Description,
                Title = x.Title,
                IconUrl = x.IconUrl,
            }).ToList();
        }
    }
}

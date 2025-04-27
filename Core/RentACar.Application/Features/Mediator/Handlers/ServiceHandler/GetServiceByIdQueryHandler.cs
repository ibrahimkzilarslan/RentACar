using MediatR;
using RentACar.Application.Features.CQRS.Results.AboutResults;
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
    public class GetServiceByIdQueryHandler : IRequestHandler<GetServiceByIdQuery, GetServiceByIdQueryResults>
    {
        private readonly IRepository<Service> _repository;

        public GetServiceByIdQueryHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task<GetServiceByIdQueryResults> Handle(GetServiceByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetServiceByIdQueryResults
            {
               ServiceID = values.ServiceID,
               Title = values.Title,
               Description = values.Description,
               IconUrl = values.IconUrl,
            };
        }
    }
}

using MediatR;
using RentACar.Application.Features.CQRS.Results.AboutResults;
using RentACar.Application.Features.CQRS.Results.BrandResults;
using RentACar.Application.Features.Mediator.Queries.FeatureQueries;
using RentACar.Application.Features.Mediator.Results.FeatureResults;
using RentACar.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class GetFeatureByIdQueryHandler : IRequestHandler<GetFeatureByIdQuery, GetFeatureByIdQueryResults>
    {
        private readonly IRepository<Domain.Entities.Features> _repository;

        public GetFeatureByIdQueryHandler(IRepository<Domain.Entities.Features> repository)
        {
            _repository = repository;
        }

        public async Task<GetFeatureByIdQueryResults> Handle(GetFeatureByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetFeatureByIdQueryResults
            {
                FeaturesID = values.FeaturesID,
                Name = values.Name,
            };
        }
    }
}

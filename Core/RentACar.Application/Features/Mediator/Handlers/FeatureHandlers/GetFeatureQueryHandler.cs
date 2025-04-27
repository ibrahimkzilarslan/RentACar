using MediatR;
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
    public class GetFeatureQueryHandler : IRequestHandler<GetFeatureQuery /* İstek buradan yapılacak*/ , /*Yanıt buradan list olarak dönecek */ List<GetFeatureQueryResults>>
    {

        private readonly IRepository<Domain.Entitites.Features> _repository;

        public GetFeatureQueryHandler(IRepository<Domain.Entitites.Features> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFeatureQueryResults>> Handle(GetFeatureQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetFeatureQueryResults
            {
                FeaturesID = x.FeaturesID,
                Name = x.Name,
            }).ToList();
        }
    }
}

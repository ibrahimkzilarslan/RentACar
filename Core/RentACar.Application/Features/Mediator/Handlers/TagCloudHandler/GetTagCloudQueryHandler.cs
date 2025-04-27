using MediatR;
using RentACar.Application.Features.Mediator.Queries.ServiceQueries;
using RentACar.Application.Features.Mediator.Queries.TagCloudQueries;
using RentACar.Application.Features.Mediator.Results.ServiceResults;
using RentACar.Application.Features.Mediator.Results.TagCloudResults;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.TagCloudHandler
{
    public class GetTagCloudQueryHandler : IRequestHandler<GetTagCloudQuery,List<GetTagCloudQueryResults>>
    {
        private readonly IRepository<TagCloud> _repository;

        public GetTagCloudQueryHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTagCloudQueryResults>> Handle(GetTagCloudQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetTagCloudQueryResults
            {
                TagCloudID = x.TagCloudID,
                Title = x.Title,
                BlogID = x.BlogID,
               
            }).ToList();
        }
    }
}

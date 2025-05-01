using MediatR;
using RentACar.Application.Features.Mediator.Queries.StatisticsQueries;
using RentACar.Application.Features.Mediator.Results.StatisticsResults;
using RentACar.Application.Interfaces.StatisticsInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.StatisticsHandler
{
    public class GetBlogCountQueryHandler : IRequestHandler<GetBlogCountQuery, GetBlogCountQueryResults>
    {
        private readonly IStatisticsRepository _repository;

        public GetBlogCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogCountQueryResults> Handle(GetBlogCountQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetBlogCount();
            return new GetBlogCountQueryResults
            {
                BlogCount = value,
            };
        }
    }
}

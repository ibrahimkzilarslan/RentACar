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
    public class GetAuthorCountQueryHandler : IRequestHandler<GetAuthorCountQuery, GetAuthorCountQueryResults>
    {
        private readonly IStatisticsRepository _repository;

        public GetAuthorCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAuthorCountQueryResults> Handle(GetAuthorCountQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetAuthorCount();
            return new GetAuthorCountQueryResults
            {
                AuthorCount = value,
            };
        }
    }
}

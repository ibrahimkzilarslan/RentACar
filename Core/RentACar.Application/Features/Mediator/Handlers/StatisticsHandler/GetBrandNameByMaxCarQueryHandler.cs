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
    public class GetBrandNameByMaxCarQueryHandler : IRequestHandler<GetBrandNameByMaxCarQuery,GetBrandNameByMaxCarQueryResults>
    {
        private readonly IStatisticsRepository _repository;

        public GetBrandNameByMaxCarQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBrandNameByMaxCarQueryResults> Handle(GetBrandNameByMaxCarQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetBrandNameByMaxCar();
            return new GetBrandNameByMaxCarQueryResults
            {
                BrandNameByMaxCar = value
            };
        }
    }
}

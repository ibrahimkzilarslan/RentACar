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
    public class GetCarCountByFuelElectricQueryHandler : IRequestHandler<GetCarCountByFuelElectricQuery, GetCarCountByFuelElectricQueryResults>
    {

        private readonly IStatisticsRepository _repository;

        public GetCarCountByFuelElectricQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByFuelElectricQueryResults> Handle(GetCarCountByFuelElectricQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByFuelElectric();
            return new GetCarCountByFuelElectricQueryResults
            {

                CarCountByFuelElectric = value

            };
        }
    }
}

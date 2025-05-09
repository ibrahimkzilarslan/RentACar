using MediatR;
using RentACar.Application.Features.Mediator.Queries.StatisticsQueries;
using RentACar.Application.Features.Mediator.Results.FooterAddressResults;
using RentACar.Application.Features.Mediator.Results.StatisticsResults;
using RentACar.Application.Interfaces;
using RentACar.Application.Interfaces.CarInterfaces;
using RentACar.Application.Interfaces.StatisticsInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.StatisticsHandler
{
    public class GetCarCountQueryHandler : IRequestHandler<GetCarCountQuery, GetCarCountQueryResults>
    {

        private readonly IStatisticsRepository _repository;

        public GetCarCountQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountQueryResults> Handle(GetCarCountQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCount();
            return new GetCarCountQueryResults
            {
                CarCount = value,

            };
        }
    }
}

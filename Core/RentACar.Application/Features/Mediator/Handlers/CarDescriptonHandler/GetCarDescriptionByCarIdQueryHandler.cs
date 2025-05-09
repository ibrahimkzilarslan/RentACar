using MediatR;
using RentACar.Application.Features.Mediator.Queries.CarDescriptionQueries;
using RentACar.Application.Features.Mediator.Results.CarDescriptionResults;
using RentACar.Application.Interfaces;
using RentACar.Application.Interfaces.CarDescriptionInterfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.CarDescriptonHandler
{
    public class GetCarDescriptionByCarIdQueryHandler : IRequestHandler<GetCarDescriptionByCarIdQuery, GetCarDescriptionQueryResults>
    {
        private readonly ICarDescriptionRepository _carDescriptionRepository;

        public GetCarDescriptionByCarIdQueryHandler(ICarDescriptionRepository carDescriptionRepository)
        {
            _carDescriptionRepository = carDescriptionRepository;
        }

        public async Task<GetCarDescriptionQueryResults> Handle(GetCarDescriptionByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = _carDescriptionRepository.GetCarDescription(request.Id);
            return new GetCarDescriptionQueryResults
            {
                CarID = values.CarID,
                CarDescriptionID = values.CarDescriptionID,
                Details = values.Details,
            };
        }
    }
}

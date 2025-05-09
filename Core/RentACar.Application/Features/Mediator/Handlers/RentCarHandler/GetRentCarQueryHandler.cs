using MediatR;
using RentACar.Application.Features.Mediator.Queries.PricingQueries;
using RentACar.Application.Features.Mediator.Queries.RentCarQueries;
using RentACar.Application.Features.Mediator.Results.PricingResults;
using RentACar.Application.Features.Mediator.Results.RentCarResults;
using RentACar.Application.Interfaces;
using RentACar.Application.Interfaces.RentCarInterfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.RentCarHandler
{
    public class GetRentCarQueryHandler : IRequestHandler<GetRentCarQuery, List<GetRentCarQueryResults>>
    {
        private readonly IRentCarRepository _repository;


        public GetRentCarQueryHandler(IRentCarRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetRentCarQueryResults>> Handle(GetRentCarQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByFilterAsync(x => x.LocationID == request.LocationID && x.Available == true);
            var results =  values.Select(x => new GetRentCarQueryResults
            {
                CarID = x.CarID,
                Brand = x.Car.Brand.Name,              
                Model = x.Car.Model,
                CoverImageUrl = x.Car.CoverImageUrl,
            }).ToList();
            return results;
        }
    }
}
﻿using MediatR;
using RentACar.Application.Features.Mediator.Queries.CarPricingQueries;
using RentACar.Application.Features.Mediator.Results.CarPricingResults;
using RentACar.Application.Interfaces.CarPricingInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.CarPricingHandler
{
    public class GetCarPricingWithCarQueryHandler : IRequestHandler<GetCarPricingWithCarQuery,List<GetCarPricingWithCarQueryResults>>
    {
        private readonly ICarPricingRepository _carPricingRepository;

        public GetCarPricingWithCarQueryHandler(ICarPricingRepository carPricingRepository)
        {
            _carPricingRepository = carPricingRepository;
        }

        public async Task<List<GetCarPricingWithCarQueryResults>> Handle(GetCarPricingWithCarQuery request, CancellationToken cancellationToken)
        {

            var values = _carPricingRepository.GetCarsPricingsWithCars();
            return values.Select(x => new GetCarPricingWithCarQueryResults
            {
                Amount = x.Amount,
                Brand = x.Car.Brand.Name,
                CarPricingID = x.CarPricingID,
                CoverImageUrl = x.Car.CoverImageUrl,
                Model = x.Car.Model,
                CarID = x.CarID
            }).ToList();
        }

    }
}

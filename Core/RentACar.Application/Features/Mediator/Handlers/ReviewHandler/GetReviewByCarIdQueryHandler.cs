﻿using MediatR;
using RentACar.Application.Features.Mediator.Queries.ReviewQueries;
using RentACar.Application.Features.Mediator.Results.PricingResults;
using RentACar.Application.Features.Mediator.Results.ReviewResults;
using RentACar.Application.Interfaces.ReviewInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.ReviewHandler
{
    public class GetReviewByCarIdQueryHandler : IRequestHandler<ReviewQueries, List<GetReviewByCarIdQueryResults>>
    {
        private readonly IReviewRepository _repository;

        public GetReviewByCarIdQueryHandler(IReviewRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetReviewByCarIdQueryResults>> Handle(ReviewQueries request, CancellationToken cancellationToken)
        {
            var values = _repository.GetReviewsByCarId(request.Id);
            return values.Select(x => new GetReviewByCarIdQueryResults
            {
                CarID = x.CarID,
                Comment = x.Comment,
                CustomerImage = x.CustomerImage,
                CustomerName = x.CustomerName,
                RatingValue = x.RatingValue,
                ReviewDate = x.ReviewDate,
                ReviewID = x.ReviewID
            }).ToList();
        }
    }
}

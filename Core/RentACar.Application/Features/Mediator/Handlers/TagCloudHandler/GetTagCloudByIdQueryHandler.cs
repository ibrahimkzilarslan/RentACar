﻿using MediatR;
using RentACar.Application.Features.CQRS.Results.AboutResults;
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
    public class GetTagCloudByIdQueryHandler : IRequestHandler<GetTagCloudByIdQuery,GetTagCloudByIdQueryResults>
    {
        private readonly IRepository<TagCloud> _repository;

        public GetTagCloudByIdQueryHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task<GetTagCloudByIdQueryResults> Handle(GetTagCloudByIdQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.Id);
            return new GetTagCloudByIdQueryResults
            {
                TagCloudID = values.TagCloudID,
                Title = values.Title,
                BlogID = values.BlogID,

            };
        }
    }
}

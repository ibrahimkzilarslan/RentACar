﻿using MediatR;
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
    public class GetBlogTitleByMaxBlogCommentQueryHandler : IRequestHandler<GetBlogTitleByMaxBlogCommentQuery, GetBlogTitleByMaxBlogCommentQueryResults>
    {
        private readonly IStatisticsRepository _repository;

        public GetBlogTitleByMaxBlogCommentQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetBlogTitleByMaxBlogCommentQueryResults> Handle(GetBlogTitleByMaxBlogCommentQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetBlogTitleByMaxBlogComment();
            return new GetBlogTitleByMaxBlogCommentQueryResults
            {
                BlogTitleByMaxComment = value,
            };
        }
    }
}

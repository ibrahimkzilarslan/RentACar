﻿using RentACar.Application.Features.CQRS.Queries.AboutQueries;
using RentACar.Application.Features.CQRS.Results.AboutResults;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.AboutHandlers
{
    public class GetAboutByIdQueryHandler
    {
        private readonly IRepository<About> _repository;

        public GetAboutByIdQueryHandler(IRepository<About> repository)
        {
            _repository = repository;
        }

        public async Task<GetAboutByIdQueryResults> Handle(GetAboutByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetAboutByIdQueryResults
            {
                AboutID = values.AboutID,
                Description = values.Description,
                Title = values.Title,
                ImageUrl = values.ImageUrl,
            };
        }
    }
}

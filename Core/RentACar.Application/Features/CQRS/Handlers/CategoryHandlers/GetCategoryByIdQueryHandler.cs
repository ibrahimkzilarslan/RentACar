﻿using RentACar.Application.Features.CQRS.Queries.CategoryQueries;
using RentACar.Application.Features.CQRS.Results.CategoryResults;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.CategoryHandlers
{
    public class GetCategoryByIdQueryHandler
    {
        private readonly IRepository<Category> _repository;

        public GetCategoryByIdQueryHandler(IRepository<Category> repository)
        {
            _repository = repository;
        }

        public async Task<GetCategoryByIdQueryResults> Handle(GetCategoryByIdQuery results)
        {
            var values = await _repository.GetByIdAsync(results.Id);
            return new GetCategoryByIdQueryResults
            {
                CategoryID = values.CategoryID,
                Name = values.Name,
            };
        }
    }
}

using MediatR;
using RentACar.Application.Features.Mediator.Queries.AuthorQueries;
using RentACar.Application.Features.Mediator.Results.AuthorResults;
using RentACar.Application.Features.Mediator.Results.FeatureResults;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.AuthorHandler
{
    public class GetAuthorQueryHandler : IRequestHandler<GetAuthorQuery, List<GetAuthorQueryResults>>
    {
        private readonly IRepository<Author> _repository;

        public GetAuthorQueryHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetAuthorQueryResults>> Handle(GetAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetAuthorQueryResults
            {
                AuthorID = x.AuthorID,
                Name = x.Name,
                ImageUrl = x.ImageUrl,
                Description = x.Description
            }).ToList();
        }
    }
 }

using MediatR;
using RentACar.Application.Features.Mediator.Queries.BlogQueries;
using RentACar.Application.Features.Mediator.Results.BlogResults;
using RentACar.Application.Interfaces.BlogInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.BlogHandler
{
    public class GetAllBlogsWithAuthorQueryHandler : IRequestHandler<GetAllBlogsWithAuthorQuery,List<GetAllBlogsWithAuthorQueryResults>>
    {

        private readonly IBlogRepository _repository;

        public GetAllBlogsWithAuthorQueryHandler(IBlogRepository repository)
        {
            _repository = repository;
        }
        public async Task<List<GetAllBlogsWithAuthorQueryResults>> Handle(GetAllBlogsWithAuthorQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetAllBlogsWithAuthors();
            return values.Select(x => new GetAllBlogsWithAuthorQueryResults
            {
                BlogID = x.BlogID,
                AuthorID = x.AuthorID,
                CategoryID = x.CategoryID,
                CoverImageUrl = x.CoverImageUrl,
                CreatedDate = x.CreatedDate,
                AuthorDescription = x.Author.Description,
                AuthorImageUrl  =x.Author.ImageUrl,
                Title = x.Title,
                AuthorName = x.Author.Name,
                Description = x.Description
            }).ToList();
        }
    }
}

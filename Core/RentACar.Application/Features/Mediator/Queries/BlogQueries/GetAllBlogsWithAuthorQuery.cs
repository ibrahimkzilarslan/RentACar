using MediatR;
using RentACar.Application.Features.Mediator.Results.BlogResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Queries.BlogQueries
{
    public class GetAllBlogsWithAuthorQuery : IRequest<List<GetAllBlogsWithAuthorQueryResults>>
    {
        public int BlogID { get; set; }
        public string Title { get; set; }
        public string AuthorName { get; set; }
        public string? CategoryName { get; set; }
        public int AuthorID { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CategoryID { get; set; }

        public string Description { get; set; }

    }
}

using MediatR;
using RentACar.Application.Features.Mediator.Results.TagCloudResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Queries.TagCloudQueries
{
    public class GetTagCloudQuery : IRequest<List<GetTagCloudQueryResults>>
    {
        public int TagCloudID { get; set; }
        public string Title { get; set; }
        public int BlogID { get; set; }

    }
}

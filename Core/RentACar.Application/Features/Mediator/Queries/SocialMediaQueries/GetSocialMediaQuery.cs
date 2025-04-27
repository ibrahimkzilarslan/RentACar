using MediatR;
using RentACar.Application.Features.Mediator.Results.SocialMediaResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Queries.SocialMediaQueries
{
    public class GetSocialMediaQuery : IRequest<List<GetSocialMediaQueryResults>>
    {
        public int SocialMediaID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
    }
}

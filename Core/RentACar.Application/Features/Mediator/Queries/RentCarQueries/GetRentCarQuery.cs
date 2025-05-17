using MediatR;
using RentACar.Application.Features.Mediator.Results.RentCarResults;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Queries.RentCarQueries
{
    public class GetRentCarQuery : IRequest<List<GetRentCarQueryResults>>
    {
        public int LocationID { get; set; }
        public bool Available { get; set; }







    }
}

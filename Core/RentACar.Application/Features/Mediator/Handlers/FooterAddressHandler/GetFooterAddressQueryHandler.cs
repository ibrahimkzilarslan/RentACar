using MediatR;
using RentACar.Application.Features.Mediator.Queries.FooterAddressQueries;
using RentACar.Application.Features.Mediator.Results.FeatureResults;
using RentACar.Application.Features.Mediator.Results.FooterAddressResults;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.FooterAddressHandler
{
    public class GetFooterAddressQueryHandler : IRequestHandler<GetFooterAddressQuery, List<GetFooterAddressQueryResults>>
    {

        private readonly IRepository<FooterAddress> _repository;

        public GetFooterAddressQueryHandler(IRepository<FooterAddress> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetFooterAddressQueryResults>> Handle(GetFooterAddressQuery request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetFooterAddressQueryResults
            {
                FooterAddressID = x.FooterAddressID,
                Phone = x.Phone,
                Email = x.Email,
                Description = x.Description,
                Address = x.Address,
            }).ToList();
        }

    }
}

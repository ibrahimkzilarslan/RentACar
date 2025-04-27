using MediatR;
using RentACar.Application.Features.Mediator.Commands.FeatureCommands;
using RentACar.Application.Interfaces;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.FeatureHandlers
{
    public class CreateFeatureCommandHandler : IRequestHandler<CreateFeatureCommand>
    {

        private readonly IRepository<Domain.Entitites.Features> _repository;

        public CreateFeatureCommandHandler(IRepository<Domain.Entitites.Features> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateFeatureCommand request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new Domain.Entitites.Features
            {
               Name = request.Name,
            });
        }

    }
}

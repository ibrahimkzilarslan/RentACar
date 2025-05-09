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
    public class UpdateFeatureCommandHandler : IRequestHandler<UpdateFeatureCommand>
    {

        private readonly IRepository<Domain.Entities.Features> _repository;

        public UpdateFeatureCommandHandler(IRepository<Domain.Entities.Features> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateFeatureCommand request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.FeaturesID);
            values.Name = request.Name;
            await _repository.UpdateAsync(values);
        }
    }
}

using MediatR;
using RentACar.Application.Features.Mediator.Commands.CarFeatureCommands;
using RentACar.Application.Interfaces.CarFeatureInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.CarFeatureHandler
{
    public class UpdateCarFeatureAvailableChangeToTrueCommandHandler : IRequestHandler<UpdateCarFeatureAvailableChangeToTrueCommand>
    {
        private readonly ICarFeatureRepository _repository;

        public UpdateCarFeatureAvailableChangeToTrueCommandHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }

        public Task Handle(UpdateCarFeatureAvailableChangeToTrueCommand request, CancellationToken cancellationToken)
        {
            _repository.ChangeCarFeatureAvailableToTrue(request.Id);
            return Task.CompletedTask;
        }
    }
}

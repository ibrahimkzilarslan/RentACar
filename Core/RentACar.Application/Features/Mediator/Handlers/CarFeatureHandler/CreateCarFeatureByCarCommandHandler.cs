using MediatR;
using RentACar.Application.Features.Mediator.Commands.CarFeatureCommands;
using RentACar.Application.Interfaces.CarFeatureInterfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.CarFeatureHandler
{
    public class CreateCarFeatureByCarCommandHandler : IRequestHandler<CreateCarFeatureByCarCommand>
    {
        private readonly ICarFeatureRepository _repository;

        public CreateCarFeatureByCarCommandHandler(ICarFeatureRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateCarFeatureByCarCommand request, CancellationToken cancellationToken)
        {
            _repository.CreateCarFeatureByCar(new CarFeatures
            {
               Available = false,
               CarID = request.CarID,
               FeaturesID = request.FeaturesID,
            });
        }
    }
}

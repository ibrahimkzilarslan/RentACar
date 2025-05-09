using MediatR;
using RentACar.Application.Features.Mediator.Commands.SocialMediaCommands;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.SocialMediaHandler
{
    public class CreateSocialMediaCommandHandler : IRequestHandler<CreateSocialMediaCommands>
    {

        private readonly IRepository<SocialMedia> _repository;

        public CreateSocialMediaCommandHandler(IRepository<SocialMedia> repository)
        {
            _repository = repository;
        }

        public async Task Handle(CreateSocialMediaCommands request, CancellationToken cancellationToken)
        {
            await _repository.CreateAsync(new SocialMedia
            {
               Name = request.Name,
               Url  = request.Url,
               Icon = request.Icon,
            });
        }
    }
}

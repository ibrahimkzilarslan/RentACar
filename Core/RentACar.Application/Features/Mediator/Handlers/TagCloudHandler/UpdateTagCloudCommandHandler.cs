﻿using MediatR;
using RentACar.Application.Features.Mediator.Commands.ServiceCommands;
using RentACar.Application.Features.Mediator.Commands.TagCloudCommands;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.TagCloudHandler
{
    public class UpdateTagCloudCommandHandler : IRequestHandler<UpdateTagCloudCommands>
    {
        private readonly IRepository<TagCloud> _repository;

        public UpdateTagCloudCommandHandler(IRepository<TagCloud> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateTagCloudCommands request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.TagCloudID);
            values.Title = request.Title;
            values.TagCloudID = request.TagCloudID;
            values.BlogID = request.BlogID;
            await _repository.UpdateAsync(values);
        }
    }
}

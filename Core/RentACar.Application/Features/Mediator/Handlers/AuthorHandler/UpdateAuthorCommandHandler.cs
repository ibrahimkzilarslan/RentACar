﻿using MediatR;
using RentACar.Application.Features.Mediator.Commands.AuthorCommands;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.AuthorHandler
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommands>
    {
        private readonly IRepository<Author> _repository;

        public UpdateAuthorCommandHandler(IRepository<Author> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateAuthorCommands request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.AuthorID);
            values.Name = request.Name;
            values.ImageUrl = request.ImageUrl;
            values.Description = request.Description;
            values.AuthorID = request.AuthorID;
            await _repository.UpdateAsync(values);
        }
    }
}

using MediatR;
using RentACar.Application.Features.Mediator.Commands.ServiceCommands;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.ServiceHandler
{
    public class UpdateServiceCommandHandler : IRequestHandler<UpdateServiceCommands>
    {
        private readonly IRepository<Service> _repository;

        public UpdateServiceCommandHandler(IRepository<Service> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateServiceCommands request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.ServiceID);
            values.Title = request.Title;
            values.ServiceID = request.ServiceID;
            values.Description = request.Description;
            values.IconUrl = request.IconUrl;
            await _repository.UpdateAsync(values);
        }
    }
}

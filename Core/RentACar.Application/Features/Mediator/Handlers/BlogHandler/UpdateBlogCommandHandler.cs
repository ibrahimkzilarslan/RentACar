using MediatR;
using RentACar.Application.Features.Mediator.Commands.BlogCommands;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.Mediator.Handlers.BlogHandler
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommands>
    {
        private readonly IRepository<Blog> _repository;

        public UpdateBlogCommandHandler(IRepository<Blog> repository)
        {
            _repository = repository;
        }

        public async Task Handle(UpdateBlogCommands request, CancellationToken cancellationToken)
        {
            var values = await _repository.GetByIdAsync(request.BlogID);
            values.AuthorID = request.AuthorID;
            values.CategoryID = request.CategoryID;
            values.CoverImageUrl = request.CoverImageUrl;
            values.CreatedDate = request.CreatedDate;
            values.Title = request.Title;
            await _repository.UpdateAsync(values);
        }
    }
}

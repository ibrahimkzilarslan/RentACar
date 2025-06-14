﻿using RentACar.Application.Features.CQRS.Results.ContactResults;
using RentACar.Application.Interfaces;
using RentACar.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Application.Features.CQRS.Handlers.ContactHandlers
{
    public class GetContactQueryHandler
    {
        private readonly IRepository<Contact> _repository;

        public GetContactQueryHandler(IRepository<Contact> repository)
        {
            _repository = repository;
        }

        public async Task<List<GetContactQueryResults>> Handle()
        {
            var values = await _repository.GetAllAsync();
            return values.Select(x => new GetContactQueryResults
            {
                Name = x.Name,
                ContactID = x.ContactID,
                Email = x.Email,
                Subject = x.Subject,
                Message = x.Message,
                SendDate = x.SendDate,
            }).ToList();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using RentACar.Application.Interfaces.RentCarInterfaces;
using RentACar.Domain.Entities;
using RentACar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repositories.RentCarRepositories
{
    public class RentCarRepository : IRentCarRepository
    {

        private readonly RentACarContext _context;

        public RentCarRepository(RentACarContext context)
        {
            _context = context;
        }

        public async Task<List<RentCar>> GetByFilterAsync(Expression<Func<RentCar, bool>> filter)
        {
            var values = await _context.RentCars.Where(filter).Include(x=>x.Car).ThenInclude(y => y.Brand).ToListAsync();
            return values;
        }
    }
}

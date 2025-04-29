using Microsoft.EntityFrameworkCore;
using RentACar.Application.Interfaces.CarInterfaces;
using RentACar.Domain.Entitites;
using RentACar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repositories.CarRepositories
{
    public class CarRepository : ICarRepository
    {

        private readonly RentACarContext _context;

        public CarRepository(RentACarContext context)
        {
            _context = context;
        }

        public int GetCarCount()
        {
            var values = _context.Cars.Count();
            return values;
        }

        public List<Car> GetCarsListWithBrands()
        {
            var values = _context.Cars.Include(x => x.Brand).ToList();
            return values;
        }

        public List<Car> GetLast5CarsWithBrands()
        {
            var values = _context.Cars.Include(x => x.Brand).OrderByDescending(x => x.CarID).Take(5).ToList();
            return values;
        }
    }
}

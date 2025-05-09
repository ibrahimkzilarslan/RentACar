using RentACar.Application.Interfaces.CarDescriptionInterfaces;
using RentACar.Domain.Entities;
using RentACar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repositories.CarDescriptionRepositories
{
    public class CarDescriptionRepository : ICarDescriptionRepository
    {
        private readonly RentACarContext _context;

        public CarDescriptionRepository(RentACarContext context)
        {
            _context = context;
        }

        public CarDescription GetCarDescription(int carId)
        {
            var values = _context.CarDescriptions.Where(x => x.CarID == carId).FirstOrDefault();
            return values;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using RentACar.Application.Interfaces.CarFeatureInterfaces;
using RentACar.Domain.Entities;
using RentACar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repositories.CarFeatureRepositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly RentACarContext _context;

        public CarFeatureRepository(RentACarContext context)
        {
            _context = context;
        }

        public void ChangeCarFeatureAvailableToFalse(int carId)
        {
            var values = _context.CarFeatures.Where(x => x.CarFeaturesID == carId).FirstOrDefault();
            values.Available = false;
            _context.SaveChanges();
        }

        public void ChangeCarFeatureAvailableToTrue(int carId)
        {
            var values = _context.CarFeatures.Where(x => x.CarFeaturesID == carId).FirstOrDefault();
            values.Available = true;
            _context.SaveChanges();
        }

        public void CreateCarFeatureByCar(CarFeatures carFeatures)
        {
            _context.CarFeatures.Add(carFeatures);
            _context.SaveChanges();
        }

        public List<CarFeatures> GetCarFeaturesByCarId(int carId)
        {
            var values = _context.CarFeatures.Include(y=>y.Features).Where(x=>x.CarID == carId).ToList();
            return values;
        }
    }
}

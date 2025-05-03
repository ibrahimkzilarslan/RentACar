using Microsoft.EntityFrameworkCore;
using RentACar.Application.Interfaces.CarPricingInterfaces;
using RentACar.Application.ViewModels;
using RentACar.Domain.Entities;
using RentACar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly RentACarContext _context;

        public CarPricingRepository(RentACarContext context)
        {
            _context = context;
        }

        public List<CarPricingViewModel> GetCarsPricingWithTimePeriod1()
        {
            List<CarPricingViewModel> values = new List<CarPricingViewModel>();
            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = "Select * From (Select Model,PricingID,Amount From CarPricings Inner Join Cars On Cars.CarID=CarPricings.CarId Inner Join Brands On Brands.BrandID=Cars.BrandID) As SourceTable Pivot (Sum(Amount) For PricingID In ([2],[3],[4])) as PivotTable;";
                command.CommandType = System.Data.CommandType.Text;
                _context.Database.OpenConnection();
                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        CarPricingViewModel carPricingViewModel = new CarPricingViewModel();
                        Enumerable.Range(1, 3).ToList().ForEach(x =>
                        {
                            carPricingViewModel.Model = reader[0].ToString();    
                            if (DBNull.Value.Equals(reader[x]))
                            {
                                carPricingViewModel.Amounts.Add(0);
                            }
                            else
                            {
                                carPricingViewModel.Amounts.Add(reader.GetDecimal(x));
                            }
                        });                    
                        values.Add(carPricingViewModel);
                    }
                } 
                _context.Database.CloseConnection();
                return values;
            }
        }        
        public List<CarPricing> GetCarsPricingsWithCars()
        {
            var values = _context.CarPricings.Include(x => x.Car).ThenInclude(y => y.Brand).Include(x => x.Pricing).Where(z => z.PricingID == 2).ToList();
            return values;
        }

        public List<CarPricing> GetCarsPricingsWithTimePeriod()
        {
            throw new NotImplementedException();
        }
    }
}



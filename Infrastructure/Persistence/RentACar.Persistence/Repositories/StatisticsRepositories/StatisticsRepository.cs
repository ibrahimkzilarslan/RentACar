﻿using Microsoft.EntityFrameworkCore;
using RentACar.Application.Interfaces.StatisticsInterfaces;
using RentACar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {

        private readonly RentACarContext _context;

        public StatisticsRepository(RentACarContext context)
        {
            _context = context;
        }

        public string GetBlogTitleByMaxBlogComment()
        {
            // Select Top(1) BlogID,Count(*) as 'Sayi' From Comments Group By BlogID Order By Sayi Desc
            var values = _context.Comments.GroupBy(x => x.BlogID).Select(y => new
            {
                BlogID = y.Key,
                Count = y.Count()
            }).OrderByDescending(z => z.Count).Take(1).FirstOrDefault();
            string blogName = _context.Blogs.Where(x => x.BlogID == values.BlogID).Select(y => y.Title).FirstOrDefault();
            return blogName;
        }
  
        public string GetBrandNameByMaxCar()
        {
            // Select Top(1) BrandID ,Count(*) as 'ToplamArac' From Cars Group By Brands.Name order by ToplamArac desc;
           var values = _context.Cars.GroupBy(x=>x.BrandID).Select(y=> new
           {
               BrandID=y.Key,
               Count=y.Count()
           }).OrderByDescending(z=>z.Count).Take(1).FirstOrDefault();
            string brandName = _context.Brands.Where(x=>x.BrandID == values.BrandID).Select(y=>y.Name).FirstOrDefault();
            return brandName;
        }

        public int GetAuthorCount()
        {
            var values = _context.Authors.Count();
            return values;
        }

        public decimal GetAvgRentPriceForDaily()
        {
            // SELECT Avg(Amount) FROM CarPricings WHERE PricingID = (SELECT PricingID FROM Pricings Where Name = 'Günlük');
            int id = _context.Pricings.Where(y=>y.Name=="Günlük").Select(z=>z.PricingID).FirstOrDefault();
            var values = _context.CarPricings.Where(w=>w.PricingID==id).Average(x => x.Amount);
            return values;
        }

        public decimal GetAvgRentPriceForMountly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Aylık").Select(z => z.PricingID).FirstOrDefault();
            var values = _context.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amount);
            return values;
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            int id = _context.Pricings.Where(y => y.Name == "Haftalık").Select(z => z.PricingID).FirstOrDefault();
            var values = _context.CarPricings.Where(w => w.PricingID == id).Average(x => x.Amount);
            return values;
        }

        public int GetBlogCount()
        {
            var values = _context.Blogs.Count();
            return values;
        }

        public int GetBrandCount()
        {
            var values = _context.Brands.Count();
            return values;
        }

        public string GetCarBrandAndModelByRentPriceDailyMax()
        {
            // Select * From CarPricings Where Amount = (Select Max(Amount) From CarPricings Where PricingsID = 3
            int pricingId = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(y => y.PricingID == pricingId).Max(x => x.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefault();
            string brandAndModel = _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandAndModel;

        }

        public string GetCarBrandAndModelByRentPriceDailyMin()
        {
            // Select * From CarPricings Where Amount = (Select Max(Amount) From CarPricings Where PricingsID = 3
            int pricingId = _context.Pricings.Where(x => x.Name == "Günlük").Select(y => y.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(y => y.PricingID == pricingId).Min(x => x.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(y => y.CarID).FirstOrDefault();
            string brandAndModel = _context.Cars.Where(x => x.CarID == carId).Include(y => y.Brand).Select(z => z.Brand.Name + " " + z.Model).FirstOrDefault();
            return brandAndModel;

        }

        public int GetCarCount()
        {
            var values = _context.Cars.Count();
            return values;
        }

        public int GetCarCountByFuelElectric()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Elektrik").Count();
            return value;
        }

        public int GetCarCountByFuelGasolineOrDiesel()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
            return value;
        }

        public int GetCarCountByKmSmallerThen1000()
        {
            var value = _context.Cars.Where(x => x.Km <= 1000).Count();
            return value;
        }

        public int GetCarCountByTransmissionIsAuto()
        {
            var value = _context.Cars.Where(x => x.Transmission == "Otomatik");
            return value.Count();
        }

        public int GetLocationCount()
        {
            var values = _context.Locations.Count();
            return values;
        }
    }
}

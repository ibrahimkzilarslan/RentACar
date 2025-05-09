using RentACar.Application.Interfaces.ReviewInterfaces;
using RentACar.Domain.Entities;
using RentACar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repositories.ReviewRepository
{
    public class ReviewRepository : IReviewRepository
    {

        private readonly RentACarContext _context;

        public ReviewRepository(RentACarContext context)
        {
            _context = context;
        }

        public List<Review> GetReviewsByCarId(int carID)
        {
            var values = _context.Reviews.Where(x=>x.CarID == carID).ToList();
            return values;
        }
    }
}

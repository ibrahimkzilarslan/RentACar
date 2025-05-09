using Microsoft.EntityFrameworkCore;
using RentACar.Application.Interfaces;
using RentACar.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RentACar.Persistence.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly RentACarContext _rentACarContext;

        public Repository(RentACarContext rentACarContext)
        {
            _rentACarContext = rentACarContext;
        }

        public async Task CreateAsync(T entity)
        {
            _rentACarContext.Set<T>().Add(entity);
            await _rentACarContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _rentACarContext.Set<T>().ToListAsync();
        }

        public async Task<T?> GetByFilterAsync(Expression<Func<T, bool>> filter)
        {
           return await _rentACarContext.Set<T?>().SingleOrDefaultAsync(filter);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _rentACarContext.Set<T>().FindAsync(id);
        }

        public async Task RemoveAsync(T entity)
        {
            _rentACarContext.Set<T>().Remove(entity);
            await _rentACarContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _rentACarContext.Set<T>().Update(entity);
            await _rentACarContext.SaveChangesAsync();
        }
    }
}

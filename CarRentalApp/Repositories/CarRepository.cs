using CarRentalApp.Data;
using CarRentalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApp.Repositories
{
    public class CarRepository<T> : IRepository<Car> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Car> _dbSet;
        public CarRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Car>();
        }
        public async Task AddAsync(Car entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await _context.Cars.ToListAsync();
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task UpdateAsync(Car entity)
        {
            throw new NotImplementedException();
        }
    }
}

using CarRentalApp.Data;
using CarRentalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApp.Repositories
{
    public class ClassificationRepository<T> : IRepository<Classification> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Classification> _dbSet;
        public ClassificationRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Classification>();
        }
        public async Task AddAsync(Classification entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Classification>> GetAllAsync()
        {
            return await _context.Classifications.ToListAsync();
        }

        public async Task<Classification> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task UpdateAsync(Classification entity)
        {
            throw new NotImplementedException();
        }
    }
}

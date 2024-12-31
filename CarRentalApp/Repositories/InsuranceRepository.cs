using CarRentalApp.Data;
using CarRentalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApp.Repositories
{
    public class InsuranceRepository<T> : IRepository<Insurance> where T : class

    {
        private readonly AppDbContext _context;
        private readonly DbSet<Insurance> _dbSet;
        public InsuranceRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Insurance>();
        }

        public async Task AddAsync(Insurance entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Insurance>> GetAllAsync()
        {
            return await _context.Insurances.ToListAsync();
        }

        public async Task<Insurance> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task UpdateAsync(Insurance entity)
        {
            throw new NotImplementedException();
        }
    }
}

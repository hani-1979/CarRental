using CarRentalApp.Data;
using CarRentalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApp.Repositories
{
    public class ModeelRepository<T> : IRepository<Modeel> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Modeel> _dbSet;
        public ModeelRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Modeel>();
        }
        public async Task AddAsync(Modeel entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Modeel>> GetAllAsync()
        {
            return await _context.Modeels.ToListAsync();
        }

        public async Task<Modeel> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task UpdateAsync(Modeel entity)
        {
            throw new NotImplementedException();
        }
    }
}

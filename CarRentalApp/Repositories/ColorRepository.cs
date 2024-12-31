using CarRentalApp.Data;
using CarRentalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApp.Repositories
{
    public class ColorRepository<T> : IRepository<Colour> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Colour> _dbSet;
        public ColorRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Colour>();
        }
        public async Task AddAsync(Colour entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Colour>> GetAllAsync()
        {
            return await _context.Colour.ToListAsync();
        }

        public async Task<Colour> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task UpdateAsync(Colour entity)
        {
            throw new NotImplementedException();
        }
    }
}

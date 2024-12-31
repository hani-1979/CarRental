using CarRentalApp.Data;
using CarRentalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApp.Repositories
{
    public class ManufactorerRepository<T> : IRepository<Manufactorer> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Manufactorer> _dbSet;
        public ManufactorerRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Manufactorer>();
        }
        public async Task AddAsync(Manufactorer entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Manufactorer>> GetAllAsync()
        {
            return await _context.Manufactorers.ToListAsync();
        }

        public  async Task<Manufactorer> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task UpdateAsync(Manufactorer entity)
        {
            throw new NotImplementedException();
        }
    }
}

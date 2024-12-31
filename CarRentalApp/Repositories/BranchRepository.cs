using CarRentalApp.Data;
using CarRentalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApp.Repositories
{
    public class BranchRepository<T> : IRepository<Branch> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Branch> _dbSet;
        public BranchRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Branch>();
        }
        public async Task AddAsync(Branch entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Branch>> GetAllAsync()
        {
            return await _context.Branches.ToListAsync();
        }

        public async Task<Branch> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task UpdateAsync(Branch entity)
        {
            throw new NotImplementedException();
        }
    }
}

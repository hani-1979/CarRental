using CarRentalApp.Data;
using CarRentalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApp.Repositories
{
    public class CompanyRepository<T> : IRepository<Company> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Company> _dbSet;
        public CompanyRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Company>();
        }
        public async Task AddAsync(Company entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await _context.Companys.ToListAsync();
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task UpdateAsync(Company entity)
        {
            throw new NotImplementedException();
        }
    }
}

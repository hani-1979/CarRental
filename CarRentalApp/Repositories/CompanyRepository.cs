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

        public Task<Company> ChangAccidentStatusStatusAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await _context.Companys.ToListAsync();
        }

        public Task<Company> GetByAccidentStatusAsync(int AccidentStatus)
        {
            throw new NotImplementedException();
        }

        public async Task<Company> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task<Company> GetByInsuranceStatusAsync(int InsuranceStatus)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Company>> GetByStatuteAsync(int statute)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> GetCompanyByAccidentIdAsync(int accidentId)
        {
            var CompanyId = await _context.Accidents
                               .Where(a => a.AccidentId == accidentId)
                               .Select(a => a.CompanyId)
                               .FirstOrDefaultAsync();

            // Simply return null if carId is zero or the result of the query is null
            return CompanyId == 0 ? (int?)null : CompanyId;  // Convert 0 to null
        }

        public Task<Company> UpdateAccidentStatusAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Company> UpdateAccidentStatusAsync(int Id, string status)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Company entity)
        {
            throw new NotImplementedException();
        }

        public Task<Company> UpdateClaimStatusAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Company> UpdateInsuranceStatusAsync(int Id)
        {
            throw new NotImplementedException();
        }

        Task<int?> IRepository<Company>.GetCarIdByAccidentIdAsync(int accidentId)
        {
            throw new NotImplementedException();
        }

        
    }
}

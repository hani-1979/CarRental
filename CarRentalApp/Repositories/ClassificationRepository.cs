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

        public Task<Classification> ChangAccidentStatusStatusAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Classification>> GetAllAsync()
        {
            return await _context.Classifications.ToListAsync();
        }

        public Task<Classification> GetByAccidentStatusAsync(int AccidentStatus)
        {
            throw new NotImplementedException();
        }

        public async Task<Classification> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task<Classification> GetByInsuranceStatusAsync(int InsuranceStatus)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Classification>> GetByStatuteAsync(int statute)
        {
            throw new NotImplementedException();
        }

        public Task<int?> GetCarIdByAccidentIdAsync(int accidentId)
        {
            throw new NotImplementedException();
        }

        public Task<int?> GetCompanyByAccidentIdAsync(int accidentId)
        {
            throw new NotImplementedException();
        }

        public Task<Classification> UpdateAccidentStatusAsync(int id)
        {
            throw new NotImplementedException();
        }

        

        public Task UpdateAsync(Classification entity)
        {
            throw new NotImplementedException();
        }

        public Task<Classification> UpdateClaimStatusAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Classification> UpdateInsuranceStatusAsync(int Id)
        {
            throw new NotImplementedException();
        }

       
    }
}

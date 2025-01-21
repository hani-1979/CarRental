using CarRentalApp.Data;
using CarRentalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApp.Repositories
{
    public class EstimationRepsitory<T> : IRepository<Estimation> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Estimation> _dbset;

        public EstimationRepsitory(AppDbContext context)
        {
            _context = context;
            _dbset=_context.Set<Estimation>();
        }
        public async Task AddAsync(Estimation entity)
        {
            await _dbset.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task<Estimation> ChangAccidentStatusStatusAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Estimation>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }

        public async Task<Estimation?> GetByAccidentStatusAsync(int Id)
        {
            return await _dbset.FindAsync(Id);
        }

        public Task<Estimation> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Estimation> GetByInsuranceStatusAsync(int Id)
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

        public Task<Estimation> UpdateAccidentStatusAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Estimation entity)
        {
            throw new NotImplementedException();
        }

        public Task<Estimation> UpdateClaimStatusAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Estimation> UpdateInsuranceStatusAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}

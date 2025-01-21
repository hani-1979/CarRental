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

        public Task<Branch> ChangAccidentStatusStatusAsync(int Id)
        {
            throw new NotImplementedException();
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

        public Task<int?> GetCarIdByAccidentIdAsync(int accidentId)
        {
            throw new NotImplementedException();
        }

        public Task<int?> GetCompanyByAccidentIdAsync(int accidentId)
        {
            throw new NotImplementedException();
        }

        public Task<Branch> UpdateAccidentStatusAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Branch> UpdateAccidentStatusAsync(int Id, string status)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Branch entity)
        {
            throw new NotImplementedException();
        }

        public Task<Branch> UpdateClaimStatusAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Branch> UpdateInsuranceStatusAsync(int Id)
        {
            throw new NotImplementedException();
        }

        
        Task IRepository<Branch>.DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

       

        Task<Branch> IRepository<Branch>.GetByAccidentStatusAsync(int AccidentStatus)
        {
            throw new NotImplementedException();
        }

       

        Task<Branch> IRepository<Branch>.GetByInsuranceStatusAsync(int InsuranceStatus)
        {
            throw new NotImplementedException();
        }

        

       
    }
}

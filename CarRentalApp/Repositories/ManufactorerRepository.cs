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

        public Task<Manufactorer> ChangAccidentStatusStatusAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Manufactorer>> GetAllAsync()
        {
            return await _context.Manufactorers.ToListAsync();
        }

        public Task<Manufactorer> GetByAccidentStatusAsync(int AccidentStatus)
        {
            throw new NotImplementedException();
        }

        public  async Task<Manufactorer> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task<Manufactorer> GetByInsuranceStatusAsync(int InsuranceStatus)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Manufactorer>> GetByStatuteAsync(int statute)
        {
            throw new NotImplementedException();
        }

        public Task<int> GetCarIdByAccidentIdAsync(int accidentId)
        {
            throw new NotImplementedException();
        }

        public Task<int?> GetCompanyByAccidentIdAsync(int accidentId)
        {
            throw new NotImplementedException();
        }

        public Task<Manufactorer> UpdateAccidentStatusAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Manufactorer> UpdateAccidentStatusAsync(int Id, string status)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Manufactorer entity)
        {
            throw new NotImplementedException();
        }

        Task<int?> IRepository<Manufactorer>.GetCarIdByAccidentIdAsync(int accidentId)
        {
            throw new NotImplementedException();
        }

        Task<Manufactorer> IRepository<Manufactorer>.UpdateClaimStatusAsync(int Id)
        {
            throw new NotImplementedException();
        }

        Task<Manufactorer> IRepository<Manufactorer>.UpdateInsuranceStatusAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}

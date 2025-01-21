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

        public Task<Colour> ChangAccidentStatusStatusAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Colour>> GetAllAsync()
        {
            return await _context.Colour.ToListAsync();
        }

        public Task<Colour> GetByAccidentStatusAsync(int AccidentStatus)
        {
            throw new NotImplementedException();
        }

        public async Task<Colour> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task<Colour> GetByInsuranceStatusAsync(int InsuranceStatus)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Colour>> GetByStatuteAsync(int statute)
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

        public Task<Colour> UpdateAccidentStatusAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Colour> UpdateAccidentStatusAsync(int Id, string status)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Colour entity)
        {
            throw new NotImplementedException();
        }

       

        Task<Colour> IRepository<Colour>.UpdateClaimStatusAsync(int Id)
        {
            throw new NotImplementedException();
        }

        Task<Colour> IRepository<Colour>.UpdateInsuranceStatusAsync(int Id)
        {
            throw new NotImplementedException();
        }
    }
}

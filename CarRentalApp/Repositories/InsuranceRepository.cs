using CarRentalApp.Data;
using CarRentalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApp.Repositories
{
    public class InsuranceRepository<T> : IRepository<Insurance> where T : class

    {
        private readonly AppDbContext _context;
        private readonly DbSet<Insurance> _dbSet;
        public InsuranceRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Insurance>();
        }

        public async Task AddAsync(Insurance entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task<Insurance> ChangAccidentStatusStatusAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Insurance>> GetAllAsync()
        {
            return await _context.Insurances.ToListAsync();
        }

        public async Task<Insurance> GetByAccidentStatusAsync(int AccidentStatus)
        {
            return await _dbSet.FindAsync(AccidentStatus);
        }

        public async Task<Insurance> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<Insurance> GetByInsuranceStatusAsync(int InsuranceStatus)
        {
            return await _dbSet.FindAsync(InsuranceStatus);
        }

        public Task<int?> GetCarIdByAccidentIdAsync(int accidentId)
        {
            throw new NotImplementedException();
        }

        public Task<int?> GetCompanyByAccidentIdAsync(int accidentId)
        {
            throw new NotImplementedException();
        }

        public Task<Insurance> UpdateAccidentStatusAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Insurance> UpdateAccidentStatusAsync(int Id, string status)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Insurance entity)
        {
            throw new NotImplementedException();
        }

        public async Task<Insurance> UpdateClaimStatusAsync(int Id)
        {
            var car = await _context.Cars.FindAsync(Id);
            if (car != null)
            {
                // Set the status to 1
                car.ClaimStatus = 1; // Assuming Status is a string. If it's an integer, use 1 instead of "1".


                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            return null;
        }

        public async Task<Insurance> UpdateInsuranceStatusAsync(int Id)
        {
            var car = await _context.Cars.FindAsync(Id);
            if (car != null)
            {
                // Set the status to 1
                car.InsuraceStatus = 1; // Assuming Status is a string. If it's an integer, use 1 instead of "1".


                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            return null;
        }

       
    }
}

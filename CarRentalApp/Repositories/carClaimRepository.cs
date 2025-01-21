using CarRentalApp.Data;
using CarRentalApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CarRentalApp.Repositories
{
    public class carClaimRepository<T> : IRepository<carClaim> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<carClaim> _dbset;

        public carClaimRepository(AppDbContext context)
        {
            _context = context;
            _dbset= _context.Set<carClaim>();
        }
        public async Task AddAsync(carClaim entity)
        {
            await _dbset.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task<carClaim> ChangAccidentStatusStatusAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<carClaim>> GetAllAsync()
        {
            return await _context.carClaim.ToListAsync();
        }

        public Task<carClaim> GetByAccidentStatusAsync(int AccidentStatus)
        {
            throw new NotImplementedException();
        }

        public async Task<carClaim> GetByIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public Task<carClaim> GetByInsuranceStatusAsync(int InsuranceStatus)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<carClaim>> GetByStatuteAsync(int statute)
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

        public Task<carClaim> UpdateAccidentStatusAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<carClaim> UpdateAccidentStatusAsync(int Id, string status)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(carClaim entity)
        {
            throw new NotImplementedException();
        }

        public async Task<carClaim> UpdateClaimStatusAsync(int Id)
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

        public Task<carClaim> UpdateInsuranceStatusAsync(int Id)
        {
            throw new NotImplementedException();
        }

        
    }
}

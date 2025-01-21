using CarRentalApp.Data;
using CarRentalApp.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.AccessControl;

namespace CarRentalApp.Repositories
{
    public class AccidentRepository<T> : IRepository<Accident> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Accident> _dbset;

        public AccidentRepository(AppDbContext context)
        {
            _context = context;
            _dbset = _context.Set<Accident>();
        }
        public async Task AddAsync(Accident entity)
        {
           await _dbset.AddAsync(entity);
           await _context.SaveChangesAsync();
        }

        public async Task<Accident> ChangAccidentStatusStatusAsync(int Id)
        {
            var accident = await _context.Accidents.FindAsync(Id);
            if (accident != null)
            {
                // Set the status to 1
                accident.AccidentId = 2; // Assuming Status is a string. If it's an integer, use 1 instead of "1".


                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            return null;
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Accident>> GetAllAsync()
        {
            return await _context.Accidents.ToListAsync();
        }

        public Task<Accident> GetByAccidentStatusAsync(int AccidentStatus)
        {
            throw new NotImplementedException();
        }

        public async Task<Accident> GetByIdAsync(int id)
        {
            return await _dbset.FindAsync(id);
        }

        public Task<Accident> GetByInsuranceStatusAsync(int InsuranceStatus)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Accident>> GetByStatuteAsync(int statute)
        {
            throw new NotImplementedException();
        }

        public async Task<int?> GetCarIdByAccidentIdAsync(int accidentId)
        {
            var carId = await _context.Accidents
                               .Where(a => a.AccidentId == accidentId)
                               .Select(a => a.CarId)
                               .FirstOrDefaultAsync();

            // Simply return null if carId is zero or the result of the query is null
            return carId == 0 ? (int?)null : carId;  // Convert 0 to null
        }

        public Task<int?> GetCompanyByAccidentIdAsync(int accidentId)
        {
            throw new NotImplementedException();
        }

        public async Task<Accident> UpdateAccidentStatusAsync(int id)
        {
            var car = await _context.Cars.FindAsync(id);
            if (car != null)
            {
                // Set the status to 1
                car.AccidenStatus = 1; // Assuming Status is a string. If it's an integer, use 1 instead of "1".


                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            return null;
        }

        

        public async Task UpdateAsync(Accident entity)
        {
             _dbset.Update(entity); // Update the entity
            await _context.SaveChangesAsync();
        }

        public Task<Accident> UpdateClaimStatusAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Accident> UpdateInsuranceStatusAsync(int Id)
        {
            throw new NotImplementedException();
        }

        
    }
}

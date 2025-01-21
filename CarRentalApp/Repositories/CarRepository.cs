using CarRentalApp.Data;
using CarRentalApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApp.Repositories
{
    public class CarRepository<T> : IRepository<Car> where T : class
    {
        private readonly AppDbContext _context;
        private readonly DbSet<Car> _dbSet;
        public CarRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<Car>();
        }
        public async Task AddAsync(Car entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Car>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<Car> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public Task UpdateAsync(Car entity)
        {
            throw new NotImplementedException();
        }


        public async Task<IEnumerable<Car>> GetByStatuteAsync(int status)
        {
            return await _context.Cars
                                .Where(c => c.AccidenStatus == status)
                                .ToListAsync();
        }

        public Task<Car> GetByInsuranceStatusAsync(int InsuranceStatus)
        {
            throw new NotImplementedException();
        }

        public Task<Car> GetByAccidentStatusAsync(int AccidentStatus)
        {
            throw new NotImplementedException();
        }

        

        public async Task<Car> UpdateInsuranceStatusAsync(int Id)
        {
            var car = await _context.Cars.FindAsync(Id);
            if (car != null)
            {
                // Set the status to 1
                car.AccidenStatus = 1; // Assuming Status is a string. If it's an integer, use 1 instead of "1".


                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            return null;
        }

        public async Task<Car> UpdateClaimStatusAsync(int Id)
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

        public async Task<Car> UpdateAccidentStatusAsync(int Id)
        {
            var car = await _context.Cars.FindAsync(Id);
            if (car != null)
            {
                // Set the status to 1
                car.AccidenStatus = 1; // Assuming Status is a string. If it's an integer, use 1 instead of "1".


                // Save changes to the database
                await _context.SaveChangesAsync();
            }
            return null;
        }

        public Task<Car> ChangAccidentStatusStatusAsync(int Id)
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
    }
}

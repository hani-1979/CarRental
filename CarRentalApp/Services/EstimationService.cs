using CarRentalApp.Data;
using CarRentalApp.Models;
using CarRentalApp.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApp.Services
{
    public class EstimationService : IEstimationService
    {
        private readonly IRepository<Estimation> _estimationRepository;
        private readonly AppDbContext _context;

        public EstimationService(IRepository<Estimation> estimationRepository,AppDbContext context)
        {
            _estimationRepository = estimationRepository;
            _context = context;
        }

        public async Task AddEstimation(Estimation estimation)
        {
            await _estimationRepository.AddAsync(estimation);
        }

        public Task DeleteEstimationAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteEstimationByIdAsync(int id)
        {
             await _estimationRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Estimation>> GetAllEstimationasync()
        {
            return await _estimationRepository.GetAllAsync();
        }

       
        public async Task<int?> GetEstIdByAccidentIdAsync(int AccidentId)
        {
            var estimation = await _context.Estimations
            .FirstOrDefaultAsync(e => e.AccidentId == AccidentId);

            if (estimation == null)
            {
                throw new Exception("Estimation not found for the given AccidentId.");
            }

            return estimation.EstimationId;
        }
        
        public async Task<Estimation> GetEstimationByIdAsync(int id)
        {
           return await _estimationRepository.GetByIdAsync(id);
        }

        public Task UpdateEstimationAsync(Estimation estimation)
        {
            throw new NotImplementedException();
        }
    }
}

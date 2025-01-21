using CarRentalApp.Models;
using CarRentalApp.Repositories;

namespace CarRentalApp.Services
{
    public class CarClaimService : ICarClaimService
    {
        private readonly IRepository<carClaim> _claimRepository;

        public CarClaimService(IRepository<carClaim> claimRepository)
        {
            _claimRepository = claimRepository;
        }
        public async Task AddClaim(carClaim claim)
        {
           await _claimRepository.AddAsync(claim);
        }

        public Task DeleteClaimAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<carClaim>> GetAllClaim()
        {
           return await _claimRepository.GetAllAsync();
        }

        public async Task<carClaim> GetcarClaimById(int claimId)
        {
            return await GetcarClaimById(claimId);
        }

        public Task UpdateClaim(carClaim claim)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateClaimStatus(int Id)
        {
            await _claimRepository.UpdateClaimStatusAsync(Id);
        }
    }
}

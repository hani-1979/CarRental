using CarRentalApp.Models;

namespace CarRentalApp.Services
{
    public interface ICarClaimService
    {
        Task<IEnumerable<carClaim>> GetAllClaim();
        Task<carClaim> GetcarClaimById(int claimId);
        Task AddClaim(carClaim claim);
        Task UpdateClaim(carClaim claim);
        Task DeleteClaimAsync(int id);
        Task UpdateClaimStatus(int Id);

    }
}

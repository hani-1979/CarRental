using CarRentalApp.Models;

namespace CarRentalApp.Services
{
    public interface IEstimationService
    {
        Task<IEnumerable<Estimation>> GetAllEstimationasync();
        Task<Estimation> GetEstimationByIdAsync(int id);
        Task AddEstimation(Estimation estimation);
        Task UpdateEstimationAsync(Estimation estimation);
        Task DeleteEstimationAsync(int id);
        Task<int?> GetEstIdByAccidentIdAsync(int EstimationId);

    }
}

using CarRentalApp.Models;

namespace CarRentalApp.Services
{
    public interface IClassificationService
    {
        Task<IEnumerable<Classification>> GetAllModeelsAsync();
        Task<Classification> GetClassificationByIdAsync(int id);
        Task AddClassificationAsync(Classification classification);
        Task UpdateClassificationAsync(Classification classification);
        Task DeleteClassificationAsync(int id);
    }
}

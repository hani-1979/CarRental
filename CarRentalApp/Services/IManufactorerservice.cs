using CarRentalApp.Models;

namespace CarRentalApp.Services
{
    public interface IManufactorerservice
    {
        Task<IEnumerable<Manufactorer>> GetAllManufactorerAsync();
        Task<Manufactorer> GetManufactorerByIdAsync(int id);
        Task AddManufactorerAsync(Manufactorer manufactorer);
        Task UpdateManufactorerAsync(Manufactorer manufactorer);
        Task DeleteManufactorerAsync(int id);
    }
}

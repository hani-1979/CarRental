using CarRentalApp.Models;

namespace CarRentalApp.Services
{
    public interface IModeelService
    {
        Task<IEnumerable<Modeel>> GetAllModeelsAsync();
        Task<Modeel> GetModeelByIdAsync(int id);
        Task AddModeelAsync(Modeel modeel);
        Task UpdateModeelAsync(Modeel modeel);
        Task DeleteModeelAsync(int id);
    }
}

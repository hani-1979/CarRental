using CarRentalApp.Models;

namespace CarRentalApp.Services
{
    public interface IAccidentService
    {
        Task<IEnumerable<Accident>> GetAllAccident();
        Task<Accident> GetAccidentById(int id);
        Task AddAccident(Accident accident);
        Task UpdateAccident(Accident accident);
        Task DeleteAccident(int id);
        Task UpdateAccidentStatusAsync(int Id);
        Task DeleteAccidentStatusAsync(int Id);
        Task<int?> GetCarIdByAccidentIdAsync(int AccidentId);
    }
}
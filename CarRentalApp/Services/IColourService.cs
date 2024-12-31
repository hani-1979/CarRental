using CarRentalApp.Models;
using System.Drawing;
using CarRentalApp.Data;

namespace CarRentalApp.Services
{
    public interface IColourService
    {
        Task<IEnumerable<Colour>> GetAllColourAsync();
        Task<Colour> GetColourByIdAsync(int id);
        Task AddColourAsync(Colour colour);
        Task UpdateColourAsync(Colour colour);
        Task DeleteColourAsync(int id);

    }
}

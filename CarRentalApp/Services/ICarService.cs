using CarRentalApp.Models;

namespace CarRentalApp.Services
{
    public interface ICarService
    {
        Task<IEnumerable<Car>> GetAllCarsAsync();
        Task<Car> GetCarByIdAsync(int id);
        Task AddCarAsync(Car car);
        Task UpdateCarAsync(Car car);
        Task DeleteCarAsync(int id);
        Task<Car> GetCarsByAccidentStatusAsync(int Status);
        Task UpdateCarAccidentStatusAsync(int Id);
        
    }
}

using CarRentalApp.Models;
using CarRentalApp.Repositories;

namespace CarRentalApp.Services
{
    public class CarService : ICarService
    {
        private readonly IRepository<Car> _carRepository;

        public CarService(IRepository<Car> carRepository)
        {
            _carRepository = carRepository;
        }
        public async Task AddCarAsync(Car car)
        {
            await _carRepository.AddAsync(car);
        }

        public Task DeleteCarAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Car>> GetAllCarsAsync()
        {
            return await _carRepository.GetAllAsync();
        }

        public async Task<Car> GetCarByIdAsync(int id)
        {
            return await _carRepository.GetByIdAsync(id);
        }

       
        public Task UpdateCarAsync(Car car)
        {
            throw new NotImplementedException();
        }

       
    }
}

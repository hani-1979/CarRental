using CarRentalApp.Models;
using CarRentalApp.Repositories;
using Microsoft.EntityFrameworkCore;
using Mono.TextTemplating;

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

       

        public Task<Car> GetCarsByAccidentStatusAsync(int Status)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Car>> GetCarsByStatusAsync(int Status)
        {
            throw new NotImplementedException();
        }

        public async Task<Car> GetCarsByStatuteAsync(int Status)
        {
            return await _carRepository.GetByInsuranceStatusAsync(Status);
        }

        public async Task UpdateCarAccidentStatusAsync(int Id)
        {
           await _carRepository.UpdateAccidentStatusAsync(Id);
        }

        public Task UpdateCarAsync(Car car)
        {
            throw new NotImplementedException();
        }

        public Task UpdateCarAsync(int Id)
        {
            throw new NotImplementedException();
        }

        
    }
}

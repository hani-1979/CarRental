using CarRentalApp.Models;
using CarRentalApp.Repositories;

namespace CarRentalApp.Services
{
    public class ManufactorerService : IManufactorerservice
        
    {
        private readonly IRepository<Manufactorer> _manufactorerRepository;

        public ManufactorerService(IRepository<Manufactorer> manufactorerRepository)
        {
            _manufactorerRepository = manufactorerRepository;
        }
        public async Task AddManufactorerAsync(Manufactorer manufactorer)
        {
            await _manufactorerRepository.AddAsync(manufactorer);
        }

        public async Task DeleteManufactorerAsync(int id)
        {
          await _manufactorerRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Manufactorer>> GetAllManufactorerAsync()
        {
            return await _manufactorerRepository.GetAllAsync();
        }

        public async Task<Manufactorer> GetManufactorerByIdAsync(int id)
        {
           return await _manufactorerRepository.GetByIdAsync(id);
        }

        public Task UpdateManufactorerAsync(Manufactorer manufactorer)
        {
            throw new NotImplementedException();
        }
    }
}

using CarRentalApp.Models;
using CarRentalApp.Repositories;

namespace CarRentalApp.Services
{
    public class ClassificationService : IClassificationService
    {
        private readonly IRepository<Classification> _classificationrepository;

        public ClassificationService(IRepository<Classification> classificationrepository)
        {
            _classificationrepository = classificationrepository;
        }
        public async Task AddClassificationAsync(Classification classification)
        {
            await _classificationrepository.AddAsync(classification);
        }

        public async Task DeleteClassificationAsync(int id)
        {
           await _classificationrepository.DeleteAsync(id);
        }

        

        public async Task<IEnumerable<Classification>> GetAllModeelsAsync()
        {
            return await _classificationrepository.GetAllAsync();
        }

        public async Task<Classification> GetClassificationByIdAsync(int id)
        {
            return await _classificationrepository.GetByIdAsync(id);
        }

        public Task UpdateClassificationAsync(Classification classification)
        {
            throw new NotImplementedException();
        }
    }
}

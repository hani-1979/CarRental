using CarRentalApp.Models;
using CarRentalApp.Repositories;

namespace CarRentalApp.Services
{
    public class AccidentService : IAccidentService
    {
        private readonly IRepository<Accident> _accidentRepositor;

        public AccidentService(IRepository<Accident> accidentRepositor)
        {
            _accidentRepositor = accidentRepositor;
        }
        public async Task AddAccident(Accident accident)
        {
            await _accidentRepositor.AddAsync(accident); 
        }

        public Task DeleteAccident(int id)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAccidentStatusAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Accident> GetAccidentById(int id)
        {
            return await _accidentRepositor.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Accident>> GetAllAccident()
        {
           return await _accidentRepositor.GetAllAsync();
        }

        public async Task<int?> GetCarIdByAccidentIdAsync(int AccidentId)
        {
             return await _accidentRepositor.GetCarIdByAccidentIdAsync(AccidentId);
        }

        public async Task UpdateAccident(Accident accident)
        {
            await _accidentRepositor.UpdateAsync(accident);
        }

        public async Task UpdateAccidentStatusAsync(int Id)
        {
            await _accidentRepositor.UpdateAccidentStatusAsync(Id);
        }
    }
}

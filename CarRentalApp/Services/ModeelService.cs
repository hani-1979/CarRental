using CarRentalApp.Models;
using CarRentalApp.Repositories;

namespace CarRentalApp.Services
{
    public class ModeelService : IModeelService
    {
        private readonly IRepository<Modeel> _modeelrepository;

        public ModeelService(IRepository<Modeel> modeelrepository)
        {
            _modeelrepository = modeelrepository;
        }
        public Task AddModeelAsync(Modeel modeel)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteModeelAsync(int id)
        {
           await _modeelrepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<Modeel>> GetAllModeelsAsync()
        {
            return await _modeelrepository.GetAllAsync();
        }

        public async Task<Modeel> GetModeelByIdAsync(int id)
        {
          return  await _modeelrepository.GetByIdAsync(id);
        }

        public Task UpdateModeelAsync(Modeel modeel)
        {
            throw new NotImplementedException();
        }
    }
}

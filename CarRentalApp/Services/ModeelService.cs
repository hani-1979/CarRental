using CarRentalApp.Data;
using CarRentalApp.Models;
using CarRentalApp.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApp.Services
{
    public class ModeelService : IModeelService
    {
        private readonly IRepository<Modeel> _modeelrepository;
        private readonly AppDbContext _context;

        public ModeelService(IRepository<Modeel> modeelrepository,AppDbContext context)
        {
            _modeelrepository = modeelrepository;
            _context = context;
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

        public async Task<int?> GetModelsByManufacturer(int Id)
        {
            var ModeelId = await _context.Modeels
        .Where(i => i.ManufactorerId == Id)
        .Select(i => i.ModeelId) // Return only the CompanyId
        .FirstOrDefaultAsync(); // Returns null if no match is found

            return ModeelId;
        }

        public Task UpdateModeelAsync(Modeel modeel)
        {
            throw new NotImplementedException();
        }
    }
}

using CarRentalApp.Models;
using CarRentalApp.Repositories;

namespace CarRentalApp.Services
{
    public class ColourService : IColourService
    {
        private readonly IRepository<Colour> _colourRepository;

        public ColourService(IRepository<Colour> ColourRepository)
        {
            _colourRepository = ColourRepository;
        }

        public async Task<Colour> GetColourByIdAsync(int id)
        {
            return await _colourRepository.GetByIdAsync(id);
        }

        public Task UpdateColourAsync(Colour colour)
        {
            throw new NotImplementedException();
        }

        async Task IColourService.AddColourAsync(Colour colour)
        {
            await _colourRepository.AddAsync(colour);
        }

        async Task IColourService.DeleteColourAsync(int id)
        {
             await _colourRepository.DeleteAsync(id);
        }

        async Task<IEnumerable<Colour>> IColourService.GetAllColourAsync()
        {
            return await _colourRepository.GetAllAsync();
        }

       

       
    }
}

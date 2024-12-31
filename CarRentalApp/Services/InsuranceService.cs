using CarRentalApp.Models;
using CarRentalApp.Repositories;

namespace CarRentalApp.Services
{
    public class InsuranceService : IInsuranceService
    {
        private readonly IRepository<Insurance> _insuranceRepository;

        public InsuranceService(IRepository<Insurance> insuranceRepository)
        {
            _insuranceRepository = insuranceRepository;
        }
        public async Task AddInsurace(Insurance insurance)
        {
           await _insuranceRepository.AddAsync(insurance);
        }

        public Task DeleteInsuraceAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Insurance>> GetAllInsuranceAsync()
        {
            return await _insuranceRepository.GetAllAsync();
        }

        public async Task<Insurance> GetInsuranceByIdAsync(int id)
        {
            return await _insuranceRepository.GetByIdAsync(id);
        }

        public Task UpdateInsurace(Insurance insurance)
        {
            throw new NotImplementedException();
        }
    }
}

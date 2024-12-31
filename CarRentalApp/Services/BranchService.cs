using CarRentalApp.Models;
using CarRentalApp.Repositories;

namespace CarRentalApp.Services
{
    public class BranchService : IBranchService
    {
        private readonly IRepository<Branch> _branchRepository;
        public BranchService(IRepository<Branch> branchRepository)
        {
            _branchRepository = branchRepository;
        }
        public async Task AddBranchAsync(Branch branch)
        {
            await _branchRepository.AddAsync(branch);
        }

        public Task DeleteBranchAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Branch>> GetAllBranchesAsync()
        {
            return await _branchRepository.GetAllAsync();
        }

        public async Task<Branch> GetBranchByIdAsync(int id)
        {
            return await _branchRepository.GetByIdAsync(id);
        }

        public Task UpdateBranchAsync(Branch branch)
        {
            throw new NotImplementedException();
        }
    }
}

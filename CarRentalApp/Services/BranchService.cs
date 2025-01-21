using CarRentalApp.Data;
using CarRentalApp.Models;
using CarRentalApp.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApp.Services
{
    public class BranchService : IBranchService
    {
        private readonly IRepository<Branch> _branchRepository;
        private readonly AppDbContext _context;

        public BranchService(IRepository<Branch> branchRepository,AppDbContext context)
        {
            _branchRepository = branchRepository;
            _context = context;
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
        public async Task<int?> GetBranchByCarIdAsync(int id)
        {
            var BranchId = await _context.Cars
         .Where(i => i.CarId == id)
         .Select(i => i.BranchId) // Return only the CompanyId
         .FirstOrDefaultAsync(); // Returns null if no match is found

            return BranchId;
        }
    }
}

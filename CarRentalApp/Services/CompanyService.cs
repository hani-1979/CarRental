using CarRentalApp.Data;
using CarRentalApp.Models;
using CarRentalApp.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CarRentalApp.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> _companyRepository;
        private readonly AppDbContext _context;

        public CompanyService(IRepository<Company> companyRepository,AppDbContext context)
        {
            _companyRepository = companyRepository;
            _context = context;
        }
       
        public async Task addCompany(Company company)
        {
            await _companyRepository.AddAsync(company);
        }

        public Task DeleteColourAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task deleteCompany(int id)
        {
            throw new NotImplementedException();
        }

       

        public async Task<IEnumerable<Company>> GetAllCompany()
        {
            return await _companyRepository.GetAllAsync();
        }

        public async Task<int?> GetCompanyByAccidentIdAsync(int id)
        {
            return await _companyRepository.GetCompanyByAccidentIdAsync(id);
        }

        public async Task<int?> GetCompanyByCarIdAsync(int id)
        {
            var companyId = await _context.Insurances
         .Where(i => i.CarId == id)
         .Select(i => i.CompanyId) // Return only the CompanyId
         .FirstOrDefaultAsync(); // Returns null if no match is found

            return companyId;
        }
       

        public async Task<Company> GetCompanyById(int id)
        {
           return await _companyRepository.GetByIdAsync(id);
        }

        
        public Task updateCompany(Company company)
        {
            throw new NotImplementedException();
        }
    }
}

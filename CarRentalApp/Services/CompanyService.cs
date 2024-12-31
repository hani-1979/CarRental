using CarRentalApp.Models;
using CarRentalApp.Repositories;

namespace CarRentalApp.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly IRepository<Company> _companyRepository;

        public CompanyService(IRepository<Company> companyRepository)
        {
            _companyRepository = companyRepository;
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

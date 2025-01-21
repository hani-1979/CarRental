using CarRentalApp.Models;
using System.Collections;

namespace CarRentalApp.Services
{
    public interface ICompanyService
    {
        Task<IEnumerable<Company>> GetAllCompany();
        Task <Company> GetCompanyById( int id);
        Task addCompany(Company company);
        Task updateCompany(Company company);
        Task deleteCompany(int id);
        Task<int?> GetCompanyByAccidentIdAsync(int id);
        Task<int?> GetCompanyByCarIdAsync(int id);
    }
}
